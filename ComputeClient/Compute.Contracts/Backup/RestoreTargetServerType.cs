using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/backup")]
    public partial class RestoreTargetServerType {
    
        private string nameField;
    
        private string descriptionField;
    
        private OSType operatingSystemField;
    
        private int cpuCountField;
    
        private int memoryMbField;
    
        private DiskWithSpeedType[] diskField;
    
        private string sourceImageIdField;
    
        private string[] softwareLabelField;
    
        private string networkIdField;
    
        private string machineNameField;
    
        private string privateIpField;
    
        private System.DateTime createdField;
    
        private RestoreTargetServerTypeBackup backupField;
    
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
        public string sourceImageId {
            get {
                return this.sourceImageIdField;
            }
            set {
                this.sourceImageIdField = value;
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
        public System.DateTime created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
            }
        }
    
        /// <remarks/>
        public RestoreTargetServerTypeBackup backup {
            get {
                return this.backupField;
            }
            set {
                this.backupField = value;
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