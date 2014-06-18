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
        [XmlElementAttribute("PricingPlan")]
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
        /// <remarks/>
        public string key;

        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;

        /// <remarks/>
        public string currency;

        /// <remarks/>
        public bool hasPromotionCodes;

        /// <remarks/>
        public double subscriptionPrice;

        /// <remarks/>
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
        /// <remarks/>
        public string key;

        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;

        /// <remarks/>
        public bool unlimited;

        /// <remarks>
        /// Optional
        /// </remarks>
        public int quantity;

        /// <remarks>
        /// Optional
        /// </remarks>
        public double pricePerAdditional;
    }

}
