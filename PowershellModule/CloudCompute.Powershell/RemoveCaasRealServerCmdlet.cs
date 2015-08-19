// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasRealServerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The remove caas real server cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The remove caas real server cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasRealServer", SupportsShouldProcess = true)]
	public class RemoveCaasRealServerCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     The network to manage the VIP settings
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     The real server to be deleted
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The real server to be deleted", ValueFromPipeline = true)]
		public RealServer RealServer { get; set; }


		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			try
			{
				if (!ShouldProcess(RealServer.name)) return;
				Status status = Connection.ApiClient.NetworkingLegacy.NetworkVip.RemoveRealServer(Network.id, RealServer.id).Result;

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