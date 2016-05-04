namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;

    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The new Tag Key CMDLET
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasTagKeyValueToApply")]
    [OutputType(typeof(TagKeyValue))]
    public class NewCaasTagKeyValueToApplyCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The name or Id of tag key")]
        public TagKeyNameIdType IdentificationType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The Identification of tag key")]
        public string Identification { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The value of tag key")]
        public string Value { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var response = new TagKeyValue
                               {
                                   Identification = Identification,
                                   IdentificationType = IdentificationType,
                                   Value = Value
                               };
            WriteObject(response);
        }
    }
}