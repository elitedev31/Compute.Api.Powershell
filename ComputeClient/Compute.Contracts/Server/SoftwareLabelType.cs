namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("SoftwareLabel", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class SoftwareLabelType {
    
        private string displayNameField;
    
        private string descriptionField;
    
        private PricedPerType pricedPerField;
    
        private int runningUnitsField;
    
        private int stoppedUnitsField;
    
        private string idField;
    
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
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
    
        /// <remarks/>
        public PricedPerType pricedPer {
            get {
                return this.pricedPerField;
            }
            set {
                this.pricedPerField = value;
            }
        }
    
        /// <remarks/>
        public int runningUnits {
            get {
                return this.runningUnitsField;
            }
            set {
                this.runningUnitsField = value;
            }
        }
    
        /// <remarks/>
        public int stoppedUnits {
            get {
                return this.stoppedUnitsField;
            }
            set {
                this.stoppedUnitsField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
    }
}