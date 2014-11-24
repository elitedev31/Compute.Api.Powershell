namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/backup")]
    public partial class BackupTimesType {
    
        private System.DateTime lastBackupField;
    
        private bool lastBackupFieldSpecified;
    
        private System.DateTime nextBackupField;
    
        private bool nextBackupFieldSpecified;
    
        private System.DateTime lastOnlineField;
    
        private bool lastOnlineFieldSpecified;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime lastBackup {
            get {
                return this.lastBackupField;
            }
            set {
                this.lastBackupField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lastBackupSpecified {
            get {
                return this.lastBackupFieldSpecified;
            }
            set {
                this.lastBackupFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime nextBackup {
            get {
                return this.nextBackupField;
            }
            set {
                this.nextBackupField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool nextBackupSpecified {
            get {
                return this.nextBackupFieldSpecified;
            }
            set {
                this.nextBackupFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime lastOnline {
            get {
                return this.lastOnlineField;
            }
            set {
                this.lastOnlineField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lastOnlineSpecified {
            get {
                return this.lastOnlineFieldSpecified;
            }
            set {
                this.lastOnlineFieldSpecified = value;
            }
        }
    }
}