// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasNetworkPublicIpBlocksCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get caas network public ip blocks cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The get caas network reserved public ip v4 cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasReservedPublicIpAddress")]
    [OutputType(typeof(ReservedPublicIpv4AddressType))]
    public class GetCaasReservedPublicIpAddressCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
        ///     The network to list the public ip addresses
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1", HelpMessage = "The network to get the public ip addresses", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
		///     The network to list the public ip addresses
		/// </summary>
		[Parameter(Mandatory = true, ParameterSetName = "MCP2", HelpMessage = "The network domain to get the public ip addresses", ValueFromPipeline = true)]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Filter the list based on the based public Ip block
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Filter the list based on the based public Ip")]
        public string IpAddress { get; set; }

        /// <summary>
        ///  Public Ip block id
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "MCP2", HelpMessage = "IP Address Block id")]
        public Guid? IpAddressBlockId { get; set; }

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
                    var resultlist = Connection.ApiClient.Networking.IpAddress.GetReservedPublicAddressesForNetwork(Guid.Parse(Network.id)).Result;
                    if (!string.IsNullOrEmpty(IpAddress))
                        resultlist = resultlist.Where(ip => ip.Value == IpAddress);
                    WriteObject(resultlist, true);
                    if (!resultlist.Any())
                        WriteError(
                                new ErrorRecord(
                                    new ItemNotFoundException(
                                        "This command cannot find a matching object with the given parameters."
                                        ), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
                }
                else if (ParameterSetName == "MCP2")
                {
                    this.WritePagedObject(
                        Connection.ApiClient.Networking.IpAddress.GetReservedPublicAddressesForNetworkDomainPaginated(
                            Guid.Parse(NetworkDomain.id), PageableRequest, new ReservedPublicIpv4ListOptions { IpAddress = IpAddress, IpBlockId = IpAddressBlockId }).Result);
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