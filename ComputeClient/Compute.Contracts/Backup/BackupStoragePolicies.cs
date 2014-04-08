namespace DD.CBU.Compute.Api.Contracts.Backup
{
    using System;
    using System.Xml.Serialization;

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.18020")]
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupStoragePolicies
    {
        [XmlElement(ElementName = "storagePolicy")]
        public BackupStoragePolicy[] Items { get; set; }
    }

    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupStoragePolicy
    {
        [XmlAttribute]
        public string retentionPeriodInDays { get; set; }

        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string secondaryLocation { get; set; }
    }
}