namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute("AclRuleList", Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class AclRuleListType {
    
        private string nameField;
    
        private AclRuleType[] aclRuleField;
    
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
        [System.Xml.Serialization.XmlElementAttribute("AclRule")]
        public AclRuleType[] AclRule {
            get {
                return this.aclRuleField;
            }
            set {
                this.aclRuleField = value;
            }
        }
    }
}