namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/backup")]
    public partial class AlertingType {
    
        private string[] emailAddressField;
    
        private TriggerType triggerField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("emailAddress")]
        public string[] emailAddress {
            get {
                return this.emailAddressField;
            }
            set {
                this.emailAddressField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public TriggerType trigger {
            get {
                return this.triggerField;
            }
            set {
                this.triggerField = value;
            }
        }
    }
}