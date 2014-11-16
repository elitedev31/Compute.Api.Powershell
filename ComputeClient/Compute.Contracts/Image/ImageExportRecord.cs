using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class ImageExportRecord {
    
        private string userNameField;
    
        private ImageSummaryType imageField;
    
        private System.DateTime endDateField;
    
        private ResultType resultField;
    
        private string resultDetailField;
    
        private string resultCodeField;
    
        private OutputFileType[] outputFileField;
    
        private string idField;
    
        private string ovfPackagePrefixField;
    
        private System.DateTime startDateField;
    
        /// <remarks/>
        public string userName {
            get {
                return this.userNameField;
            }
            set {
                this.userNameField = value;
            }
        }
    
        /// <remarks/>
        public ImageSummaryType image {
            get {
                return this.imageField;
            }
            set {
                this.imageField = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime endDate {
            get {
                return this.endDateField;
            }
            set {
                this.endDateField = value;
            }
        }
    
        /// <remarks/>
        public ResultType result {
            get {
                return this.resultField;
            }
            set {
                this.resultField = value;
            }
        }
    
        /// <remarks/>
        public string resultDetail {
            get {
                return this.resultDetailField;
            }
            set {
                this.resultDetailField = value;
            }
        }
    
        /// <remarks/>
        public string resultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("outputFile")]
        public OutputFileType[] outputFile {
            get {
                return this.outputFileField;
            }
            set {
                this.outputFileField = value;
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
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime startDate {
            get {
                return this.startDateField;
            }
            set {
                this.startDateField = value;
            }
        }
    }
}