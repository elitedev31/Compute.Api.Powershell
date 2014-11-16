using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("ImageCopy", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class ImageCopyType {
    
        private ServerImageWithStateType targetImageField;
    
        private string imageCopyIdField;
    
        private string sourceLocationField;
    
        private string sourceImageIdField;
    
        private string sourceImageNameField;
    
        private string ovfPackagePrefixField;
    
        /// <remarks/>
        public ServerImageWithStateType targetImage {
            get {
                return this.targetImageField;
            }
            set {
                this.targetImageField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string imageCopyId {
            get {
                return this.imageCopyIdField;
            }
            set {
                this.imageCopyIdField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sourceLocation {
            get {
                return this.sourceLocationField;
            }
            set {
                this.sourceLocationField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sourceImageId {
            get {
                return this.sourceImageIdField;
            }
            set {
                this.sourceImageIdField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string sourceImageName {
            get {
                return this.sourceImageNameField;
            }
            set {
                this.sourceImageNameField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ovfPackagePrefix {
            get {
                return this.ovfPackagePrefixField;
            }
            set {
                this.ovfPackagePrefixField = value;
            }
        }
    }
}