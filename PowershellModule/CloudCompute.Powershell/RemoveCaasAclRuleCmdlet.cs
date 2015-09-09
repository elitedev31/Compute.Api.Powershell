// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasAclRuleCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Remove ACL Rule cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Remove ACL Rule cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Remove, "CaasAclRule", SupportsShouldProcess = true)]
	public class RemoveCaasAclRuleCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the network.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network that the ACL Rule exists", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Gets or sets the acl rule.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The ACL rule to delete", ValueFromPipeline = true)]
		public AclRuleType AclRule { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				if (!ShouldProcess(AclRule.name)) return;
				DeleteAclRule();
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
		///     Removes an ACL Rule
		/// </summary>
		private void DeleteAclRule()
		{
			Status status = Connection.ApiClient.NetworkingLegacy.Network.DeleteAclRule(Network.id, AclRule.id).Result;
			if (status != null)
			{
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