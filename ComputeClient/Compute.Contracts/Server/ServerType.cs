namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("Server", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class ServerType {
    
        private string idField;
    
        private string resourcePathField;
    
        private string nameField;
    
        private string descriptionField;
    
        private string vlanResourcePathField;
    
        private string imageResourcePathField;
    
        private OperatingSystemType operatingSystemField;
    
        private int cpuCountField;
    
        private bool cpuCountFieldSpecified;
    
        private int memoryField;
    
        private bool memoryFieldSpecified;
    
        private int osStorageField;
    
        private bool osStorageFieldSpecified;
    
        private int additionalLocalStorageField;
    
        private bool additionalLocalStorageFieldSpecified;
    
        private string machineNameField;
    
        private string administratorPasswordField;
    
        private string privateIPAddressField;
    
        private bool isDeployedField;
    
        private bool isStartedField;
    
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
        public string vlanResourcePath {
            get {
                return this.vlanResourcePathField;
            }
            set {
                this.vlanResourcePathField = value;
            }
        }
    
        /// <remarks/>
        public string imageResourcePath {
            get {
                return this.imageResourcePathField;
            }
            set {
                this.imageResourcePathField = value;
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
        public int cpuCount {
            get {
                return this.cpuCountField;
            }
            set {
                this.cpuCountField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool cpuCountSpecified {
            get {
                return this.cpuCountFieldSpecified;
            }
            set {
                this.cpuCountFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool memorySpecified {
            get {
                return this.memoryFieldSpecified;
            }
            set {
                this.memoryFieldSpecified = value;
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
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool osStorageSpecified {
            get {
                return this.osStorageFieldSpecified;
            }
            set {
                this.osStorageFieldSpecified = value;
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
        public string machineName {
            get {
                return this.machineNameField;
            }
            set {
                this.machineNameField = value;
            }
        }
    
        /// <remarks/>
        public string administratorPassword {
            get {
                return this.administratorPasswordField;
            }
            set {
                this.administratorPasswordField = value;
            }
        }
    
        /// <remarks/>
        public string privateIPAddress {
            get {
                return this.privateIPAddressField;
            }
            set {
                this.privateIPAddressField = value;
            }
        }
    
        /// <remarks/>
        public bool isDeployed {
            get {
                return this.isDeployedField;
            }
            set {
                this.isDeployedField = value;
            }
        }
    
        /// <remarks/>
        public bool isStarted {
            get {
                return this.isStartedField;
            }
            set {
                this.isStartedField = value;
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