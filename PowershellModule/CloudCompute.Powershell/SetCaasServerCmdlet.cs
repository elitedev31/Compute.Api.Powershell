// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasServerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The set server state cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasServer")]
	[OutputType(typeof (ServerWithBackupType))]
	public class SetCaasServerCmdlet : PsCmdletCaasServerBase
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Set the server name on CaaS")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Set the server description")]
		public string Description { get; set; }


		/// <summary>
		/// Gets or sets the memory in mb.
		/// </summary>
		[Parameter(Mandatory = false, 
			HelpMessage = "Set the server RAM memory. Value must be represent a GB integer (e.g. 1024, 2048, 3072, 4096, etc.)")]
		public int MemoryInMB { get; set; }

		/// <summary>
		/// Gets or sets the cpu count.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Set the number of virtual CPUs.")]
		public int CPUCount { get; set; }

		/// <summary>
		/// Gets or sets the private ip.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Set the privateIp of the server")]
		public string PrivateIp { get; set; }

		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			SetServerTask();
			base.ProcessRecord();
		}

		/// <summary>
		/// Edit the server details the state of the server
		/// </summary>
		private void SetServerTask()
		{
			try
			{
				Status status = null;

				status = Connection.ApiClient.ModifyServer(Server.id, Name, Description, MemoryInMB, CPUCount, PrivateIp).Result;
				if (status != null)
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}", 
							status.operation, 
							status.result, 
							status.resultCode, 
							status.resultDetail));
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
	}
}