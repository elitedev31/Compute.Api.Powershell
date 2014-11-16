namespace DD.CBU.Compute.Api.Contracts.Network
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/network")]
    [System.Xml.Serialization.XmlRootAttribute("Network", Namespace="http://oec.api.opsource.net/schemas/network", IsNullable=false)]
    public partial class NetworkType {
    
        private string idField;
    
        private string resourcePathField;
    
        private string nameField;
    
        private string descriptionField;
    
        private bool multicastField;
    
        private bool multicastFieldSpecified;
    
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
        public string resourcePath {
            get {
                return this.resourcePathField;
            }
            set {
                this.resourcePathField = value;
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
        public bool multicast {
            get {
                return this.multicastField;
            }
            set {
                this.multicastField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool multicastSpecified {
            get {
                return this.multicastFieldSpecified;
            }
            set {
                this.multicastFieldSpecified = value;
            }
        }
    }
}