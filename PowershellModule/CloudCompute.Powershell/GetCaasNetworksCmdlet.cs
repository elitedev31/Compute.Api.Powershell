// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasNetworksCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get networks cmdlet.
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
	///     The get networks cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasNetworks")]
	[OutputType(typeof (NetworkWithLocationsNetwork[]))]
	public class GetCaasNetworksCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Get a CaaS network by name
		/// </summary>
		[Parameter(Mandatory = false, Position = 1, HelpMessage = "Network name to filter")]
		public string Name { get; set; }


		/// <summary>
		///     Get a CaaS network by name
		/// </summary>
		[Parameter(Mandatory = false, Position = 0, HelpMessage = "Location to filter")]
		public string Location { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<NetworkWithLocationsNetwork> resultlist =
					Connection.ApiClient.NetworkingLegacy.Network.GetNetworks().Result;

				if (resultlist != null && resultlist.Any())
				{
					if (!string.IsNullOrEmpty(Location))
						resultlist =
							resultlist.Where(item => string.Equals(item.location, Location, StringComparison.CurrentCultureIgnoreCase));

					if (!string.IsNullOrEmpty(Name))
						resultlist = resultlist.Where(net => string.Equals(net.name, Name, StringComparison.CurrentCultureIgnoreCase));

					switch (resultlist.Count())
					{
						case 0:
							WriteError(
								new ErrorRecord(
									new ItemNotFoundException(
										"This command cannot find a matching object with the given parameters."
										), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
							break;
						case 1:
							WriteObject(resultlist.First());
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