using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The get Tag Key CMDLET
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasTagKey")]
    [OutputType(typeof(ResponseType))]
    public class GetCaasTagKeyCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Alias("Id")]
        [Parameter(Mandatory = false, ValueFromPipeline = true, ParameterSetName = "Filtered", HelpMessage = "The tag key id to filter")]
        public Guid TagKeyId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The tag key name to filter")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The value required to filter")]
        public bool? ValueRequired { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The displayed on reports to filter")]
        public bool? DisplayOnReport { get; set; }
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Tagging.GetTagKeysPaginated(
                        ParameterSetName.Equals("Filtered")
                            ? new Api.Contracts.Requests.Tagging.TagKeyListOptions
                                  {
                                      Id = TagKeyId != Guid.Empty ? TagKeyId : (Guid?)null,
                                      Name = Name,
                                      DisplayOnReport = DisplayOnReport,
                                      ValueRequired = ValueRequired
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
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            // if (e is HttpRequestException)
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }
    }
}