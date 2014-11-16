namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    public partial class Ips {
    
        private int subnetSizeField;
    
        private string[] ipField;
    
        /// <remarks/>
        public int subnetSize {
            get {
                return this.subnetSizeField;
            }
            set {
                this.subnetSizeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Ip")]
        public string[] Ip {
            get {
                return this.ipField;
            }
            set {
                this.ipField = value;
            }
        }
    }
}