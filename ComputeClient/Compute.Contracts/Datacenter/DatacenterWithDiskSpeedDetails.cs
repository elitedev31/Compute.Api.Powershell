namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/datacenter")]
    public partial class DatacenterWithDiskSpeedDetails {
    
        private string displayNameField;
    
        private string cityField;
    
        private string stateField;
    
        private string countryField;
    
        private string vpnUrlField;
    
        private int maxCpuField;
    
        private int maxRamMbField;
    
        private DiskSpeedAvailabilityType[] diskSpeedField;
    
        private string locationField;
    
        private bool defaultField;
    
        /// <remarks/>
        public string displayName {
            get {
                return this.displayNameField;
            }
            set {
                this.displayNameField = value;
            }
        }
    
        /// <remarks/>
        public string city {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
    
        /// <remarks/>
        public string state {
            get {
                return this.stateField;
            }
            set {
                this.stateField = value;
            }
        }
    
        /// <remarks/>
        public string country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
    
        /// <remarks/>
        public string vpnUrl {
            get {
                return this.vpnUrlField;
            }
            set {
                this.vpnUrlField = value;
            }
        }
    
        /// <remarks/>
        public int maxCpu {
            get {
                return this.maxCpuField;
            }
            set {
                this.maxCpuField = value;
            }
        }
    
        /// <remarks/>
        public int maxRamMb {
            get {
                return this.maxRamMbField;
            }
            set {
                this.maxRamMbField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("diskSpeed")]
        public DiskSpeedAvailabilityType[] diskSpeed {
            get {
                return this.diskSpeedField;
            }
            set {
                this.diskSpeedField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form=System.Xml.Schema.XmlSchemaForm.Qualified)]
        public bool @default {
            get {
                return this.defaultField;
            }
            set {
                this.defaultField = value;
            }
        }
    }
}