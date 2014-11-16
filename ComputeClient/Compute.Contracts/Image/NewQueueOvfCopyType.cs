namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class NewQueueOvfCopyType {
    
        private string destinationGeoIdField;
    
        private string sourceOvfPackageField;
    
        /// <remarks/>
        public string destinationGeoId {
            get {
                return this.destinationGeoIdField;
            }
            set {
                this.destinationGeoIdField = value;
            }
        }
    
        /// <remarks/>
        public string sourceOvfPackage {
            get {
                return this.sourceOvfPackageField;
            }
            set {
                this.sourceOvfPackageField = value;
            }
        }
    }
}