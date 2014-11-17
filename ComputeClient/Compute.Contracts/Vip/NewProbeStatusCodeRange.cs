namespace DD.CBU.Compute.Api.Contracts.Vip
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    public partial class NewProbeStatusCodeRange
    {

        private string lowerBoundField;

        private string upperBoundField;

        /// <remarks/>
        public string lowerBound
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
        public string upperBound
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