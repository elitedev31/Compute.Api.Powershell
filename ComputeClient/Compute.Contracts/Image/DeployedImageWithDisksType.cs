using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Api.Contracts.Image
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.18020")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://oec.api.opsource.net/schemas/server")]
    [System.Xml.Serialization.XmlRootAttribute("DeployedImageWithDisks", Namespace="http://oec.api.opsource.net/schemas/server", IsNullable=false)]
    public partial class DeployedImageWithDisksType : DeployedImageWithSoftwareLabelsType {
    
        private DiskType[] additionalDiskField;
    
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("additionalDisk")]
        public DiskType[] additionalDisk {
            get {
                return this.additionalDiskField;
            }
            set {
                this.additionalDiskField = value;
            }
        }
    }
}