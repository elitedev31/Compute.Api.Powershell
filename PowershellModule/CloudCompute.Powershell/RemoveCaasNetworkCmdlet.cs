// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasNetworkCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The "Remove-CaasNetwork" Cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The "Remove-CaasNetwork" Cmdlet.
	/// </summary>
	/// <remarks>
	///     Removes a network from a data centre using the network id.
	/// </remarks>
	[Cmdlet(VerbsCommon.Remove, "CaasNetwork", SupportsShouldProcess = true)]
	public class RemoveCaasNetworkCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the network.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The target data centre location for the customer image.", 
			ValueFromPipeline = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				if (!ShouldProcess(Network.name)) return;
				Status status = Connection.ApiClient.NetworkingLegacy.Network.DeleteNetwork(Network.id).Result;
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