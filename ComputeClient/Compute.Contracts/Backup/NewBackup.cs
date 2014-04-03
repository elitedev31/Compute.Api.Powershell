namespace DD.CBU.Compute.Api.Contracts.Backup
{
    using System;
    using System.Xml.Serialization;

    public enum BackupServicePlans
    {
        Essentials,

        Advanced,

        Enterprise
    }

    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.0.30319.18020")]
    [Serializable]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Backup)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Backup, IsNullable = false)]
    public class NewBackup
    {
        [XmlAttribute]
        public string servicePlan { get; set; }

        public static NewBackup Create(BackupServicePlans plan)
        {
            switch (plan)
            {
                case BackupServicePlans.Essentials:
                    return new NewBackup { servicePlan = "Essentials" };
                case BackupServicePlans.Advanced:
                    return new NewBackup { servicePlan = "Advanced" };
                case BackupServicePlans.Enterprise:
                    return new NewBackup { servicePlan = "Enterprise" };
                default:
                    throw new InvalidOperationException(string.Format("Unknown plan {0}", plan));
            }
        }
    }
}