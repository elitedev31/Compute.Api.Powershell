namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute("AclRule", Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class AclRuleType {
    
        private string idField;
    
        private string nameField;
    
        private string statusField;
    
        private int positionField;
    
        private AclActionType actionField;
    
        private string protocolField;
    
        private IpRangeType sourceIpRangeField;
    
        private IpRangeType destinationIpRangeField;
    
        private PortRangeType portRangeField;
    
        private AclType typeField;
    
        private bool typeFieldSpecified;
    
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
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    
        /// <remarks/>
        public int position {
            get {
                return this.positionField;
            }
            set {
                this.positionField = value;
            }
        }
    
        /// <remarks/>
        public AclActionType action {
            get {
                return this.actionField;
            }
            set {
                this.actionField = value;
            }
        }
    
        /// <remarks/>
        public string protocol {
            get {
                return this.protocolField;
            }
            set {
                this.protocolField = value;
            }
        }
    
        /// <remarks/>
        public IpRangeType sourceIpRange {
            get {
                return this.sourceIpRangeField;
            }
            set {
                this.sourceIpRangeField = value;
            }
        }
    
        /// <remarks/>
        public IpRangeType destinationIpRange {
            get {
                return this.destinationIpRangeField;
            }
            set {
                this.destinationIpRangeField = value;
            }
        }
    
        /// <remarks/>
        public PortRangeType portRange {
            get {
                return this.portRangeField;
            }
            set {
                this.portRangeField = value;
            }
        }
    
        /// <remarks/>
        public AclType type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified {
            get {
                return this.typeFieldSpecified;
            }
            set {
                this.typeFieldSpecified = value;
            }
        }
    }
}