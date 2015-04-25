// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasAccountCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Add CaaS Account Cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Directory;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The Add CaaS Account Cmdlet.
	/// </summary>
	/// <remarks>
	/// Add new sub administrator account
	/// </remarks>
	[Cmdlet(VerbsCommon.New, "CaasAccount")]
	public class NewCaasAccountCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the username.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The account username.")]
		[ValidateLength(1, 32)]
		public string Username { get; set; }

		/// <summary>
		/// Gets or sets the full name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The account full name")]
		public string FullName { get; set; }


		/// <summary>
		/// Gets or sets the first name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The account first name")]
		public string FirstName { get; set; }


		/// <summary>
		/// Gets or sets the last name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The account last name")]
		public string LastName { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The account password")]
		public SecureString Password { get; set; }

		/// <summary>
		/// Gets or sets the email address.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The account email address")]
		public string EmailAddress { get; set; }


		/// <summary>
		/// Gets or sets the department.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The account department")]
		public string Department { get; set; }

		/// <summary>
		/// Gets or sets the phone country code.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The account phone country code address")]
		public string PhoneCountryCode { get; set; }

		/// <summary>
		/// Gets or sets the phone number.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The account phone number")]
		public string PhoneNumber { get; set; }


		/// <summary>
		/// Gets or sets the custom defined 1.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The account custom defined field 1")]
		public string CustomDefined1 { get; set; }

		/// <summary>
		/// Gets or sets the custom defined 2.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The account custom defined field 2")]
		public string CustomDefined2 { get; set; }

		/// <summary>
		/// Gets or sets the roles.
		/// </summary>
		[Parameter(Mandatory = false, ValueFromPipeline = true, 
			HelpMessage = "The roles for this account, use the cmdlet New-CaasAccountRoles to create the values")]
		public Role[] Roles { get; set; }


		/// <summary>
		/// Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				Status status = CreateAccount();
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						if (e is ComputeApiException)
						{
							WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
						}
						else
						{
// if (e is HttpRequestException)
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}

		/// <summary>
		/// The create account.
		/// </summary>
		/// <returns>
		/// The <see cref="Status"/>.
		/// </returns>
		private Status CreateAccount()
		{
			var roles = new List<Role>();
			roles.AddRange(Roles);

			var account = new AccountWithPhoneNumber
			{
				orgId = Connection.Account.OrganizationId.ToString(), 
				userName = Username, 
				password = Password.ToPlainString(), 
				fullName = FullName, 
				firstName = FirstName, 
				lastName = LastName, 
				emailAddress = EmailAddress, 
				department = Department, 
				phoneCountryCode = PhoneCountryCode, 
				phoneNumber = PhoneNumber, 
				customDefined1 = CustomDefined1, 
				customDefined2 = CustomDefined2, 
				MemberOfRoles = roles
			};


			Status status = Connection.ApiClient.AddSubAdministratorAccount(account).Result;
			if (status != null)
				WriteDebug(
					string.Format(
						"{0} resulted in {1} ({2}): {3}", 
						status.operation, 
						status.result, 
						status.resultCode, 
						status.resultDetail));

			return status;
		}
	}
}