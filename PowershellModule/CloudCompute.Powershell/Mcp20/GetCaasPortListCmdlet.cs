namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasPortList")]
    [OutputType(typeof(FirewallRuleType))]
    public class GetCaasPortCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "Filtered", HelpMessage = "The network domain id")]
        public Guid NetworkDomainId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The Port list id")]
        public Guid? PortListId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The Port List name")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The State of the Port List")]
        public string State { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Networking.FirewallRule.GetPortListsPaginated(
                        NetworkDomainId,
                        ParameterSetName.Equals("Filtered")
                            ? new PortListOptions
                            {
                                Id = PortListId != Guid.Empty ? PortListId : (Guid?)null,
                                State = State,
                                Name = Name,
                            } 
                            : null,
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
