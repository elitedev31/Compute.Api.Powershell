// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeployCaasNetworkDomainCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Network Domain cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The new CaaS Network Domain cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasNetworkDomain")]
	[OutputType(typeof (ResponseType))]
	public class DeployCaasNetworkDomainCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     Gets or sets the network domain location.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network domain location")]
		public string Location { get; set; }

		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The  Network Domain name")]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The  Network Domain description")]
		public string Description { get; set; }

		/// <summary>
		///     Gets or sets the NetworkDomainType.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Network Domain Type")]
		public NetworkDomainServiceType Type { get; set; }

        [Parameter(Mandatory =false, HelpMessage = "Wait until provisioned before returning")]
        public SwitchParameter Wait { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			ResponseType response = null;
            base.ProcessRecord();
            try
			{
				response =
					Connection.ApiClient.Networking.NetworkDomain.DeployNetworkDomain(
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
                if (this.Wait  && response != null && response.responseCode == "IN_PROGRESS")
                {
                    bool provisioned = false;
                    NetworkDomainType domain = null;
                    Guid networkDomainId = Guid.Parse(response.info.First(nvp => nvp.name == "networkDomainId").value);
                    while (!provisioned)
                    {
                        domain = Connection.ApiClient.Networking.NetworkDomain.GetNetworkDomain(networkDomainId).Result;
                        provisioned = domain.state != "IN_PROGRESS" && domain.state != "PENDING_ADD";
                    }
                    if (domain.state == "NORMAL")
                        base.WriteObject(domain);
                    else
                        throw new Exception(string.Format("Failed to provision network domain {0}", domain.state));
                } else
                {
                    base.WriteObject(response);
                }
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
		}
	}
}