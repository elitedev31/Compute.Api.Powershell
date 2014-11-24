namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/backup")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/backup", IsNullable=false)]
    public partial class ModifyBackupClient {
    
        private string storagePolicyNameField;
    
        private string schedulePolicyNameField;
    
        private AlertingType alertingField;
    
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
        public string schedulePolicyName {
            get {
                return this.schedulePolicyNameField;
            }
            set {
                this.schedulePolicyNameField = value;
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
    }
}