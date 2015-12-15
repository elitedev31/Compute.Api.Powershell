namespace DD.CBU.Compute.Api.Contracts.Network20
{
    using System.Xml.Serialization;

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.81.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class editVirtualListener
    {
        private bool poolIdFieldSpecified;
        private bool clientClonePoolIdFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool poolIdSpecified
        {
            get { return this.poolIdFieldSpecified; }
            set { this.poolIdFieldSpecified = value; }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool clientClonePoolIdSpecified
        {
            get { return this.clientClonePoolIdFieldSpecified; }
            set { this.clientClonePoolIdFieldSpecified = value; }
        }
    }
}
