namespace DD.CBU.Compute.Api.Contracts.Network20
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    public partial class PortListSummaryType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    public partial class PortRangeType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort begin;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort end;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool endSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class CreatePortList
    {

        /// <remarks/>
        public string networkDomainId;

        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("port")]
        public PortRangeType[] port;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("childPortListId")]
        public string[] childPortListId;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class EditPortList
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public string description;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("port", IsNullable = true)]
        public EditPortListPort[] port;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("childPortListId", IsNullable = true)]
        public string[] childPortListId;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    public partial class EditPortListPort
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort begin;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool beginSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort end;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool endSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute("portList", Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class PortListType
    {

        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("port")]
        public PortRangeType[] port;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("childPortList")]
        public PortListSummaryType[] childPortList;

        /// <remarks/>
        public string state;

        /// <remarks/>
        public System.DateTime createTime;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class PortLists
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("portList")]
        public PortListType[] portList;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageNumber;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageNumberSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int totalCount;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalCountSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int pageSize;

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool pageSizeSpecified;
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute("deletePortList", Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public partial class DeletePortListType
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id;
    }
}