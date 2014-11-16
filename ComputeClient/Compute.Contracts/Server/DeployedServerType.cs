namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DeployedServerWithStatusType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DeployedServerWithSoftwareLabelsType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DeployedServerWithDisksType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("DeployedServer", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class DeployedServerType {
    
        private string idField;
    
        private string nameField;
    
        private string descriptionField;
    
        private MachineSpecificationType machineSpecificationField;
    
        private string sourceImageIdField;
    
        private string networkIdField;
    
        private string privateIpAddressField;
    
        private string publicIpAddressField;
    
        private string machineNameField;
    
        private bool isStartedField;
    
        private System.DateTime deployedTimeField;
    
        private bool deployedTimeFieldSpecified;
    
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
        public string sourceImageId {
            get {
                return this.sourceImageIdField;
            }
            set {
                this.sourceImageIdField = value;
            }
        }
    
        /// <remarks/>
        public string networkId {
            get {
                return this.networkIdField;
            }
            set {
                this.networkIdField = value;
            }
        }
    
        /// <remarks/>
        public string privateIpAddress {
            get {
                return this.privateIpAddressField;
            }
            set {
                this.privateIpAddressField = value;
            }
        }
    
        /// <remarks/>
        public string publicIpAddress {
            get {
                return this.publicIpAddressField;
            }
            set {
                this.publicIpAddressField = value;
            }
        }
    
        /// <remarks/>
        public string machineName {
            get {
                return this.machineNameField;
            }
            set {
                this.machineNameField = value;
            }
        }
    
        /// <remarks/>
        public bool isStarted {
            get {
                return this.isStartedField;
            }
            set {
                this.isStartedField = value;
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