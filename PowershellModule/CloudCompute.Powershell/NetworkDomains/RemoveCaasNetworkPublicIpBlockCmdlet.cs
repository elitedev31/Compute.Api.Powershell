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
    [OutputType(typeof(Status), ParameterSetName = new[] { "MCP1" })]
    [OutputType(typeof(ResponseType), ParameterSetName = new[] { "MCP2" })]
    public class RemoveCaasNetworkPublicIpBlockCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The network to add the public ip addresses
		/// </summary>
		[Parameter(Mandatory = true, ParameterSetName = "MCP1", HelpMessage = "The network to release the public ip addresses", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     The public ip block to be released
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The public ip block to be released", ValueFromPipeline = true)]
		public PSObject PublicIpBlock { get; set; }


        /// <summary>
		///     The network to add the public ip addresses
		/// </summary>
		[Parameter(Mandatory = true, ParameterSetName = "MCP2", HelpMessage = "The network domain to release the public ip addresses",
            ValueFromPipelineByPropertyName = true)]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     The process record.
        /// </summary>
        protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
			    if (ParameterSetName == "MCP1")
			    {
			        var mcp1PublicIpBlock = PublicIpBlock.BaseObject as IpBlockType;
			        if (mcp1PublicIpBlock == null)
			        {
			            ThrowTerminatingError(
			                new ErrorRecord(new ArgumentException("PublicIpBlock type cannot be converted to " + typeof(IpBlockType)), "-3",
			                    ErrorCategory.InvalidArgument, Connection));
			            return;
			        }

                    if (!ShouldProcess(mcp1PublicIpBlock.baseIp)) return;
                    Status status =
                        Connection.ApiClient.NetworkingLegacy.Network.ReleaseNetworkPublicIpAddressBlock(Network.id, mcp1PublicIpBlock.id)
                            .Result;
                    WriteObject(status);
                }
				else if (ParameterSetName == "MCP2")
                    {
                        var mcp2PublicIpBlock = PublicIpBlock.BaseObject as PublicIpBlockType;
                        if (mcp2PublicIpBlock == null)
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(new ArgumentException("PublicIpBlock type cannot be converted to " + typeof(PublicIpBlockType)), "-3",
                                    ErrorCategory.InvalidArgument, Connection));
                            return;
                        }

                        if (!ShouldProcess(mcp2PublicIpBlock.baseIp)) return;
                        var result =
                            Connection.ApiClient.Networking.IpAddress.DeletePublicIpBlock(Guid.Parse(NetworkDomain.id), Guid.Parse(mcp2PublicIpBlock.id)).Result;
                        WriteObject(result);
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