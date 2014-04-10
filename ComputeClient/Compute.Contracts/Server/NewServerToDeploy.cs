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
    [XmlRoot(Namespace = XmlNamespaceConstants.Server, IsNullable = false, ElementName = "Server")]
    public class NewServerToDeploy
    {
        /// <remarks/>
        public string name;

        /// <remarks/>
        public string description;

        /// <remarks/>
        public string vlanResourcePath;

        /// <remarks/>
        public string imageResourcePath;

        /// <remarks/>
        public string administratorPassword;

        /// <remarks/>
        public bool isStarted;
    }
}