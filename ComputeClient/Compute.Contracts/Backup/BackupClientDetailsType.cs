using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/backup")]
    public partial class BackupClientDetailsType {
    
        private string descriptionField;
    
        private string schedulePolicyNameField;
    
        private string storagePolicyNameField;
    
        private AlertingType alertingField;
    
        private BackupTimesType timesField;
    
        private int totalBackupSizeGbField;
    
        private bool totalBackupSizeGbFieldSpecified;
    
        private string downloadUrlField;
    
        private RunningJobType runningJobField;
    
        private string idField;
    
        private string typeField;
    
        private bool isFileSystemField;
    
        private ClientStatusType statusField;
    
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
        public string schedulePolicyName {
            get {
                return this.schedulePolicyNameField;
            }
            set {
                this.schedulePolicyNameField = value;
            }
        }
    
        /// <remarks/>
        public string storagePolicyName {
            get {
                return this.storagePolicyNameField;
            }
            set {
                this.storagePolicyNameField = value;
            }
        }
    
        /// <remarks/>
        public AlertingType alerting {
            get {
                return this.alertingField;
            }
            set {
                this.alertingField = value;
            }
        }
    
        /// <remarks/>
        public BackupTimesType times {
            get {
                return this.timesField;
            }
            set {
                this.timesField = value;
            }
        }
    
        /// <remarks/>
        public int totalBackupSizeGb {
            get {
                return this.totalBackupSizeGbField;
            }
            set {
                this.totalBackupSizeGbField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalBackupSizeGbSpecified {
            get {
                return this.totalBackupSizeGbFieldSpecified;
            }
            set {
                this.totalBackupSizeGbFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public string downloadUrl {
            get {
                return this.downloadUrlField;
            }
            set {
                this.downloadUrlField = value;
            }
        }
    
        /// <remarks/>
        public RunningJobType runningJob {
            get {
                return this.runningJobField;
            }
            set {
                this.runningJobField = value;
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
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool isFileSystem {
            get {
                return this.isFileSystemField;
            }
            set {
                this.isFileSystemField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ClientStatusType status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
}