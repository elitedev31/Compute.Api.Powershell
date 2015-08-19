// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasServerAntiAffinityRuleCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get caas server anti affinity rule cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Server;
using ServerType = DD.CBU.Compute.Api.Contracts.Network20.ServerType;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The get caas server anti affinity rule cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasServerAntiAffinityRule")]
	[OutputType(typeof (AntiAffinityRuleType))]
	public class GetCaasServerAntiAffinityRuleCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     The network to show the anti affinity rules from
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "filter the network to show the the rules")]
		public NetworkWithLocationsNetwork Network { get; set; }


		/// <summary>
		///     The ruleid to show the anti affinity rules from
		/// </summary>
		[Parameter(Mandatory = false, Position = 0, HelpMessage = "filter the Antiaffinity rule id")]
		public string RuleId { get; set; }

		/// <summary>
		///     The location to show the anti affinity rules from
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "filter the location to show the rules")]
		public string Location { get; set; }


		/// <summary>
		///     A server to find to show the anti affinity rules from
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "find a rule base in a server")]
		public ServerType Server { get; set; }


		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				string networkid = null;
				if (Network != null)
				{
					networkid = Network.id;
				}

				IEnumerable<AntiAffinityRuleType> resultlist =
					Connection.ApiClient.ServerManagementLegacy.Server.GetServerAntiAffinityRules(RuleId, Location, networkid).Result;
				if (Server != null)
				{
					resultlist = resultlist.Where(rule => rule.serverSummary.Any(server => server.id == Server.id));
				}


				if (resultlist != null && resultlist.Any())
				{
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