namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Network;
    using DD.CBU.Compute.Api.Client.Network20;
    using DD.CBU.Compute.Api.Contracts;

    /// <summary>
    /// The new CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasNetworkDomain")]

    [OutputType(typeof(NetworkDomain[]))]
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
            IEnumerable<NetworkDomain> networks = new List<NetworkDomain>();
            base.ProcessRecord();
            try
            {
                networks = this.ParameterSetName.Equals("FilterNetworkDomains") ? (this.Connection.ApiClient.GetNetworkDomain(this.NetworkDomainId, this.NetworkDomainName)).Result : (this.Connection.ApiClient.GetNetworkDomains()).Result;                
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                        {
                            if (e is ComputeApiException)
                            {
                                this.WriteError(
                                    new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, this.Connection));
                            }
                            else
                            {
                                this.ThrowTerminatingError(
                                    new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, this.Connection));
                            }
                            return true;
                        });
            }

            if (networks != null && networks.Count() == 1)
            {
                this.WriteObject(networks.First());
            }
            else
            {
                this.WriteObject(networks);
            }          
        }
    }
}