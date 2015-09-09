// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasNatRuleCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Add CaaS NAT Rule Cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using System.Net;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Add CaaS NAT Rule Cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasNatRule")]
	[OutputType(typeof (NatRuleType))]
	public class NewCaasNatRuleCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the network.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The target network to add the NAT rule into.", ValueFromPipeline = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Gets or sets the nat rule name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The NAT Rule name")]
		public string NatRuleName { get; set; }

		/// <summary>
		///     Gets or sets the source ip address.
		/// </summary>
		[Parameter(HelpMessage = "The source IP Address.")]
		public IPAddress SourceIpAddress { get; set; }

		/// <summary>
		///     Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				NatRuleType natRule = CreateNatRule();

				if (natRule != null)
				{
					WriteObject(natRule);
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
		///     The create nat rule.
		/// </summary>
		/// <returns>
		///     The <see cref="NatRuleType" />.
		/// </returns>
		private NatRuleType CreateNatRule()
		{
			return Connection.ApiClient.NetworkingLegacy.Network.CreateNatRule(Network.id, NatRuleName, SourceIpAddress).Result;
		}
	}
}