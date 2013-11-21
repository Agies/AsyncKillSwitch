using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncKillSwitch
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new FooService();
            var ServiceBase = new System.ServiceModel.ServiceHost(service, new Uri("http://localhost:8080"));
            ServiceBase.Description.Behaviors.Add(new ServiceMetadataBehavior
                                                      {
                                                          HttpGetEnabled = true,
                                                      });
            
            ServiceBase.AddServiceEndpoint(typeof (IFooService), new BasicHttpBinding(), "FooService");
            ServiceBase.AddServiceEndpoint(typeof (IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), "MEX");
            ServiceBase.Open();
            service.Start();
            Console.ReadLine();
        }
    }

    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class FooService : IFooService
    {
        public static Random r = new Random();
        public ConcurrentDictionary<Guid, ThreadWrapper> runningThreads;

        public Action Job = () => Thread.Sleep(new TimeSpan(0, r.Next(1, 5), 0));
        
        public FooService()
        {
            
        }

        public void Start()
        {
            runningThreads = new ConcurrentDictionary<Guid, ThreadWrapper>();
            var task = new Task(RunJobs);
            task.ContinueWith(t =>
                                  {
                                      if (t.Exception != null) Console.WriteLine(t.Exception);
                                      Start();
                                  });
            Console.WriteLine("Starting runner loop...");
            //NOTE: THIS MUST BE ON A DIFFERENT THREAD!!!
            task.Start();
        }

        private void RunJobs()
        {
            try
            {
                while (true)
                {
                    var jobs = Enumerable.Range(0, 12).Select(i => Job).ToList();
                    Parallel.ForEach(jobs, new ParallelOptions {MaxDegreeOfParallelism = 10},
                                     j =>
                                         {
                                             var thread = Thread.CurrentThread;
                                             var info = new ThreadWrapper(thread, Guid.NewGuid());
                                             Console.WriteLine("Adding Thread: " + thread.ManagedThreadId);
                                             runningThreads.TryAdd(info.JobName, info);
                                             j();
                                             runningThreads.TryRemove(info.JobName, out info);
                                             Console.WriteLine("Removing Thread: " + thread.ManagedThreadId);
                                         });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Tearing down runner loop...");
            }
        }

        public GetRunningThreadsResponse GetRunningThreads()
        {
            return new GetRunningThreadsResponse
                       {
                           Threads = new List<ThreadInfo>(runningThreads.Select(t => new ThreadInfo
                                                                                         {
                                                                                             JobName = t.Key,
                                                                                             ExecutionTime = DateTime.Now - t.Value.ExecutionStart,
                                                                                             ThreadName = t.Value.Thread.ManagedThreadId,
                                                                                         }))
                       };
        }

        public void KillRunningThread(KillRunningThreadRequest request)
        {
            ThreadWrapper info;
            if (runningThreads.TryRemove(request.JobName, out info))
            {
                try
                {
                    Console.WriteLine("Removing Thread: " + info.Thread.ManagedThreadId);
                    info.Thread.Abort();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Thread Abort exploded... "+ e);
                }
            }
        }
    }

    public class ThreadWrapper
    {
        public ThreadWrapper(Thread thread, Guid jobName)
        {
            Thread = thread;
            JobName = jobName;
            ExecutionStart = DateTime.Now;
        }

        public Thread Thread { get; private set; }
        public Guid JobName { get; set; }

        public DateTime ExecutionStart { get; private set; }
    }

    public class ThreadInfo
    {
        public Guid JobName { get; set; }

        public TimeSpan ExecutionTime { get; set; }

        public int ThreadName { get; set; }
    }

    [ServiceContract]
    public interface IFooService
    {
        [OperationContract]
        GetRunningThreadsResponse GetRunningThreads();
        [OperationContract]
        void KillRunningThread(KillRunningThreadRequest request);
    }

    public class KillRunningThreadRequest
    {
        public Guid JobName { get; set; }
    }

    public class GetRunningThreadsResponse
    {
        public List<ThreadInfo> Threads { get; set; }
    }
}
