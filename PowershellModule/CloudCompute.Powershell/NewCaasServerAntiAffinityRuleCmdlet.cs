// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasServerAntiAffinityRuleCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new caas server anti affinity rule cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Server;
using ServerType = DD.CBU.Compute.Api.Contracts.Network20.ServerType;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The new caas server anti affinity rule cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasServerAntiAffinityRule")]
	[OutputType(typeof (AntiAffinityRuleType))]
	public class NewCaasServerAntiAffinityRuleCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the server 1.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server to add to anti affinity rule")]
		public ServerType Server1 { get; set; }

		/// <summary>
		///     Gets or sets the server 2.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server to add to anti affinity rule")]
		public ServerType Server2 { get; set; }

		/// <summary>
		///     Gets or sets the pass thru.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Return the  AntiAffinity object after execution")]
		public SwitchParameter PassThru { get; set; }

		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			AntiAffinityRuleType rule = null;
			base.ProcessRecord();
			try
			{
				Status status =
					Connection.ApiClient.ServerManagementLegacy.Server.CreateServerAntiAffinityRule(Server1.id, Server2.id).Result;
				if (status.result == "SUCCESS")
				{
					AdditionalInformation statusadditionalInfo =
						status.additionalInformation.Single(info => info.name == "antiaffinityrule.id");
					if (statusadditionalInfo != null && PassThru.IsPresent)
					{
						IEnumerable<AntiAffinityRuleType> rules =
							Connection.ApiClient.ServerManagementLegacy.Server.GetServerAntiAffinityRules(statusadditionalInfo.value, null, 
								null).Result;
						if (rules.Any())
						{
							rule = rules.First();
							WriteObject(rule);
						}
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