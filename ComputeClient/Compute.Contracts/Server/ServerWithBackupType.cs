namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class ServerWithBackupType : ServerWithStateType {
    
        private ServerBackupType backupField;
    
        /// <remarks/>
        public ServerBackupType backup {
            get {
                return this.backupField;
            }
            set {
                this.backupField = value;
            }
        }
    }
}