using DD.CBU.Compute.Api.Contracts.Backup;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Api.Contracts.Datacenter
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/datacenter")]
    public partial class DatacenterWithMaintenanceStatusType {
    
        private string displayNameField;
    
        private string cityField;
    
        private string stateField;
    
        private string countryField;
    
        private string vpnUrlField;
    
        private NetworkingType networkingField;
    
        private HypervisorType hypervisorField;
    
        private BackupType backupField;
    
        private bool defaultField;
    
        private string locationField;
    
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
        public NetworkingType networking {
            get {
                return this.networkingField;
            }
            set {
                this.networkingField = value;
            }
        }
    
        /// <remarks/>
        public HypervisorType hypervisor {
            get {
                return this.hypervisorField;
            }
            set {
                this.hypervisorField = value;
            }
        }
    
        /// <remarks/>
        public BackupType backup {
            get {
                return this.backupField;
            }
            set {
                this.backupField = value;
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
    }
}