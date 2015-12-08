// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasNetworkPublicIpBlockCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new caas network public ip block cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The new caas network public ip block cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasNetworkPublicIpBlock")]
    [OutputType(typeof (IpBlockType), ParameterSetName = new[] {"MCP1"})]
    [OutputType(typeof (PublicIpBlockType), ParameterSetName = new[] {"MCP2"})]
    public class NewCaasNetworkPublicIpBlockCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     The network to add the public ip addresses
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1",
            HelpMessage = "The network to add the public ip addresses", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     The network to add the public ip addresses
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2",
            HelpMessage = "The network to add the public ip addresses", ValueFromPipeline = true)]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     The network to add the public ip addresses
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the IpBlockType object")]
        public SwitchParameter PassThru { get; set; }

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
                    CreatePublicIpOnMcp1Network();
                }
                else
                {
                    CreatePublicIpOnMcp2NetworkDomain();
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

        private void CreatePublicIpOnMcp2NetworkDomain()
        {
            var response =
                Connection.ApiClient.Networking.IpAddress.AddPublicIpBlock(Guid.Parse(NetworkDomain.id)).Result;
            if (response != null)
            {
                if (response.info != null && PassThru.IsPresent)
                {
                    var ipblockid =
                        response.info.SingleOrDefault(info => info.name == "ipBlockId");
                    if (ipblockid == null)
                    {
                        WriteObject(response);
                        return;
                    }

                    var publicIpBlock = Connection.ApiClient.Networking.IpAddress.GetPublicIpBlock(Guid.Parse(NetworkDomain.id),
                        Guid.Parse(ipblockid.value)).Result;
                   
                    WriteObject(publicIpBlock);
                }
                else
                    WriteObject(response);
            }
        }

        private void CreatePublicIpOnMcp1Network()
        {
            Status status =
                Connection.ApiClient.NetworkingLegacy.Network.ReserveNetworkPublicIpAddressBlock(Network.id).Result;
            if (status != null)
            {
                if (status.additionalInformation != null && PassThru.IsPresent)
                {
                    var ipblock = new IpBlockType();


                    AdditionalInformation ipblockid =
                        status.additionalInformation.Single(info => info.name == "ipBlock.id");
                    if (ipblockid != null)
                        ipblock.id = ipblockid.value;

                    AdditionalInformation baseip =
                        status.additionalInformation.Single(info => info.name == "ipBlock.baseIp");
                    if (baseip != null)
                        ipblock.baseIp = baseip.value;

                    AdditionalInformation blocksize =
                        status.additionalInformation.Single(info => info.name == "ipBlock.size");
                    if (blocksize != null)
                        ipblock.subnetSize = int.Parse(blocksize.value);

                    ipblock.serverToVipConnectivity = false;
                    WriteObject(ipblock);
                }

                WriteDebug(
                    string.Format(
                        "{0} resulted in {1} ({2}): {3}",
                        status.operation,
                        status.result,
                        status.resultCode,
                        status.resultDetail));
            }
        }
    }
}