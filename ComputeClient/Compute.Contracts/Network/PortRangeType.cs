namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    public partial class PortRangeType {
    
        private PortRangeTypeType typeField;
    
        private int port1Field;
    
        private bool port1FieldSpecified;
    
        private int port2Field;
    
        private bool port2FieldSpecified;
    
        /// <remarks/>
        public PortRangeTypeType type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
    
        /// <remarks/>
        public int port1 {
            get {
                return this.port1Field;
            }
            set {
                this.port1Field = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool port1Specified {
            get {
                return this.port1FieldSpecified;
            }
            set {
                this.port1FieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public int port2 {
            get {
                return this.port2Field;
            }
            set {
                this.port2Field = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool port2Specified {
            get {
                return this.port2FieldSpecified;
            }
            set {
                this.port2FieldSpecified = value;
            }
        }
    }
}