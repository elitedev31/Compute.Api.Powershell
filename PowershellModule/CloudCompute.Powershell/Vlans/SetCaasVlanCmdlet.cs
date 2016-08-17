namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;

    /// <summary>
    ///     The edit VLAN cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasVlan")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasVlanCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VLAN Id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the VLAN name on CaaS")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the VLAN description")]
        public string Description { get; set; }

        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var editVlan = new EditVlanType()
                {
                    id = Id.ToString(),
                    name = Name,
                    description = Description
                };

                response = Connection.ApiClient.Networking.Vlan.EditVlan(editVlan).Result;
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