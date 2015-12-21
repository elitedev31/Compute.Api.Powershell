using System;
using System.Collections.Generic;
using System.Linq;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    /// <summary>
    /// Get Caas VIP Virtual Listeners CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasVIPVirtualListener")]
    [OutputType(typeof(VirtualListenerType))]
    public class GetCaasVipVirtualListenerCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the VIP VirtualListener name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP virtual listener name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets VIP VirtualListener id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The VIP virtual listener id")]
        public Guid Id { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Networking.VipVirtualListener.GetVirtualListenersPaginated(
                        (ParameterSetName.Equals("Filtered")
                            ? new VirtualListenerListOptions
                            {
                                Id = Id != Guid.Empty ? Id : (Guid?) null,
                                Name = Name,
                                NetworkDomainId = NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : (Guid?) null
                            }
                            : null),
                        PageableRequest).Result);
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
