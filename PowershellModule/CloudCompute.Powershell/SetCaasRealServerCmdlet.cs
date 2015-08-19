// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasRealServerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set caas real server cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.VIP;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The set caas real server cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasRealServer")]
	public class SetCaasRealServerCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// The network to manage the VIP settings
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		/// The server to be added as real server
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The real server to be modified", ValueFromPipeline = true)]
		public RealServer RealServer { get; set; }


		/// <summary>
		/// The real server status
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The real server status")]
		public bool InService { get; set; }

		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				Status status = Connection.ApiClient.NetworkingLegacy.NetworkVip.ModifyRealServer(Network.id, RealServer.id, InService).Result;

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