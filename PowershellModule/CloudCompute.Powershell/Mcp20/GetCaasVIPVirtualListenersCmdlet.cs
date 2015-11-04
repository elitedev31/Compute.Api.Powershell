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
    [Cmdlet(VerbsCommon.Get, "CaasVIPVirtualListeners")]
    [OutputType(typeof(VirtualListenerType[]))]
    public class GetCaasVIPVirtualListenersCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
		///     Gets or sets the VIP VirtualListener name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP virtual listener name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     Gets or sets VIP VirtualListener id.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP virtual listener id")]
        public Guid Id { get; set; }

        protected override void ProcessRecord()
        {
            IEnumerable<VirtualListenerType> vipVirtualListeners = new List<VirtualListenerType>();
            base.ProcessRecord();

            try
            {
                vipVirtualListeners = Connection.ApiClient.Networking.VipVirtualListener.GetVirtualListeners((ParameterSetName.Equals("Filtered") ? new VirtualListenerListOptions
                {
                    Id = Id != Guid.Empty ? Id : (Guid?)null,
                    Name = Name,
                    NetworkDomainId = NetworkDomain != null ? Guid.Parse(NetworkDomain.id) : Guid.Empty
                } : null)).Result;
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

            if (vipVirtualListeners != null && vipVirtualListeners.Count() == 1)
            {
                WriteObject(vipVirtualListeners.First());
            }
            else
            {
                WriteObject(vipVirtualListeners);
            }
        }
    }
}
