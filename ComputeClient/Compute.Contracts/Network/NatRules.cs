namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class NatRules {
    
        private NatRuleType[] natRuleField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("NatRule")]
        public NatRuleType[] NatRule {
            get {
                return this.natRuleField;
            }
            set {
                this.natRuleField = value;
            }
        }
    }
}