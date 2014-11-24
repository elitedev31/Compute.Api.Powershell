namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/backup")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/backup", IsNullable=false)]
    public partial class RestoreBackup {
    
        private System.DateTime asAtDateField;
    
        private bool asAtDateFieldSpecified;
    
        private string targetServerIdField;
    
        /// <remarks/>
        public System.DateTime asAtDate {
            get {
                return this.asAtDateField;
            }
            set {
                this.asAtDateField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool asAtDateSpecified {
            get {
                return this.asAtDateFieldSpecified;
            }
            set {
                this.asAtDateFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public string targetServerId {
            get {
                return this.targetServerIdField;
            }
            set {
                this.targetServerIdField = value;
            }
        }
    }
}