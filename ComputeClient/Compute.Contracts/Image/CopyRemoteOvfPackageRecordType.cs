using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class CopyRemoteOvfPackageRecordType {
    
        private OvfPackageFileType mfFileField;
    
        private OvfPackageFileType ovfFileField;
    
        private OvfPackageFileType[] vmdkFileField;
    
        private System.DateTime startDateField;
    
        private System.DateTime endDateField;
    
        private ResultType resultField;
    
        private string resultCodeField;
    
        private string resultDetailField;
    
        private string idField;
    
        private string sourceGeoKeyField;
    
        /// <remarks/>
        public OvfPackageFileType mfFile {
            get {
                return this.mfFileField;
            }
            set {
                this.mfFileField = value;
            }
        }
    
        /// <remarks/>
        public OvfPackageFileType ovfFile {
            get {
                return this.ovfFileField;
            }
            set {
                this.ovfFileField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("vmdkFile")]
        public OvfPackageFileType[] vmdkFile {
            get {
                return this.vmdkFileField;
            }
            set {
                this.vmdkFileField = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime startDate {
            get {
                return this.startDateField;
            }
            set {
                this.startDateField = value;
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
        public string resultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
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
        public string sourceGeoKey {
            get {
                return this.sourceGeoKeyField;
            }
            set {
                this.sourceGeoKeyField = value;
            }
        }
    }
}