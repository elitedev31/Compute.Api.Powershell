namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DeployedServerWithDisksType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("DeployedServerWithSoftwareLabels", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class DeployedServerWithSoftwareLabelsType : DeployedServerWithStatusType {
    
        private string[] softwareLabelField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("softwareLabel")]
        public string[] softwareLabel {
            get {
                return this.softwareLabelField;
            }
            set {
                this.softwareLabelField = value;
            }
        }
    }
}