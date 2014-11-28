namespace DD.CBU.Compute.Api.Contracts.Vip
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true,
        Namespace = "http://oec.api.opsource.net/schemas/vip")]
    public partial class PersistenceProfile
    {

        private string idField;

        private string stateField;

        private string nameField;

        private string serverFarmIdField;

        private string serverFarmNameField;

        private string timeoutField;

        private PersistenceProfileType typeField;

        private string cookieNameField;

        private string cookieTypeField;

        private string directionField;

        private string netmaskField;

        /// <remarks/>
        public string id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        public string state
        {
            get { return this.stateField; }
            set { this.stateField = value; }
        }

        /// <remarks/>
        public string name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        public string serverFarmId
        {
            get { return this.serverFarmIdField; }
            set { this.serverFarmIdField = value; }
        }

        /// <remarks/>
        public string serverFarmName
        {
            get { return this.serverFarmNameField; }
            set { this.serverFarmNameField = value; }
        }

        /// <remarks/>
        public string timeout
        {
            get { return this.timeoutField; }
            set { this.timeoutField = value; }
        }

        /// <remarks/>
        public PersistenceProfileType type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        public string cookieName
        {
            get { return this.cookieNameField; }
            set { this.cookieNameField = value; }
        }

        /// <remarks/>
        public string cookieType
        {
            get { return this.cookieTypeField; }
            set { this.cookieTypeField = value; }
        }

        /// <remarks/>
        public string direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }

        /// <remarks/>
        public string netmask
        {
            get
            {
                return this.netmaskField;
            }
            set
            {
                this.netmaskField = value;
            }
        }
    }
}