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

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The get caas network public ip blocks cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasNetworkPublicIpBlock")]
	[OutputType(typeof (IpBlockType))]
	public class GetCaasNetworkPublicIpBlocksCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The network to list the public ip addresses
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to release the public ip addresses", ValueFromPipeline = true)
		]
		public NetworkWithLocationsNetwork Network { get; set; }


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
				IEnumerable<IpBlockType> resultlist =
					Connection.ApiClient.NetworkingLegacy.Network.GetNetworkPublicIpAddressBlock(Network.id).Result;
				if (resultlist != null && resultlist.Any())
				{
					if (!string.IsNullOrEmpty(BaseIp))
						resultlist = resultlist.Where(ip => ip.baseIp == BaseIp);

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