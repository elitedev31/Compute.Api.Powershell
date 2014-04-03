namespace DD.CBU.Compute.Api.Contracts.Backup
{
    using System;
    using System.Xml.Serialization;

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.18020")]
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class ModifyBackup
    {
        [XmlAttribute]
        public string servicePlan { get; set; }

        public static ModifyBackup Create(BackupServicePlans plan)
        {
            switch (plan)
            {
                case BackupServicePlans.Essentials:
                    return new ModifyBackup { servicePlan = "Essentials" };
                case BackupServicePlans.Advanced:
                    return new ModifyBackup { servicePlan = "Advanced" };
                case BackupServicePlans.Enterprise:
                    return new ModifyBackup { servicePlan = "Enterprise" };
                default:
                    throw new InvalidOperationException(string.Format("Unknown plan {0}", plan));
            }
        }
    }
}