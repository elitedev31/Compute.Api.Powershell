using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Contracts.Network2._0
{
    using DD.CBU.Compute.Api.Contracts.General;
    using System.Xml.Serialization;

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "urn:didata.com:api:cloud:types")]
    [System.Xml.Serialization.XmlRootAttribute("response", Namespace = "urn:didata.com:api:cloud:types", IsNullable = false)]
    public class response
    {
        /// <remarks/>
        public string operation { get; set; }

        /// <remarks/>
        public string responseCode { get; set; }

        /// <remarks/>
        public string message { get; set; }

        /// <remarks/>
        public string requestId { get; set; }

        /// <summary>
        /// The additional information
        /// </summary>
        [XmlElement("info")]
        public AdditionalInformation[] additionalInformation { get; set; }
    }
}
