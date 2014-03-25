using System;
using System.Collections.Generic;

namespace DD.CBU.Compute.Api.Contracts.Directory
{
	/// <summary>
	///		Provides read-only access to information about a CaaS account.
	/// </summary>
	public interface IAccount
	{
		/// <summary>
		///		The user login name associated with the account.
		/// </summary>
		string UserName
		{
			get;
		}

		/// <summary>
		///		The full name of the user associated with the account.
		/// </summary>
		string FullName
		{
			get;
		}

		/// <summary>
		///		The first name of the user associated with the account.
		/// </summary>
		string FirstName
		{
			get;
		}

		/// <summary>
		///		The last name of the user associated with the account.
		/// </summary>
		string LastName
		{
			get;
		}

		/// <summary>
		///		The e-mail address of the user associated with the account.
		/// </summary>
		string EmailAddress
		{
			get;
		}

		/// <summary>
		///		The name of the department to which the account's user belongs.
		/// </summary>
		string Department
		{
			get;
		}

		/// <summary>
		///		Custom field 1.
		/// </summary>
		string CustomDefined1
		{
			get;
		}

		/// <summary>
		///		Custom field 2.
		/// </summary>
		string CustomDefined2
		{
			get;
		}

		/// <summary>
		///		The Id of the organisation to which the account belongs.
		/// </summary>
		Guid OrganizationId
		{
			get;
		}

		/// <summary>
		///		Roles (if any) to which the account belongs.
		/// </summary>
		IReadOnlyList<IRole> MemberOfRoles
		{
			get;
		}
	}
}
