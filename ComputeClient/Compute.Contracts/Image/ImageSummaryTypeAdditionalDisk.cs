namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class ImageSummaryTypeAdditionalDisk {
    
        private int scsiIdField;
    
        private int sizeGbField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int scsiId {
            get {
                return this.scsiIdField;
            }
            set {
                this.scsiIdField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int sizeGb {
            get {
                return this.sizeGbField;
            }
            set {
                this.sizeGbField = value;
            }
        }
    }
}