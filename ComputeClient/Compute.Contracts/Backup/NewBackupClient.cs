namespace DD.CBU.Compute.Api.Contracts.Backup
{
    using System.Xml.Serialization;

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class NewBackupClient
    {
        /// <remarks/>
        public string type { get; set; }

        /// <remarks/>
        public string storagePolicyName { get; set; }

        /// <remarks/>
        public string schedulePolicyName { get; set; }

        /// <remarks/>
        public AlertingType alerting { get; set; }
    }
}