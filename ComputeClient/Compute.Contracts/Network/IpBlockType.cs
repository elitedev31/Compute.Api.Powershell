namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute("IpBlock", Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class IpBlockType {
    
        private string idField;
    
        private string baseIpField;
    
        private int subnetSizeField;
    
        private bool networkDefaultField;
    
        private bool serverToVipConnectivityField;
    
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
        public string baseIp {
            get {
                return this.baseIpField;
            }
            set {
                this.baseIpField = value;
            }
        }
    
        /// <remarks/>
        public int subnetSize {
            get {
                return this.subnetSizeField;
            }
            set {
                this.subnetSizeField = value;
            }
        }
    
        /// <remarks/>
        public bool networkDefault {
            get {
                return this.networkDefaultField;
            }
            set {
                this.networkDefaultField = value;
            }
        }
    
        /// <remarks/>
        public bool serverToVipConnectivity {
            get {
                return this.serverToVipConnectivityField;
            }
            set {
                this.serverToVipConnectivityField = value;
            }
        }
    }
}