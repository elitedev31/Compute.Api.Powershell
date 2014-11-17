namespace DD.CBU.Compute.Api.Contracts.Vip
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    public partial class VipsVip
    {

        private string idField;

        private string nameField;

        private string ipAddressField;

        private string portField;

        private string protocolField;

        private string vipTargetTypeField;

        private string vipTargetIdField;

        private string vipTargetNameField;

        private string replyToIcmpField;

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
        public string ipAddress
        {
            get
            {
                return this.ipAddressField;
            }
            set
            {
                this.ipAddressField = value;
            }
        }

        /// <remarks/>
        public string port
        {
            get
            {
                return this.portField;
            }
            set
            {
                this.portField = value;
            }
        }

        /// <remarks/>
        public string protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }

        /// <remarks/>
        public string vipTargetType
        {
            get
            {
                return this.vipTargetTypeField;
            }
            set
            {
                this.vipTargetTypeField = value;
            }
        }

        /// <remarks/>
        public string vipTargetId
        {
            get
            {
                return this.vipTargetIdField;
            }
            set
            {
                this.vipTargetIdField = value;
            }
        }

        /// <remarks/>
        public string vipTargetName
        {
            get
            {
                return this.vipTargetNameField;
            }
            set
            {
                this.vipTargetNameField = value;
            }
        }

        /// <remarks/>
        public string replyToIcmp
        {
            get
            {
                return this.replyToIcmpField;
            }
            set
            {
                this.replyToIcmpField = value;
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