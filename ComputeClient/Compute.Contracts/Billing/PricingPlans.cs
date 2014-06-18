namespace DD.CBU.Compute.Api.Contracts.Billing
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Xml.Serialization;

    /// <summary>
    /// Get pricing plans
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.WhiteLabel)]
    [XmlRoot(Namespace = XmlNamespaceConstants.WhiteLabel, IsNullable = false)]
    public class PricingPlans
    {
        /// <remarks/>
        [XmlElementAttribute("PricingPlans")]
        public PricingPlan[] pricingPlans;
    }

    /// <summary>
    /// Get pricing plan
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.WhiteLabel)]
    public class PricingPlan
    {
        public string key;

        public string name;

        public string description;

        public string currency;

        [XmlElementAttribute("pricingPlanItems")]
        public PricingPlanItem[] pricingPlanItems;
    }

    /// <summary>
    /// Get pricing plan
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.WhiteLabel)]
    public class PricingPlanItem
    {
        public string description;
    }

}
