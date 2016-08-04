// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeployCaasVlanCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
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
	public class DeployCaasVlanCmdlet : PSCmdletCaasWithConnectionBase
	{
        [Parameter(Mandatory = true, ParameterSetName = "With_NetworkDomainId", HelpMessage = "The network domain id")]
        public string NetworkDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "With_NetworkDomain", HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

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
		///     Gets or sets the private ip v4 base address.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The vlan Private Ipv4 PrefixSize, must be between 16 and 24")]
        public int PrivateIpv4PrefixSize { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Wait until provisioned before returning")]
        public SwitchParameter Wait { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{
			ResponseType response = null;

            if (NetworkDomain != null)
            {
                NetworkDomainId = NetworkDomain.id;
            }

			try
			{
				response =
					Connection.ApiClient.Networking.Vlan.DeployVlan(
						new DeployVlanType
						{
							name = Name, 
							description = Description, 
							networkDomainId = NetworkDomainId.ToString(), 
							privateIpv4BaseAddress = PrivateIpv4BaseAddress.MapToIPv4().ToString(),
                            privateIpv4PrefixSize = PrivateIpv4PrefixSize
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

                if (this.Wait && response != null && response.responseCode == "IN_PROGRESS")
                {
                    bool provisioned = false;
                    VlanType vlan = null;
                    Guid vlanId = Guid.Parse(response.info.First(nvp => nvp.name == "vlanId").value);
                    while (!provisioned)
                    {
                        vlan = Connection.ApiClient.Networking.Vlan.GetVlan(vlanId).Result;
                        provisioned = vlan.state != "IN_PROGRESS" && vlan.state != "PENDING_ADD";
                    }
                    if (vlan.state == "NORMAL")
                        base.WriteObject(vlan);
                    else
                        ThrowTerminatingError(
								new ErrorRecord(new ComputeApiException(string.Format("Failed to provision VLAN {0}", vlan.state)), "-1", ErrorCategory.ConnectionError, Connection)); 
                }
                else
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