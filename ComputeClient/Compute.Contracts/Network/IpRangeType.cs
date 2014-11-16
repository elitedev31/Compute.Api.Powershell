namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    public partial class IpRangeType {
    
        private string ipAddressField;
    
        private string netmaskField;
    
        /// <remarks/>
        public string ipAddress {
            get {
                return this.ipAddressField;
            }
            set {
                this.ipAddressField = value;
            }
        }
    
        /// <remarks/>
        public string netmask {
            get {
                return this.netmaskField;
            }
            set {
                this.netmaskField = value;
            }
        }
    }
}