namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    public partial class MachineSpecificationType {
    
        private int cpuCountField;
    
        private int memoryMbField;
    
        private int osStorageGbField;
    
        private int additionalLocalStorageGbField;
    
        private global::DD.CBU.Compute.Api.Contracts.Server.OperatingSystemType operatingSystemField;
    
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
        public int additionalLocalStorageGb {
            get {
                return this.additionalLocalStorageGbField;
            }
            set {
                this.additionalLocalStorageGbField = value;
            }
        }
    
        /// <remarks/>
        public global::DD.CBU.Compute.Api.Contracts.Server.OperatingSystemType operatingSystem {
            get {
                return this.operatingSystemField;
            }
            set {
                this.operatingSystemField = value;
            }
        }
    }
}