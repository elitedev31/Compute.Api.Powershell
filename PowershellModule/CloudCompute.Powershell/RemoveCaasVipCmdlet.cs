// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasVipCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The remove caas vip cmdlet.
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
	/// The remove caas vip cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasVip", SupportsShouldProcess = true)]
	public class RemoveCaasVipCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// The network to manage the VIP settings
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		/// The real server to be deleted
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The vip to be deleted", ValueFromPipeline = true)]
		public Vip Vip { get; set; }


		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			try
			{
				if (!ShouldProcess(Vip.name)) return;
				Status status = Connection.ApiClient.RemoveVip(Network.id, Vip.id).Result;

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