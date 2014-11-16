namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/datacenter")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/datacenter", IsNullable=false)]
    public partial class DatacentersWithLimits {
    
        private DatacenterWithLimitsType[] datacenterWithLimitsField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("datacenterWithLimits")]
        public DatacenterWithLimitsType[] datacenterWithLimits {
            get {
                return this.datacenterWithLimitsField;
            }
            set {
                this.datacenterWithLimitsField = value;
            }
        }
    }
}