// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasNetworkPublicIpBlocksCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get caas network public ip blocks cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The get caas network public ip blocks cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasNetworkPublicIpBlock")]
    [OutputType(typeof(IpBlockType), ParameterSetName = new[] { "MCP1" })]
    [OutputType(typeof(PublicIpBlockType), ParameterSetName = new[] { "MCP2" })]
    public class GetCaasNetworkPublicIpBlocksCmdlet : PSCmdletCaasWithConnectionBase
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
        [Parameter(Mandatory = false, HelpMessage = "Filter the list based on the based public Ip block")]
		public string BaseIp { get; set; }

		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
			    IEnumerable<object> resultlist = null;

			    if (ParameterSetName == "MCP1")
			    {
                    resultlist = Connection.ApiClient.NetworkingLegacy.Network.GetNetworkPublicIpAddressBlock(Network.id).Result;			      
			    }
                else if (ParameterSetName == "MCP2")
                {
                    resultlist = Connection.ApiClient.Networking.IpAddress.GetPublicIpBlocks(Guid.Parse(NetworkDomain.id)).Result;              
                }


                if (resultlist != null && resultlist.Any())
				{
                    if (!string.IsNullOrEmpty(BaseIp))
                        if (ParameterSetName == "MCP1")
                            resultlist = ((IEnumerable<IpBlockType>)resultlist).Where(ip => ip.baseIp == BaseIp);
                        else
                            resultlist = ((IEnumerable<PublicIpBlockType>)resultlist).Where(ip => ip.baseIp == BaseIp);

                    switch (resultlist.Count())
					{
						case 0:
							WriteError(
								new ErrorRecord(
									new ItemNotFoundException(
										"This command cannot find a matching object with the given parameters."
										), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
							break;					
						default:
							WriteObject(resultlist, true);
							break;
					}
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