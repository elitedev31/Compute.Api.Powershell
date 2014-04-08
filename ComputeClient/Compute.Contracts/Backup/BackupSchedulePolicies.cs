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
    public class BackupSchedulePolicies
    {
        [XmlElement(ElementName = "schedulePolicy")]
        public BackupSchedulePolicy[] Items { get; set; }
    }

    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupSchedulePolicy
    {
        [XmlAttribute]
        public string name { get; set; }

        [XmlAttribute]
        public string description { get; set; }
    }
}