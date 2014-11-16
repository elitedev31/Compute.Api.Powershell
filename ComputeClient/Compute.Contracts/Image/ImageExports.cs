namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class ImageExports {
    
        private ImageExportType[] imageExportField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("imageExport")]
        public ImageExportType[] imageExport {
            get {
                return this.imageExportField;
            }
            set {
                this.imageExportField = value;
            }
        }
    }
}