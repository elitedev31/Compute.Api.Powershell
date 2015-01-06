using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Directory
{
	/// <summary>
	///		Represents a role in the CaaS API.
	/// </summary>
	[XmlRoot("Role", Namespace = XmlNamespaceConstants.Directory)]
	public class Role
		: IRole
	{
		/// <summary>
		///		Create a new CaaS role data-contract.
		/// </summary>
		public Role()
		{
		}

        /// <summary>
        ///		Create a new CaaS role data-contract using the helper enum
        /// </summary>
        public Role(RoleType name)
        {
            this.Name = name.ToString().ToLower().Replace("_", " ");
        }

		/// <summary>
		///		The name of the CaaS role.
		/// </summary>
		[XmlElement("name", Namespace = XmlNamespaceConstants.Directory)]
		public string Name
		{
			get;
			set;
		}
	}
}
