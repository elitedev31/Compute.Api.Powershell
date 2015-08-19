// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeployCaasVlanCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using System.Net;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The new CaaS Virtual Machine cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasVlan")]
	[OutputType(typeof (ResponseType))]
	public class DeployCaasVlanCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets the network domain id.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network domain Id")]
		public Guid NetworkDomainId { get; set; }

		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The vlan name")]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The vlan description")]
		public string Description { get; set; }

		/// <summary>
		///     Gets or sets the private ip v4 base address.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The vlan Private Ipv4BaseAddress")]
		public IPAddress PrivateIpv4BaseAddress { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			ResponseType response = null;
			try
			{
				response =
					Connection.ApiClient.Networking.Vlan.DeployVlan(
						new DeployVlanType
						{
							name = Name, 
							description = Description, 
							networkDomainId = NetworkDomainId.ToString(), 
							privateIpv4BaseAddress = PrivateIpv4BaseAddress.MapToIPv4().ToString()
						}).Result;
				if (response != null)
					WriteDebug(
						string.Format(
							"{0} resulted in {1} ({2}): {3}", 
							response.operation, 
							response.message, 
							response.requestId, 
							response.responseCode));

				base.ProcessRecord();
			}
			catch (AggregateException ae)
			{
				ae.Handle(
					e =>
					{
						if (e is ComputeApiException)
						{
							WriteError(
								new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
						}
						else
						{
							ThrowTerminatingError(
								new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}

			WriteObject(response);
		}
	}
}