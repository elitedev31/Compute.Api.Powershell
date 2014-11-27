namespace DD.CBU.Compute.Api.Contracts.Vip
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    public partial class ProbeStatusCodeRange
    {

        private int lowerBoundField;

        private int upperBoundField;

        /// <remarks/>
        public int lowerBound
        {
            get
            {
                return this.lowerBoundField;
            }
            set
            {
                this.lowerBoundField = value;
            }
        }

        /// <remarks/>
        public int upperBound
        {
            get
            {
                return this.upperBoundField;
            }
            set
            {
                this.upperBoundField = value;
            }
        }
    }
}