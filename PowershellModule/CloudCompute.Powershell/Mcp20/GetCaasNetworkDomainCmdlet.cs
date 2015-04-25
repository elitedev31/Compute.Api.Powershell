// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasNetworkDomainCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	/// The new CaaS Virtual Machine cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasNetworkDomain")]
	[OutputType(typeof (NetworkDomainType[]))]
	public class GetCaasNetworkDomainCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Get a CaaS server by ServerId
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "FilterNetworkDomains", HelpMessage = "NetworkDomain id")]
		public Guid NetworkDomainId { get; set; }

		/// <summary>
		/// Get a CaaS server by ServerId
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "FilterNetworkDomains", HelpMessage = "NetworkDomain name")]
		public string NetworkDomainName { get; set; }

		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			IEnumerable<NetworkDomainType> networks = new List<NetworkDomainType>();
			base.ProcessRecord();
			try
			{
				networks = ParameterSetName.Equals("FilterNetworkDomains")
					? Connection.ApiClient.GetNetworkDomain(NetworkDomainId, NetworkDomainName).Result
					: Connection.ApiClient.GetNetworkDomains().Result;
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

			if (networks != null && networks.Count() == 1)
			{
				WriteObject(networks.First());
			}
			else
			{
				WriteObject(networks);
			}
		}
	}
}