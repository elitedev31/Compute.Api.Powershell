namespace DD.CBU.Compute.Api.Contracts.Server
{
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(PendingDeployServerWithDisksType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("PendingDeployServerWithSoftwareLabels", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class PendingDeployServerWithSoftwareLabelsType {
    
        private string idField;
    
        private string nameField;
    
        private string descriptionField;
    
        private MachineSpecificationType machineSpecificationField;
    
        private string sourceImageIdField;
    
        private string networkIdField;
    
        private string privateIpAddressField;
    
        private ProgressStatusType statusField;
    
        private string[] softwareLabelField;
    
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
        public MachineSpecificationType machineSpecification {
            get {
                return this.machineSpecificationField;
            }
            set {
                this.machineSpecificationField = value;
            }
        }
    
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
        public string networkId {
            get {
                return this.networkIdField;
            }
            set {
                this.networkIdField = value;
            }
        }
    
        /// <remarks/>
        public string privateIpAddress {
            get {
                return this.privateIpAddressField;
            }
            set {
                this.privateIpAddressField = value;
            }
        }
    
        /// <remarks/>
        public ProgressStatusType status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("softwareLabel")]
        public string[] softwareLabel {
            get {
                return this.softwareLabelField;
            }
            set {
                this.softwareLabelField = value;
            }
        }
    }
}