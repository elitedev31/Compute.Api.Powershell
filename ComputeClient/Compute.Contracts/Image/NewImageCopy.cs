namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class NewImageCopy {
    
        private string sourceImageIdField;
    
        private string targetImageNameField;
    
        private string targetImageDescriptionField;
    
        private string targetLocationField;
    
        private string ovfPackagePrefixField;
    
        /// <remarks/>
        public string sourceImageId {
            get {
                return this.sourceImageIdField;
            }
            set {
                this.sourceImageIdField = value;
            }
        }
    
        /// <remarks/>
        public string targetImageName {
            get {
                return this.targetImageNameField;
            }
            set {
                this.targetImageNameField = value;
            }
        }
    
        /// <remarks/>
        public string targetImageDescription {
            get {
                return this.targetImageDescriptionField;
            }
            set {
                this.targetImageDescriptionField = value;
            }
        }
    
        /// <remarks/>
        public string targetLocation {
            get {
                return this.targetLocationField;
            }
            set {
                this.targetLocationField = value;
            }
        }
    
        /// <remarks/>
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