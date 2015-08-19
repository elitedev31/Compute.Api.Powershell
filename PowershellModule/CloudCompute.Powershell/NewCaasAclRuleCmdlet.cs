// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasAclRuleCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Add CaaS ACL Rule Cmdlet.
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
	///     The Add CaaS ACL Rule Cmdlet.
	/// </summary>
	/// <remarks>
	///     Imports a new customer image.
	/// </remarks>
	[Cmdlet(VerbsCommon.New, "CaasAclRule")]
	[OutputType(typeof (AclRuleType))]
	public class NewCaasAclRuleCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets the network.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The target network to add the ACL rule into.", ValueFromPipeline = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Gets or sets the acl rule name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The ACL Rule name")]
		public string AclRuleName { get; set; }

		/// <summary>
		///     Gets or sets the position.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The position of the ACL rule to add")]
		[ValidateRange(100, 500)]
		public int Position { get; set; }

		/// <summary>
		///     Gets or sets the action.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The ACL action type: Permit or Deny")]
		public AclActionType Action { get; set; }

		/// <summary>
		///     Gets or sets the protocol.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The protocol")]
		public AclProtocolType Protocol { get; set; }

		/// <summary>
		///     Gets or sets the source ip address.
		/// </summary>
		[Parameter(HelpMessage = "The source IP Address. If not supplied, ANY IP address is assumed.")]
		public IPAddress SourceIpAddress { get; set; }

		/// <summary>
		///     Gets or sets the source netmask.
		/// </summary>
		[Parameter(
			HelpMessage = "The source Netmask. If supplied with the SourceIpAddress, represents CIDR boundary for the network.")]
		public IPAddress SourceNetmask { get; set; }

		/// <summary>
		///     Gets or sets the destination ip address.
		/// </summary>
		[Parameter(HelpMessage = "The destination IP Address. If not supplied, ANY IP address is assumed.")]
		public IPAddress DestinationIpAddress { get; set; }

		/// <summary>
		///     Gets or sets the destination netmask.
		/// </summary>
		[Parameter(
			HelpMessage =
				"The destination Netmask. If supplied with the DestinationIpAddress, represents CIDR boundary for the network.")]
		public IPAddress DestinationNetmask { get; set; }

		/// <summary>
		///     Gets or sets the port range type.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The port range type")]
		public PortRangeTypeType PortRangeType { get; set; }

		/// <summary>
		///     Gets or sets the port 1.
		/// </summary>
		[Parameter(HelpMessage = "Depending on the port range type - will define the port criteria")]
		[ValidateRange(1, 65535)]
		public int Port1 { get; set; }

		/// <summary>
		///     Gets or sets the port 2.
		/// </summary>
		[Parameter(HelpMessage = "Depending on the port range type - will define the port criteria")]
		[ValidateRange(1, 65535)]
		public int Port2 { get; set; }

		/// <summary>
		///     Gets or sets the acl type.
		/// </summary>
		[Parameter(HelpMessage = "The type of the ACL. One of OUTSIDE_ACL or INSIDE_ACL. Default is OUTSIDE_ACL.")]
		[PSDefaultValue(Value = AclType.OUTSIDE_ACL)]
		public AclType AclType { get; set; }

		/// <summary>
		///     Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				AclRuleType aclRule = CreateAclRule();

				if (aclRule != null)
				{
					WriteObject(aclRule);
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
		///     The create acl rule.
		/// </summary>
		/// <returns>
		///     The <see cref="AclRuleType" />.
		/// </returns>
		private AclRuleType CreateAclRule()
		{
			return
				Connection.ApiClient.NetworkingLegacy.Network.CreateAclRule(
					Network.id, 
					AclRuleName, 
					Position, 
					Action, 
					Protocol, 
					PortRangeType, 
					SourceIpAddress, 
					SourceNetmask, 
					DestinationIpAddress, 
					DestinationNetmask, 
					Port1, 
					Port2, 
					AclType).Result;
		}
	}
}