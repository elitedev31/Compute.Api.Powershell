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
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The remove caas network public ip block cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasNetworkPublicIpBlock", SupportsShouldProcess = true)]
    [OutputType(typeof(ResponseType), ParameterSetName = new[] { "MCP2" })]
    public class RemoveCaasNetworkPublicIpBlockCmdlet : PSCmdletCaasWithConnectionBase
	{
        /// <summary>
        ///     The network to add the public ip addresses
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1", HelpMessage = "The network to add the public ip addresses", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     The public ip block to be released
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1", HelpMessage = "The public ip block to be released", ValueFromPipeline = true)]
        public IpBlockType PublicIpBlock { get; set; }


        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }


        /// <summary>
        ///     The public ip block to be released
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2", HelpMessage = "The public ip block to be released", ValueFromPipeline = true)]
        public PublicIpBlockType PublicIpBlockType { get; set; }


        /// <summary>
        ///     The process record.
        /// </summary>
        protected override void ProcessRecord()
		{
            ResponseType response = null;
            base.ProcessRecord();
			try
			{

			    if (ParameterSetName == "MCP1")
			    {
			        if (!ShouldProcess(PublicIpBlock.baseIp)) return;
			        Status status =
			            Connection.ApiClient.NetworkingLegacy.Network.ReleaseNetworkPublicIpAddressBlock(Network.id,
			                PublicIpBlock.id)
			                .Result;
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
			    else
			    {

			        response =
			            Connection.ApiClient.Networking.IpAddress.DeletePublicIpBlock(Guid.Parse(NetworkDomain.id),
			                Guid.Parse(PublicIpBlockType.id)).Result;
                    WriteObject(response);

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