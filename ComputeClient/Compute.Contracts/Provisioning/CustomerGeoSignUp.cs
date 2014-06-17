namespace DD.CBU.Compute.Api.Contracts.Provisioning
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    /// <summary>
    /// A new customer to sign up
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Provision)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Provision, IsNullable = false)]
    public class CustomerGeoSignUp
    {
        /// <remarks/>
        public Guid geoId;

        /// <remarks/>
        public string pricingPlanKey;
    }
}
