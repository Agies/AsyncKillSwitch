using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows.Input;
using Engage.Bar;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;

namespace Engage
{
    public class JobWatcherViewModel : ViewModelBase
    {
        private readonly Timer _timer;
        public JobWatcherViewModel()
        {
            Jobs = new List<JobViewModel>();

            var client = new Bar.FooServiceClient();
            _timer = new Timer(2000);
            _timer.Elapsed += (sender, args) =>
                                  {
                                      var newJobs = new List<JobViewModel>();
                                      try
                                      {
                                          var result = client.GetRunningThreads();
                                          newJobs.AddRange(result.Threads.Select(t => new JobViewModel
                                                                                          {
                                                                                              JobName = t.JobName,
                                                                                              ThreadName = t.ThreadName,
                                                                                              Elapsed = t.ExecutionTime
                                                                                          }));
                                      }
                                      catch (Exception e)
                                      {
                                          return;
                                      }
                                      DispatcherHelper.CheckBeginInvokeOnUI(
                                          () =>
                                              {

                                                  Jobs = newJobs;
                                              });
                                  };
            _timer.Start();
        }
        private List<JobViewModel> _jobs;       
        public List<JobViewModel> Jobs
        {
            get { return _jobs; }
            set
            {
                if (_jobs == value) return;
                _jobs = value;
                RaisePropertyChanged("Jobs");
            }
        }
    }

    public class JobViewModel : ViewModelBase
    {
        public JobViewModel()
        {
            client = new Bar.FooServiceClient();
        }

        private ICommand _killIt;
        public Guid JobName { get; set; }
        public int ThreadName { get; set; }
        public ICommand KillIt
        {
            get { return _killIt ?? (_killIt = new RelayCommand(OnKillIt)); }
        }

        private TimeSpan _elapsed;
        private FooServiceClient client;

        public TimeSpan Elapsed
        {
            get { return _elapsed; }
            set
            {
                if (_elapsed == value) return;
                _elapsed = value;
                RaisePropertyChanged("Elapsed");
            }
        }

        private void OnKillIt()
        {
            try
            {
                client.KillRunningThread(new KillRunningThreadRequest
                                             {
                                                 JobName = JobName,
                                             });
            }
            catch (Exception e)
            {
                
            }
        }
    }
}