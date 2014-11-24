namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/backup")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/backup", IsNullable=false)]
    public partial class BackupDetails {
    
        private BackupClientDetailsType[] backupClientField;
    
        private string assetIdField;
    
        private ServicePlan servicePlanField;
    
        private string stateField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("backupClient")]
        public BackupClientDetailsType[] backupClient {
            get {
                return this.backupClientField;
            }
            set {
                this.backupClientField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string assetId {
            get {
                return this.assetIdField;
            }
            set {
                this.assetIdField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ServicePlan servicePlan {
            get {
                return this.servicePlanField;
            }
            set {
                this.servicePlanField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string state {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
    }
}