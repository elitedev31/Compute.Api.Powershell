using System;

namespace DD.CBU.Compute.Api.Contracts.Backup
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/backup")]
    public partial class RunningJobType {
    
        private int idField;
    
        private string nameField;
    
        private int percentageCompleteField;
    
        private string statusField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int id {
            get {
                return this.idField;
            }
            set {
				this.idField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int percentageComplete {
            get {
                return this.percentageCompleteField;
            }
            set {
                this.percentageCompleteField = value;
            }
        }
    
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
    }
}