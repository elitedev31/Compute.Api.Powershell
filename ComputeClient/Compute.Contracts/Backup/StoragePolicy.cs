namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/backup")]
    public partial class StoragePolicy {
    
        private int retentionPeriodInDaysField;
    
        private string nameField;
    
        private string secondaryLocationField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int retentionPeriodInDays {
            get {
                return this.retentionPeriodInDaysField;
            }
            set {
                this.retentionPeriodInDaysField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string secondaryLocation {
            get {
                return this.secondaryLocationField;
            }
            set {
                this.secondaryLocationField = value;
            }
        }
    }
}