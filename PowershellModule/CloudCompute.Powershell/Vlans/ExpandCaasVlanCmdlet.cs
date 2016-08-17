namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;

    /// <summary>
    ///     The expand VLAN cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Resize, "CaasVlan")]
    [OutputType(typeof(ResponseType))]
    public class ExpandCaasVlanCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VLAN Id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the prefix size.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "An Integer between 16 and 23, which represents the size of the VLAN after expansion")]
        public int PrivateIpv4PrefixSize { get; set; }

        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var expandVlan = new ExpandVlanType()
                {
                    id = Id.ToString(),
                    privateIpv4PrefixSize = PrivateIpv4PrefixSize
                };

                response = Connection.ApiClient.Networking.Vlan.ExpandVlan(expandVlan).Result;
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

            WriteObject(response);
        }
    }
}