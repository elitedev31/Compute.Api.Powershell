namespace DD.CBU.Compute.Api.Contracts.Vip
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    public partial class ProbesProbe
    {

        private string idField;

        private string nameField;

        private string typeField;

        private string probeIntervalSecondsField;

        private string errorCountBeforeServerFailField;

        private string successCountBeforeServerEnableField;

        private string failedProbeIntervalSecondsField;

        private string maxReplyWaitSecondsField;

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
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string probeIntervalSeconds
        {
            get
            {
                return this.probeIntervalSecondsField;
            }
            set
            {
                this.probeIntervalSecondsField = value;
            }
        }

        /// <remarks/>
        public string errorCountBeforeServerFail
        {
            get
            {
                return this.errorCountBeforeServerFailField;
            }
            set
            {
                this.errorCountBeforeServerFailField = value;
            }
        }

        /// <remarks/>
        public string successCountBeforeServerEnable
        {
            get
            {
                return this.successCountBeforeServerEnableField;
            }
            set
            {
                this.successCountBeforeServerEnableField = value;
            }
        }

        /// <remarks/>
        public string failedProbeIntervalSeconds
        {
            get
            {
                return this.failedProbeIntervalSecondsField;
            }
            set
            {
                this.failedProbeIntervalSecondsField = value;
            }
        }

        /// <remarks/>
        public string maxReplyWaitSeconds
        {
            get
            {
                return this.maxReplyWaitSecondsField;
            }
            set
            {
                this.maxReplyWaitSecondsField = value;
            }
        }
    }
}