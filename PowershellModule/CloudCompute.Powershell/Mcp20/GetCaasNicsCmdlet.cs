namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;

    using DD.CBU.Compute.Api.Contracts.Requests;

    [Cmdlet(VerbsCommon.Get, "CaasNic")]
    [OutputType(typeof(NicWithSecurityGroupType))]
    public class GetCaasNicsCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = true, ParameterSetName = "Filtered", HelpMessage = "Identifies NICs on an individual VLAN")]
        public Guid VlanId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "Identifies an individual NIC")]
        public Guid? Id { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "Identifies NICs on an individual Server")]
        public Guid? ServerId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "Identifies NICs in an individual Security Group")]
        public Guid? SecurityGroupId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "Indicates whether or not the given NIC is or is not part of a Security Group")]
        public bool? IsPartOfSecurityGroup { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.ServerManagement.Server.ListNics(
                        VlanId,
                        ParameterSetName.Equals("Filtered")
                            ? new Api.Contracts.Requests.Server20.ListNicsOptions
                            {
                                Id = Id,
                                ServerId = ServerId,
                                SecurityGroupId = SecurityGroupId,
                                SecurityGroup =
                                          IsPartOfSecurityGroup.HasValue
                                              ? IsPartOfSecurityGroup.Value ? NullFilterOptions.NOT_NULL : NullFilterOptions.NULL
                                              : (NullFilterOptions?)null
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
