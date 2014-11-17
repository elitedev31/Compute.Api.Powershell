namespace DD.CBU.Compute.Api.Contracts.Vip
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    public partial class RealServersRealServer
    {

        private string idField;

        private string nameField;

        private string serverIdField;

        private string serverNameField;

        private string serverIpField;

        private string inServiceField;

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string serverId
        {
            get
            {
                return this.serverIdField;
            }
            set
            {
                this.serverIdField = value;
            }
        }

        /// <remarks/>
        public string serverName
        {
            get
            {
                return this.serverNameField;
            }
            set
            {
                this.serverNameField = value;
            }
        }

        /// <remarks/>
        public string serverIp
        {
            get
            {
                return this.serverIpField;
            }
            set
            {
                this.serverIpField = value;
            }
        }

        /// <remarks/>
        public string inService
        {
            get
            {
                return this.inServiceField;
            }
            set
            {
                this.inServiceField = value;
            }
        }
    }
}