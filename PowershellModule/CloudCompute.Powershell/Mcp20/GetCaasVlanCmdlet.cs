namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Client.Network20;
    using DD.CBU.Compute.Api.Contracts;

    /// <summary>
    /// The new CaaS Virtual Machine cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasVlan")]
    
    [OutputType(typeof(VlanType[]))]
    public class GetCaasVlanCmdlet : PsCmdletCaasBase
    {
        /// <summary>
        /// Switch to return the server object after execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the Vlan object after execution")]
        public SwitchParameter PassThru { get; set; }



        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            IEnumerable<VlanType> vlans = new List<VlanType>();
            base.ProcessRecord();
            try
            {                
                vlans = (this.Connection.ApiClient.GetVlans()).Result;
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            this.WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, this.Connection));
                        }
                        else
                        {
                            this.ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, this.Connection));
                        }
                        return true;
                    });
            }

            if (this.PassThru.IsPresent)
            {
                this.WriteObject(vlans);
            }
        }
    }
}