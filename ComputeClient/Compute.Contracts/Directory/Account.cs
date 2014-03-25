using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Directory
{
	/// <summary>
	///		Represents a CaaS user account.
	/// </summary>
	[XmlRoot("Account", Namespace = XmlNamespaceConstants.Directory)]
	public class Account
		: IAccount
	{
		/// <summary>
		///		Roles (if any) to which the account belongs.
		/// </summary>
		readonly List<Role> _memberOfRoles = new List<Role>();

		/// <summary>
		///		Create a new CaaS user account data-contract.
		/// </summary>
		public Account()
		{
		}

		/// <summary>
		///		The user login name associated with the account.
		/// </summary>
		[XmlElement("userName", Namespace = XmlNamespaceConstants.Directory)]
		public string UserName
		{
			get;
			set;
		}

		/// <summary>
		///		The full name of the user associated with the account.
		/// </summary>
		[XmlElement("fullName", Namespace = XmlNamespaceConstants.Directory)]
		public string FullName
		{
			get;
			set;
		}

		/// <summary>
		///		The first name of the user associated with the account.
		/// </summary>
		[XmlElement("firstName", Namespace = XmlNamespaceConstants.Directory)]
		public string FirstName
		{
			get;
			set;
		}

		/// <summary>
		///		The last name of the user associated with the account.
		/// </summary>
		[XmlElement("lastName", Namespace = XmlNamespaceConstants.Directory)]
		public string LastName
		{
			get;
			set;
		}

		/// <summary>
		///		The e-mail address of the user associated with the account.
		/// </summary>
		[XmlElement("emailAddress", Namespace = XmlNamespaceConstants.Directory)]
		public string EmailAddress
		{
			get;
			set;
		}

		/// <summary>
		///		The name of the department to which the account's user belongs.
		/// </summary>
		[XmlElement("department", Namespace = XmlNamespaceConstants.Directory)]
		public string Department
		{
			get;
			set;
		}

		/// <summary>
		///		Custom field 1.
		/// </summary>
		[XmlElement("customDefined1", Namespace = XmlNamespaceConstants.Directory)]
		public string CustomDefined1
		{
			get;
			set;
		}

		/// <summary>
		///		Custom field 2.
		/// </summary>
		[XmlElement("customDefined2", Namespace = XmlNamespaceConstants.Directory)]
		public string CustomDefined2
		{
			get;
			set;
		}

		/// <summary>
		///		The Id of the organisation to which the account belongs.
		/// </summary>
		[XmlElement("orgId", Namespace = XmlNamespaceConstants.Directory)]
		public Guid OrganizationId
		{
			get;
			set;
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
		}

		/// <summary>
		///		Roles (if any) to which the account belongs.
		/// </summary>
		IReadOnlyList<IRole> IAccount.MemberOfRoles
		{
			get
			{
				return MemberOfRoles;
			}
		}
	}
}
