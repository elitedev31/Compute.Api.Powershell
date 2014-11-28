using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Contracts.Vip
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/vip")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://oec.api.opsource.net/schemas/vip", IsNullable = false)]
    public partial class NewPersistenceProfile
    {

        private string nameField;

        private string serverFarmIdField;

        private string timeoutMinutesField;

        private PersistenceProfileType typeField;

        private string directionField;

        private string netmaskField;

        private string cookieNameField;

        private string cookieTypeField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string serverFarmId
        {
            get
            {
                return this.serverFarmIdField;
            }
            set
            {
                this.serverFarmIdField = value;
            }
        }

        /// <remarks/>
        public string timeoutMinutes
        {
            get
            {
                return this.timeoutMinutesField;
            }
            set
            {
                this.timeoutMinutesField = value;
            }
        }

        /// <remarks/>
        public PersistenceProfileType type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
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

        /// <remarks/>
        public string cookieName
        {
            get
            {
                return this.cookieNameField;
            }
            set
            {
                this.cookieNameField = value;
            }
        }

        /// <remarks/>
        public string cookieType
        {
            get
            {
                return this.cookieTypeField;
            }
            set
            {
                this.cookieTypeField = value;
            }
        }
    }

}
