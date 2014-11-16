namespace DD.CBU.Compute.Api.Contracts.Directory
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/directory")]
    [System.Xml.Serialization.XmlRootAttribute("Role", Namespace="http://oec.api.opsource.net/schemas/directory", IsNullable=false)]
    public partial class RoleType {
    
        private string nameField;
    
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    }
}