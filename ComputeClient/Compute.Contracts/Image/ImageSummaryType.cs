namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class ImageSummaryType {
    
        private string nameField;
    
        private string descriptionField;
    
        private string locationField;
    
        private string operatingSystemField;
    
        private int cpuCountField;
    
        private int memoryMbField;
    
        private int osStorageGbField;
    
        private ImageSummaryTypeAdditionalDisk[] additionalDiskField;
    
        private string idField;
    
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
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
    
        /// <remarks/>
        public string operatingSystem {
            get {
                return this.operatingSystemField;
            }
            set {
                this.operatingSystemField = value;
            }
        }
    
        /// <remarks/>
        public int cpuCount {
            get {
                return this.cpuCountField;
            }
            set {
                this.cpuCountField = value;
            }
        }
    
        /// <remarks/>
        public int memoryMb {
            get {
                return this.memoryMbField;
            }
            set {
                this.memoryMbField = value;
            }
        }
    
        /// <remarks/>
        public int osStorageGb {
            get {
                return this.osStorageGbField;
            }
            set {
                this.osStorageGbField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("additionalDisk")]
        public ImageSummaryTypeAdditionalDisk[] additionalDisk {
            get {
                return this.additionalDiskField;
            }
            set {
                this.additionalDiskField = value;
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