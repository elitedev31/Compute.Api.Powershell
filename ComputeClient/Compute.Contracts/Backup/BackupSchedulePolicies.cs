namespace DD.CBU.Compute.Api.Contracts.Backup
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// The backup schedule policies
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.18020")]
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupSchedulePolicies
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "schedulePolicy")]
        public BackupSchedulePolicy[] Items { get; set; }
    }

    /// <summary>
    /// The backup schedule policy
    /// </summary>
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class BackupSchedulePolicy
    {
        /// <summary>
        /// The name
        /// </summary>
        [XmlAttribute]
        public string name { get; set; }

        /// <summary>
        /// The description
        /// </summary>
        [XmlAttribute]
        public string description { get; set; }
    }
}