namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute("NatRule", Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class NatRuleType {
    
        private string idField;
    
        private string nameField;
    
        private string natIpField;
    
        private string sourceIpField;
    
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
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    
        /// <remarks/>
        public string natIp {
            get {
                return this.natIpField;
            }
            set {
                this.natIpField = value;
            }
        }
    
        /// <remarks/>
        public string sourceIp {
            get {
                return this.sourceIpField;
            }
            set {
                this.sourceIpField = value;
            }
        }
    }
}