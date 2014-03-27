namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = XmlNamespaceConstants.MultiGeo)]
    public partial class Region
    {

        private string idField;

        private string nameField;

        private string cloudUiUrlField;

        private string cloudApiUrlField;

        private string isHomeField;

        private string productKeyField;

        private string pricingUrlField;

        private string stateField;

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
        public string cloudUiUrl
        {
            get
            {
                return this.cloudUiUrlField;
            }
            set
            {
                this.cloudUiUrlField = value;
            }
        }

        /// <remarks/>
        public string cloudApiUrl
        {
            get
            {
                return this.cloudApiUrlField;
            }
            set
            {
                this.cloudApiUrlField = value;
            }
        }

        /// <remarks/>
        public string isHome
        {
            get
            {
                return this.isHomeField;
            }
            set
            {
                this.isHomeField = value;
            }
        }

        /// <remarks/>
        public string productKey
        {
            get
            {
                return this.productKeyField;
            }
            set
            {
                this.productKeyField = value;
            }
        }

        /// <remarks/>
        public string pricingUrl
        {
            get
            {
                return this.pricingUrlField;
            }
            set
            {
                this.pricingUrlField = value;
            }
        }

        /// <remarks/>
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
    }
}