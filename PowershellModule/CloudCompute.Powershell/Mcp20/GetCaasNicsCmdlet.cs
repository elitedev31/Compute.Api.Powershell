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
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "With_VLan", HelpMessage = "Identifies NICs on an individual VLAN")]
        public VlanType Vlan { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_VLanId", HelpMessage = "Identifies NICs on an individual VLAN")]
        public Guid VlanId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Identifies an individual NIC")]
        public Guid? Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Identifies NICs on an individual Server")]
        public Guid? ServerId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Identifies NICs in an individual Security Group")]
        public Guid? SecurityGroupId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Indicates whether or not the given NIC is or is not part of a Security Group")]
        public bool? IsPartOfSecurityGroup { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                if (Vlan != null)
                {
                    VlanId = Guid.Parse(Vlan.id);
                }

                this.WritePagedObject(
                    Connection.ApiClient.ServerManagement.Server.ListNics(
                        VlanId,
                            new Api.Contracts.Requests.Server20.ListNicsOptions
                            {
                                Id = Id,
                                ServerId = ServerId,
                                SecurityGroupId = SecurityGroupId,
                                SecurityGroup =
                                          IsPartOfSecurityGroup.HasValue
                                              ? IsPartOfSecurityGroup.Value ? NullFilterOptions.NOT_NULL : NullFilterOptions.NULL
                                              : (NullFilterOptions?)null
                            },
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
