// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasVlanCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual LAN cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The new CaaS Virtual LAN cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasVlan")]
	[OutputType(typeof (VlanType))]
	public class GetCaasVlanCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
        ///     Get CaaS VLAN by VLAN ID
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The virtual lan id")]
        [Alias("VirtualLanId")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Get CaaS VLAN by VLAN Name
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The virtual lan name")]
        public string Name { get; set; }

        /// <summary>
        ///     Get CaaS VLAN by Datacenter Id
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Datacenter Id")]
        public string DatacenterId { get; set; }

        /// <summary>
        ///     Get CaaS VLAN by Network Domain.
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The virtual lan domain")]
		public NetworkDomainType NetworkDomain { get; set; }
        
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{			
			base.ProcessRecord();
			try
			{
                this.WritePagedObject(Connection.ApiClient.Networking.Vlan.GetVlansPaginated(
                     new VlanListOptions
                     {
                         DatacenterId = DatacenterId,
                         Id = Id != Guid.Empty ? Id : (Guid?)null,
                         Name = Name,
                         NetworkDomainId = (NetworkDomain != null) ? Guid.Parse(NetworkDomain.id) : (Guid?)null
                     }
                        , PageableRequest).Result);
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