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
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The new CaaS Virtual Machine cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasNetworkDomain", DefaultParameterSetName = "None")]
	[OutputType(typeof(NetworkDomainType))]
	public class GetCaasNetworkDomainCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
		/// <summary>
		///     Get a CaaS network domain by NetworkDomain Id
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "FilterById", HelpMessage = "NetworkDomain id")]
        [Alias("NetworkDomainId")]
		public Guid Id { get; set; }

		/// <summary>
		///     Get a CaaS network domain by NetworkDomain Name
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "FilterByName", HelpMessage = "NetworkDomain name")]
        [Alias("NetworkDomainName")]
        public string Name { get; set; }

        /// <summary>
        ///     Get a CaaS network domain by Datacenter Id
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Datacenter Id")]
        public string DatacenterId { get; set; }
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{		
			base.ProcessRecord();
			try
			{
				this.WritePagedObject(Connection.ApiClient.Networking.NetworkDomain.GetNetworkDomainsPaginated(
                     new NetworkDomainListOptions
                     {
                         DatacenterId = DatacenterId,
                         Id = Id != Guid.Empty ? Id : (Guid?)null,
                         Name = Name,
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