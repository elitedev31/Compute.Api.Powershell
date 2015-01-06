using System.Collections.Generic;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Directory
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://oec.api.opsource.net/schemas/directory")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://oec.api.opsource.net/schemas/directory", IsNullable = false)]
    public partial class AccountWithPhoneNumber
    {

        private string userNameField;

        private string fullNameField;

        private string firstNameField;

        private string lastNameField;

        private string passwordField;

        private string emailAddressField;

        private string phoneCountryCodeField;

        private string phoneNumberField;

        private string departmentField;

        private string customDefined1Field;

        private string customDefined2Field;

        private string orgIdField;

        private List<Role> _memberOfRoles = new List<Role>();

        /// <remarks/>
        public string userName
        {
            get
            {
                return this.userNameField;
            }
            set
            {
                this.userNameField = value;
            }
        }

        /// <remarks/>
        public string fullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }

        /// <remarks/>
        public string firstName
        {
            get
            {
                return this.firstNameField;
            }
            set
            {
                this.firstNameField = value;
            }
        }

        /// <remarks/>
        public string lastName
        {
            get
            {
                return this.lastNameField;
            }
            set
            {
                this.lastNameField = value;
            }
        }


        /// <remarks/>
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        public string emailAddress
        {
            get
            {
                return this.emailAddressField;
            }
            set
            {
                this.emailAddressField = value;
            }
        }

        /// <remarks/>
        public string phoneCountryCode
        {
            get
            {
                return this.phoneCountryCodeField;
            }
            set
            {
                this.phoneCountryCodeField = value;
            }
        }

        /// <remarks/>
        public string phoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }

        /// <remarks/>
        public string department
        {
            get
            {
                return this.departmentField;
            }
            set
            {
                this.departmentField = value;
            }
        }

        /// <remarks/>
        public string customDefined1
        {
            get
            {
                return this.customDefined1Field;
            }
            set
            {
                this.customDefined1Field = value;
            }
        }

        /// <remarks/>
        public string customDefined2
        {
            get
            {
                return this.customDefined2Field;
            }
            set
            {
                this.customDefined2Field = value;
            }
        }

        /// <remarks/>
        public string orgId
        {
            get
            {
                return this.orgIdField;
            }
            set
            {
                this.orgIdField = value;
            }
        }

        /// <summary>
        ///		Roles (if any) to which the account belongs.
        /// </summary>
        [XmlArray("roles", Namespace = XmlNamespaceConstants.Directory)]
        [XmlArrayItem("role", Namespace = XmlNamespaceConstants.Directory)]
        public List<Role> MemberOfRoles
        {
            get
            {
                return _memberOfRoles;
            }

            set { this._memberOfRoles = value; }
        }
    }
}