namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DeployedServerWithSoftwareLabelsType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DeployedServerWithDisksType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class DeployedServerWithStatusType : DeployedServerType {
    
        private MachineStatusType[] machineStatusField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("machineStatus")]
        public MachineStatusType[] machineStatus {
            get {
                return this.machineStatusField;
            }
            set {
                this.machineStatusField = value;
            }
        }
    }
}