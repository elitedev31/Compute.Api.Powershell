// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeployCaasNetworkDomainCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Network Domain cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	/// The new CaaS Network Domain cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasNetworkDomain")]
	[OutputType(typeof (ResponseType))]
	public class DeployCaasNetworkDomainCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the network domain location.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network domain location")]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The  Network Domain name")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The  Network Domain description")]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the NetworkDomainType.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Network Domain Type")]
		public NetworkDomainServiceType Type { get; set; }

		/// <summary>
		/// The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			ResponseType response = null;
			try
			{
				response =
					Connection.ApiClient.DeployNetworkDomain(
						new DeployNetworkDomainType
						{
							name = Name, 
							description = Description, 
							datacenterId = Location, 
							type = Type.ToString().ToUpperInvariant()
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