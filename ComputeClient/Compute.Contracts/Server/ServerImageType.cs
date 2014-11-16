namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("ServerImage", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class ServerImageType {
    
        private string idField;
    
        private string resourcePathField;
    
        private string nameField;
    
        private string descriptionField;
    
        private OperatingSystemType operatingSystemField;
    
        private string locationField;
    
        private string sourceResourcePathField;
    
        private int cpuCountField;
    
        private int memoryField;
    
        private int osStorageField;
    
        private int additionalLocalStorageField;
    
        private bool additionalLocalStorageFieldSpecified;
    
        private System.DateTime createdField;
    
        private bool createdFieldSpecified;
    
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
        public string resourcePath {
            get {
                return this.resourcePathField;
            }
            set {
                this.resourcePathField = value;
            }
        }
    
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
        public OperatingSystemType operatingSystem {
            get {
                return this.operatingSystemField;
            }
            set {
                this.operatingSystemField = value;
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
        public string sourceResourcePath {
            get {
                return this.sourceResourcePathField;
            }
            set {
                this.sourceResourcePathField = value;
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
        public int memory {
            get {
                return this.memoryField;
            }
            set {
                this.memoryField = value;
            }
        }
    
        /// <remarks/>
        public int osStorage {
            get {
                return this.osStorageField;
            }
            set {
                this.osStorageField = value;
            }
        }
    
        /// <remarks/>
        public int additionalLocalStorage {
            get {
                return this.additionalLocalStorageField;
            }
            set {
                this.additionalLocalStorageField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool additionalLocalStorageSpecified {
            get {
                return this.additionalLocalStorageFieldSpecified;
            }
            set {
                this.additionalLocalStorageFieldSpecified = value;
            }
        }
    
        /// <remarks/>
        public System.DateTime created {
            get {
                return this.createdField;
            }
            set {
                this.createdField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool createdSpecified {
            get {
                return this.createdFieldSpecified;
            }
            set {
                this.createdFieldSpecified = value;
            }
        }
    }
}