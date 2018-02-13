 // --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasServersCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get deployed server/s cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests.Server20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The get deployed server/s cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasServer")]
	[OutputType(typeof (ServerType))]
	public class GetCaasServerCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
		/// <summary>
		///     Get a CaaS server by name
		/// </summary>
		[Parameter(Mandatory = false, Position = 0, HelpMessage = "Name of the server to filter")]
		public string Name { get; set; }

		/// <summary>
		///     Get a CaaS server by ServerId
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Server id  to filter")]
		public Guid? ServerId { get; set; }

		/// <summary>
		///     Get a CaaS server by network
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The network to show the servers from")]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Get a CaaS server by network
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The network domain to show the servers from")]
		public NetworkDomainType NetworkDomain { get; set; }

		/// <summary>
		///     Gets or sets the identifier of the network domain.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The network domain to show the servers from")]
		public string NetworkDomainId { get; set; }

		/// <summary>	Gets or sets the vlan. </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VLAN to filter by")]
		public VlanType Vlan { get; set; }

		/// <summary>	Gets or sets the identifier of the vlan. </summary>
		[Parameter(Mandatory = false, HelpMessage = "The VLAN ID to filter by")]
		public string VlanId { get; set; }

		/// <summary>
		///     Get a CaaS server by location
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Location of the server to filter")]
		public string Location { get; set; }


        /// <summary>
		///     Get a CaaS server by State
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "State of the server to filter")]
		public string State { get; set; }


		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
			    Guid vlanId;                
                if (!Guid.TryParse(VlanId, out vlanId))
			    {
			        vlanId = Vlan != null ? Guid.Parse(Vlan.id) : Guid.Empty;
			    }
               
                Guid networkDomainId;
                if (!Guid.TryParse(NetworkDomainId, out networkDomainId))
                {
                    networkDomainId = NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty;
                }                          
               

			    this.WritePagedObject(Connection.ApiClient.ServerManagement.Server.GetServersPaginated(new ServerListOptions()
			    {
			        Id = ServerId,
			        Name = Name,
			        NetworkId = Network != null ? Guid.Parse(Network.id) : (Guid?) null,
			        NetworkDomainId = networkDomainId != Guid.Empty? networkDomainId : (Guid?)null,
			        VlanId = vlanId != Guid.Empty? vlanId : (Guid?)null,
			        DatacenterId = Location,
                    State = State
			    }, PageableRequest).Result);
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