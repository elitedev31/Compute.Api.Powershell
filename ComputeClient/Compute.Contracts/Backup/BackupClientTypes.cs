namespace DD.CBU.Compute.Api.Contracts.Backup
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The backup client types
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.18020")]
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupClientTypes
    {
        /// <summary>
        /// the items
        /// </summary>
        [XmlElement(ElementName = "backupClientType")]
        public BackupClientType[] Items { get; set; }
    }

    /// <summary>
    /// The backup client type
    /// </summary>
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupClientType
    {
        /// <summary>
        /// the type
        /// </summary>
        [XmlAttribute]
        public string type { get; set; }

        /// <summary>
        /// Is file system
        /// </summary>
        [XmlAttribute]
        public string isFileSystem { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [XmlAttribute]
        public string description { get; set; }
    }
}