using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/datacenter")]
    public partial class NetworkingType {
    
        private PropertyType[] propertyField;
    
        private string typeField;
    
        private string maintenanceStatusField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("property")]
        public PropertyType[] property {
            get {
                return this.propertyField;
            }
            set {
                this.propertyField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string maintenanceStatus {
            get {
                return this.maintenanceStatusField;
            }
            set {
                this.maintenanceStatusField = value;
            }
        }
    }
}