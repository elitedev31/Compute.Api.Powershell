namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ServerWithBackupType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class ServerWithStateType {
    
        private string nameField;
    
        private string descriptionField;
    
        private OSType operatingSystemField;
    
        private int cpuCountField;
    
        private int memoryMbField;
    
        private DiskWithSpeedType[] diskField;
    
        private string[] softwareLabelField;
    
        private string sourceImageIdField;
    
        private string networkIdField;
    
        private string machineNameField;
    
        private string privateIpField;
    
        private string publicIpField;
    
        private System.DateTime createdField;
    
        private bool isDeployedField;
    
        private bool isStartedField;
    
        private string stateField;
    
        private ProgressStatusType statusField;
    
        private MachineStatusType[] machineStatusField;
    
        private string idField;
    
        private string locationField;
    
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
        public OSType operatingSystem {
            get {
                return this.operatingSystemField;
            }
            set {
                this.operatingSystemField = value;
            }
        }
    
        /// <remarks/>
        public int cpuCount {
            get {
                return this.cpuCountField;
            }
            set {
                this.cpuCountField = value;
            }
        }
    
        /// <remarks/>
        public int memoryMb {
            get {
                return this.memoryMbField;
            }
            set {
                this.memoryMbField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("disk")]
        public DiskWithSpeedType[] disk {
            get {
                return this.diskField;
            }
            set {
                this.diskField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("softwareLabel")]
        public string[] softwareLabel {
            get {
                return this.softwareLabelField;
            }
            set {
                this.softwareLabelField = value;
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
        public string machineName {
            get {
                return this.machineNameField;
            }
            set {
                this.machineNameField = value;
            }
        }
    
        /// <remarks/>
        public string privateIp {
            get {
                return this.privateIpField;
            }
            set {
                this.privateIpField = value;
            }
        }
    
        /// <remarks/>
        public string publicIp {
            get {
                return this.publicIpField;
            }
            set {
                this.publicIpField = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
            }
        }
    
        /// <remarks/>
        public bool isDeployed {
            get {
                return this.isDeployedField;
            }
            set {
                this.isDeployedField = value;
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
        public string state {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
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
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("machineStatus")]
        public MachineStatusType[] machineStatus {
            get {
                return this.machineStatusField;
            }
            set {
                this.machineStatusField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
    }
}