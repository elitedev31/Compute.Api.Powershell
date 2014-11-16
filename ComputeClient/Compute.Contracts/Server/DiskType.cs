namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class DiskType {
    
        private string idField;
    
        private string scsiIdField;
    
        private int diskSizeGbField;
    
        private string stateField;
    
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
        public string scsiId {
            get {
                return this.scsiIdField;
            }
            set {
                this.scsiIdField = value;
            }
        }
    
        /// <remarks/>
        public int diskSizeGb {
            get {
                return this.diskSizeGbField;
            }
            set {
                this.diskSizeGbField = value;
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
    }
}