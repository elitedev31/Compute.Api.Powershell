namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute("NetworkConfiguration", Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class NetworkConfigurationType {
    
        private NetworkType networkField;
    
        private string hostNameField;
    
        private int aggField;
    
        private bool aggFieldSpecified;
    
        private string locationField;
    
        private int contextField;
    
        private bool contextFieldSpecified;
    
        private int acePairField;
    
        private bool acePairFieldSpecified;
    
        private int intVlanField;
    
        private bool intVlanFieldSpecified;
    
        private int outVlanField;
    
        private bool outVlanFieldSpecified;
    
        private string publicSnatField;
    
        private string privateSnatField;
    
        private string publicNetField;
    
        private string privateNetField;
    
        private IpBlockType[] publicIpsField;
    
        private Ips privateIpsField;
    
        /// <remarks/>
        public NetworkType network {
            get {
                return this.networkField;
            }
            set {
                this.networkField = value;
            }
        }
    
        /// <remarks/>
        public string hostName {
            get {
                return this.hostNameField;
            }
            set {
                this.hostNameField = value;
            }
        }
    
        /// <remarks/>
        public int agg {
            get {
                return this.aggField;
            }
            set {
                this.aggField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool aggSpecified {
            get {
                return this.aggFieldSpecified;
            }
            set {
                this.aggFieldSpecified = value;
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
        public int context {
            get {
                return this.contextField;
            }
            set {
                this.contextField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool contextSpecified {
            get {
                return this.contextFieldSpecified;
            }
            set {
                this.contextFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public int acePair {
            get {
                return this.acePairField;
            }
            set {
                this.acePairField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool acePairSpecified {
            get {
                return this.acePairFieldSpecified;
            }
            set {
                this.acePairFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public int intVlan {
            get {
                return this.intVlanField;
            }
            set {
                this.intVlanField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool intVlanSpecified {
            get {
                return this.intVlanFieldSpecified;
            }
            set {
                this.intVlanFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public int outVlan {
            get {
                return this.outVlanField;
            }
            set {
                this.outVlanField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool outVlanSpecified {
            get {
                return this.outVlanFieldSpecified;
            }
            set {
                this.outVlanFieldSpecified = value;
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
        public string privateSnat {
            get {
                return this.privateSnatField;
            }
            set {
                this.privateSnatField = value;
            }
        }
    
        /// <remarks/>
        public string publicNet {
            get {
                return this.publicNetField;
            }
            set {
                this.publicNetField = value;
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