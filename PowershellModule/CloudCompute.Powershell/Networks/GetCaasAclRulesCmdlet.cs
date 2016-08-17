// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasAclRulesCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get CaaS ACL Rules cmdlet.
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
	///     The get CaaS ACL Rules cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasAclRules")]
	[OutputType(typeof (AclRuleType))]
	public class GetCaasAclRulesCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The network to show the images from
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to show the ACL rules from", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Get a CaaS ACL by name
		/// </summary>
		[Parameter(Mandatory = false, Position = 0, HelpMessage = "ACL name to filter", ValueFromPipeline = true)]
		public string Name { get; set; }


		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				IEnumerable<AclRuleType> resultlist = GetAclRules();
				if (resultlist != null && resultlist.Any())
				{
					if (!string.IsNullOrEmpty(Name))
						resultlist =
							resultlist.Where(net => net != null && string.Equals(net.name, Name, StringComparison.CurrentCultureIgnoreCase));

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

		/// <summary>
		///     Gets the ACL rules from the specified network
		/// </summary>
		/// <returns>
		///     The ACL Rules
		/// </returns>
		private IEnumerable<AclRuleType> GetAclRules()
		{
			return Connection.ApiClient.NetworkingLegacy.Network.GetAclRules(Network.id).Result;
		}
	}
}