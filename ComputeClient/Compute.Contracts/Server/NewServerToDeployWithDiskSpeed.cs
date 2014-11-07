using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <summary>
    /// A new server to deploy
    /// </summary>
    [GeneratedCode("xsd", "4.0.30319.1")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = XmlNamespaceConstants.Server)]
    [XmlRoot(Namespace = XmlNamespaceConstants.Server, IsNullable = false, ElementName = "DeployServer")]
    public class NewServerToDeployWithDiskSpeed
    {
        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;


        /// <remarks/>
        public string imageId;

        /// <remarks/>
        public string administratorPassword;

        /// <remarks/>
        public bool start;

        /// <remarks/>
        public string privateIp;
        /// <remarks/>
        /// 
        public string networkId;

        /// <remarks/>
          [XmlElement("disk")] 
        public Disk[] disk;
    }
}