namespace DD.CBU.Compute.Api.Contracts.General
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/general")]
    [System.Xml.Serialization.XmlRootAttribute("Status", Namespace="http://oec.api.opsource.net/schemas/general", IsNullable=false)]
    public partial class StatusType {
    
        private string operationField;
    
        private ResultType resultField;
    
        private string resultDetailField;
    
        private string resultCodeField;
    
        private AdditionalInformationType[] additionalInformationField;
    
        /// <remarks/>
        public string operation {
            get {
                return this.operationField;
            }
            set {
                this.operationField = value;
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
        [System.Xml.Serialization.XmlElementAttribute("additionalInformation")]
        public AdditionalInformationType[] additionalInformation {
            get {
                return this.additionalInformationField;
            }
            set {
                this.additionalInformationField = value;
            }
        }
    }
}