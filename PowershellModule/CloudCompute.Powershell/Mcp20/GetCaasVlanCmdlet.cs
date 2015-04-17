namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Network20;
    using DD.CBU.Compute.Api.Contracts;

    /// <summary>
    /// The new CaaS Virtual LAN cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasVlan")]
    
    [OutputType(typeof(VlanType[]))]
    public class GetCaasVlanCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The virtual lan name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The virtual lan domain")]
        public NetworkDomain NetworkDomain { get; set; }

        /// <summary>
        /// Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The virtual lan domain")]
        public Guid VirtualLanId { get; set; }
        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            IEnumerable<VlanType> vlans = new List<VlanType>();
            base.ProcessRecord();
            try
            {
                vlans = this.ParameterSetName.Equals("Filtered")
                            ? (this.Connection.ApiClient.GetVlans(
                                this.VirtualLanId,
                                this.Name,
                                (this.NetworkDomain != null) ? Guid.Parse(this.NetworkDomain.id) : Guid.Empty)).Result
                            : (this.Connection.ApiClient.GetVlans()).Result;
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
            
            if (vlans != null && vlans.Count() == 1)
            {
                this.WriteObject(vlans.First());
            }
            else
            {
                this.WriteObject(vlans);
            }             
        }
    }
}