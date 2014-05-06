namespace DD.CBU.Compute.Api.Contracts.Backup
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The backup storage policies
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.18020")]
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupStoragePolicies
    {
        /// <summary>
        /// The items
        /// </summary>
        [XmlElement(ElementName = "storagePolicy")]
        public BackupStoragePolicy[] Items { get; set; }
    }

    /// <summary>
    /// The backup storage policy
    /// </summary>
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupStoragePolicy
    {
        /// <summary>
        /// The retention period in days
        /// </summary>
        [XmlAttribute]
        public string retentionPeriodInDays { get; set; }

        /// <summary>
        /// The name
        /// </summary>
        [XmlAttribute]
        public string name { get; set; }

        /// <summary>
        /// The secondary location
        /// </summary>
        [XmlAttribute]
        public string secondaryLocation { get; set; }
    }
}