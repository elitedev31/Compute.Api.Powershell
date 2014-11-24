namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/backup")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/backup", IsNullable=false)]
    public partial class RestoreTargetServers {
    
        private RestoreTargetServerType[] serverField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("server")]
        public RestoreTargetServerType[] server {
            get {
                return this.serverField;
            }
            set {
                this.serverField = value;
            }
        }
    }
}