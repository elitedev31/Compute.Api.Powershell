// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasAccountRolesCmdLet.cs" company="">
//   
// </copyright>
// <summary>
//   The new caas account roles cmd let.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Management.Automation;
using DD.CBU.Compute.Api.Contracts.Directory;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The new caas account roles cmd let.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasAccountRoles")]
	[OutputType(typeof(Role[]))]
	public class NewCaasAccountRolesCmdLet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets a value indicating whether network.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "SubAdministrator", 
			HelpMessage = "True of False for network role")]
		public bool Network { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether server.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "SubAdministrator", 
			HelpMessage = "True of False for server role")]
		public bool Server { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether backup.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "SubAdministrator", 
			HelpMessage = "True of False for backup role")]
		public bool Backup { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether create image.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "SubAdministrator", 
			HelpMessage = "True of False for create image role")]
		public bool CreateImage { get; set; }


		/// <summary>
		///     Gets or sets a value indicating whether storage.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "SubAdministrator", 
			HelpMessage = "True of False for storage role")]
		public bool Storage { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether reports.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "SubAdministrator", 
			HelpMessage = "True of False for reports role")]
		public bool Reports { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether read only.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "ReadOnly", 
			HelpMessage = "True of False for reports role")]
		public bool ReadOnly { get; set; }


		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			var roles = new List<Role>();
			if (Network)
				roles.Add(new Role(RoleType.Network));
			if (Backup)
				roles.Add(new Role(RoleType.Backup));
			if (Server)
				roles.Add(new Role(RoleType.Server));
			if (CreateImage)
				roles.Add(new Role(RoleType.CreateImage));
			if (Storage)
				roles.Add(new Role(RoleType.Storage));
			if (Reports)
				roles.Add(new Role(RoleType.Reports));
			if (ReadOnly)
				roles.Add(new Role(RoleType.ReadOnly));

			WriteObject(roles.ToArray());
		}
	}
}