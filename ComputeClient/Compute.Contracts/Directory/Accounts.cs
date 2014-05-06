namespace DD.CBU.Compute.Api.Contracts.Directory
{
    /// <summary>
    /// The accounts
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = XmlNamespaceConstants.Directory)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = XmlNamespaceConstants.Directory, IsNullable = false)]
    public class Accounts
    {
        /// <summary>
        /// The items
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Account")]
        public Account[] Items;
    }
}
