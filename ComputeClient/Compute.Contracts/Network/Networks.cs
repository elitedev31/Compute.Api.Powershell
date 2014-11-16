namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class Networks {
    
        private NetworkType[] networkField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Network")]
        public NetworkType[] Network {
            get {
                return this.networkField;
            }
            set {
                this.networkField = value;
            }
        }
    }
}