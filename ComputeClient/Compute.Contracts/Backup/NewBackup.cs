namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/backup")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/backup", IsNullable=false)]
    public partial class NewBackup {
    
        private ServicePlan servicePlanField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ServicePlan servicePlan {
            get {
                return this.servicePlanField;
            }
            set {
                this.servicePlanField = value;
            }
        }
    }
}