// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasNetworkPublicIpBlockCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The remove caas network public ip block cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The remove caas network public ip block cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasNetworkPublicIpBlock", SupportsShouldProcess = true)]
	public class RemoveCaasNetworkPublicIpBlockCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// The network to add the public ip addresses
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to release the public ip addresses", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		/// The public ip block to be released
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The public ip block to be released", ValueFromPipeline = true)]
		public IpBlockType PublicIpBlock { get; set; }

		/// <summary>
		/// The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				if (!ShouldProcess(PublicIpBlock.baseIp)) return;

				Status status = Connection.ApiClient.ReleaseNetworkPublicIpAddressBlock(Network.id, PublicIpBlock.id).Result;
				if (status != null)
				{
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}", 
							status.operation, 
							status.result, 
							status.resultCode, 
							status.resultDetail));
				}
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