namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("ServerImageWithState", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class ServerImageWithStateType {
    
        private string idField;
    
        private string locationField;
    
        private string nameField;
    
        private string descriptionField;
    
        private OperatingSystemType operatingSystemField;
    
        private int cpuCountField;
    
        private int memoryMbField;
    
        private int osStorageGbField;
    
        private DiskType[] additionalDiskField;
    
        private string[] softwareLabelField;
    
        private ServerImageWithStateTypeSource sourceField;
    
        private string stateField;
    
        private System.DateTime deployedTimeField;
    
        private bool deployedTimeFieldSpecified;
    
        private MachineStatusType[] machineStatusField;
    
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
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
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
        public OperatingSystemType operatingSystem {
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
        public int osStorageGb {
            get {
                return this.osStorageGbField;
            }
            set {
                this.osStorageGbField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("additionalDisk")]
        public DiskType[] additionalDisk {
            get {
                return this.additionalDiskField;
            }
            set {
                this.additionalDiskField = value;
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
        public ServerImageWithStateTypeSource source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
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