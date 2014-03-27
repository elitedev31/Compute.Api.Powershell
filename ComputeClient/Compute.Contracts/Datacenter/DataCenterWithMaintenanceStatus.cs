namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DataCenterWithMaintenanceStatus
    {

        private string displayNameField;

        private string cityField;

        private string stateField;

        private string countryField;

        private string vpnUrlField;

        private DatacentersWithMaintenanceStatusDatacenterNetworking networkingField;

        private DatacentersWithMaintenanceStatusDatacenterHypervisor hypervisorField;

        private string locationField;

        private string defaultField;

        /// <remarks/>
        public string displayName
        {
            get
            {
                return this.displayNameField;
            }
            set
            {
                this.displayNameField = value;
            }
        }

        /// <remarks/>
        public string city
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
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

        /// <remarks/>
        public string country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        public string vpnUrl
        {
            get
            {
                return this.vpnUrlField;
            }
            set
            {
                this.vpnUrlField = value;
            }
        }

        /// <remarks/>
        public DatacentersWithMaintenanceStatusDatacenterNetworking networking
        {
            get
            {
                return this.networkingField;
            }
            set
            {
                this.networkingField = value;
            }
        }

        /// <remarks/>
        public DatacentersWithMaintenanceStatusDatacenterHypervisor hypervisor
        {
            get
            {
                return this.hypervisorField;
            }
            set
            {
                this.hypervisorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string location
        {
            get
            {
                return this.locationField;
            }
            set
            {
                this.locationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string @default
        {
            get
            {
                return this.defaultField;
            }
            set
            {
                this.defaultField = value;
            }
        }
    }
}