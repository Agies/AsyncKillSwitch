﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Engage.Bar {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GetRunningThreadsResponse", Namespace="http://schemas.datacontract.org/2004/07/AsyncKillSwitch")]
    [System.SerializableAttribute()]
    public partial class GetRunningThreadsResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private Engage.Bar.ThreadInfo[] ThreadsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Engage.Bar.ThreadInfo[] Threads {
            get {
                return this.ThreadsField;
            }
            set {
                if ((object.ReferenceEquals(this.ThreadsField, value) != true)) {
                    this.ThreadsField = value;
                    this.RaisePropertyChanged("Threads");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ThreadInfo", Namespace="http://schemas.datacontract.org/2004/07/AsyncKillSwitch")]
    [System.SerializableAttribute()]
    public partial class ThreadInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.TimeSpan ExecutionTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid JobNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ThreadNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan ExecutionTime {
            get {
                return this.ExecutionTimeField;
            }
            set {
                if ((this.ExecutionTimeField.Equals(value) != true)) {
                    this.ExecutionTimeField = value;
                    this.RaisePropertyChanged("ExecutionTime");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid JobName {
            get {
                return this.JobNameField;
            }
            set {
                if ((this.JobNameField.Equals(value) != true)) {
                    this.JobNameField = value;
                    this.RaisePropertyChanged("JobName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ThreadName {
            get {
                return this.ThreadNameField;
            }
            set {
                if ((this.ThreadNameField.Equals(value) != true)) {
                    this.ThreadNameField = value;
                    this.RaisePropertyChanged("ThreadName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="KillRunningThreadRequest", Namespace="http://schemas.datacontract.org/2004/07/AsyncKillSwitch")]
    [System.SerializableAttribute()]
    public partial class KillRunningThreadRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid JobNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid JobName {
            get {
                return this.JobNameField;
            }
            set {
                if ((this.JobNameField.Equals(value) != true)) {
                    this.JobNameField = value;
                    this.RaisePropertyChanged("JobName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Bar.IFooService")]
    public interface IFooService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFooService/GetRunningThreads", ReplyAction="http://tempuri.org/IFooService/GetRunningThreadsResponse")]
        Engage.Bar.GetRunningThreadsResponse GetRunningThreads();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFooService/GetRunningThreads", ReplyAction="http://tempuri.org/IFooService/GetRunningThreadsResponse")]
        System.Threading.Tasks.Task<Engage.Bar.GetRunningThreadsResponse> GetRunningThreadsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFooService/KillRunningThread", ReplyAction="http://tempuri.org/IFooService/KillRunningThreadResponse")]
        void KillRunningThread(Engage.Bar.KillRunningThreadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFooService/KillRunningThread", ReplyAction="http://tempuri.org/IFooService/KillRunningThreadResponse")]
        System.Threading.Tasks.Task KillRunningThreadAsync(Engage.Bar.KillRunningThreadRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFooServiceChannel : Engage.Bar.IFooService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FooServiceClient : System.ServiceModel.ClientBase<Engage.Bar.IFooService>, Engage.Bar.IFooService {
        
        public FooServiceClient() {
        }
        
        public FooServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FooServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FooServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FooServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Engage.Bar.GetRunningThreadsResponse GetRunningThreads() {
            return base.Channel.GetRunningThreads();
        }
        
        public System.Threading.Tasks.Task<Engage.Bar.GetRunningThreadsResponse> GetRunningThreadsAsync() {
            return base.Channel.GetRunningThreadsAsync();
        }
        
        public void KillRunningThread(Engage.Bar.KillRunningThreadRequest request) {
            base.Channel.KillRunningThread(request);
        }
        
        public System.Threading.Tasks.Task KillRunningThreadAsync(Engage.Bar.KillRunningThreadRequest request) {
            return base.Channel.KillRunningThreadAsync(request);
        }
    }
}
