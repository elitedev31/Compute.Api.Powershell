namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute("NetworkConfigurationWithLocation", Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class NetworkConfigurationWithLocationType {
    
        private string idField;
    
        private string nameField;
    
        private string descriptionField;
    
        private string locationField;
    
        private string privateNetField;
    
        private bool multicastField;
    
        private string privateSnatField;
    
        private string publicSnatField;
    
        private IpBlockType[] publicIpsField;
    
        private Ips privateIpsField;
    
        /// <remarks/>
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    
        /// <remarks/>
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    
        /// <remarks/>
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    
        /// <remarks/>
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
    
        /// <remarks/>
        public string privateNet {
            get {
                return this.privateNetField;
            }
            set {
                this.privateNetField = value;
            }
        }
    
        /// <remarks/>
        public bool multicast {
            get {
                return this.multicastField;
            }
            set {
                this.multicastField = value;
            }
        }
    
        /// <remarks/>
        public string privateSnat {
            get {
                return this.privateSnatField;
            }
            set {
                this.privateSnatField = value;
            }
        }
    
        /// <remarks/>
        public string publicSnat {
            get {
                return this.publicSnatField;
            }
            set {
                this.publicSnatField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("IpBlock", IsNullable=false)]
        public IpBlockType[] publicIps {
            get {
                return this.publicIpsField;
            }
            set {
                this.publicIpsField = value;
            }
        }
    
        /// <remarks/>
        public Ips privateIps {
            get {
                return this.privateIpsField;
            }
            set {
                this.privateIpsField = value;
            }
        }
    }
}