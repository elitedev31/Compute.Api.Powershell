using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("DeployedImage", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class DeployedImageType {
    
        private string idField;
    
        private string nameField;
    
        private string descriptionField;
    
        private MachineSpecificationType machineSpecificationField;
    
        private string sourceServerIdField;
    
        private System.DateTime deployedTimeField;
    
        private bool deployedTimeFieldSpecified;
    
        private string locationField;
    
        private ProgressStatusType statusField;
    
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    
        /// <remarks/>
        public MachineSpecificationType machineSpecification {
            get {
                return this.machineSpecificationField;
            }
            set {
                this.machineSpecificationField = value;
            }
        }
    
        /// <remarks/>
        public string sourceServerId {
            get {
                return this.sourceServerIdField;
            }
            set {
                this.sourceServerIdField = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime deployedTime {
            get {
                return this.deployedTimeField;
            }
            set {
                this.deployedTimeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool deployedTimeSpecified {
            get {
                return this.deployedTimeFieldSpecified;
            }
            set {
                this.deployedTimeFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
    
        /// <remarks/>
        public ProgressStatusType status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
}