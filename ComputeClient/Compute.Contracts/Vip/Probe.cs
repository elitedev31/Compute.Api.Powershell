namespace DD.CBU.Compute.Api.Contracts.Vip
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    public partial class Probe
    {

        private string idField;

        private string nameField;

        private ProbeType typeField;

        private int probeIntervalSecondsField;

        private int errorCountBeforeServerFailField;

        private int successCountBeforeServerEnableField;

        private int failedProbeIntervalSecondsField;

        private int maxReplyWaitSecondsField;

        private ProbeRequestMethod requestMethodField;

        private int portField;

        private string requestUrlField;

        private string matchContentField;

        private ProbeStatusCodeRange[] statusCodeRangeField;

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
        public ProbeType type
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
        public int probeIntervalSeconds
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
        public int errorCountBeforeServerFail
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
        public int successCountBeforeServerEnable
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
        public int failedProbeIntervalSeconds
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
        public int maxReplyWaitSeconds
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

        /// <remarks/>
        public ProbeRequestMethod requestMethod
        {
            get
            {
                return this.requestMethodField;
            }
            set
            {
                this.requestMethodField = value;
            }
        }

        /// <remarks/>
        public int port
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
        public string requestUrl
        {
            get
            {
                return this.requestUrlField;
            }
            set
            {
                this.requestUrlField = value;
            }
        }

        /// <remarks/>
        public string matchContent
        {
            get
            {
                return this.matchContentField;
            }
            set
            {
                this.matchContentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("statusCodeRange")]
        public ProbeStatusCodeRange[] statusCodeRange
        {
            get
            {
                return this.statusCodeRangeField;
            }
            set
            {
                this.statusCodeRangeField = value;
            }
        }



    }
}