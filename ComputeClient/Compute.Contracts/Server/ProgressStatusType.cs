namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class ProgressStatusType {
    
        private string actionField;
    
        private System.DateTime requestTimeField;
    
        private string userNameField;
    
        private int numberOfStepsField;
    
        private bool numberOfStepsFieldSpecified;
    
        private System.DateTime updateTimeField;
    
        private bool updateTimeFieldSpecified;
    
        private ProgressStatusStepType stepField;
    
        private string failureReasonField;
    
        /// <remarks/>
        public string action {
            get {
                return this.actionField;
            }
            set {
                this.actionField = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime requestTime {
            get {
                return this.requestTimeField;
            }
            set {
                this.requestTimeField = value;
            }
        }
    
        /// <remarks/>
        public string userName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
    
        /// <remarks/>
        public int numberOfSteps {
            get {
                return this.numberOfStepsField;
            }
            set {
                this.numberOfStepsField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool numberOfStepsSpecified {
            get {
                return this.numberOfStepsFieldSpecified;
            }
            set {
                this.numberOfStepsFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime updateTime {
            get {
                return this.updateTimeField;
            }
            set {
                this.updateTimeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool updateTimeSpecified {
            get {
                return this.updateTimeFieldSpecified;
            }
            set {
                this.updateTimeFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public ProgressStatusStepType step {
            get {
                return this.stepField;
            }
            set {
                this.stepField = value;
            }
        }
    
        /// <remarks/>
        public string failureReason {
            get {
                return this.failureReasonField;
            }
            set {
                this.failureReasonField = value;
            }
        }
    }
}