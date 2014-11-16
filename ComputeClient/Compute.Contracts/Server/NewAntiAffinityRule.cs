namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class NewAntiAffinityRule {
    
        private string[] serverIdField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("serverId")]
        public string[] serverId {
            get {
                return this.serverIdField;
            }
            set {
                this.serverIdField = value;
            }
        }
    }
}