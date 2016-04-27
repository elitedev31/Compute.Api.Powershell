using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The get Tag CMDLET
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasTag")]
    [OutputType(typeof(ResponseType))]
    public class GetCaasTagCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The asset id to filter")]
        public string AssetId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The asset type to filter")]
        public string AssetType { get; set; }

        [Alias("Location")]
        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "Data Center Id/ Location to filter")]
        public string DataCenterId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The tag key name to filter")]
        public string TagKeyName { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The tag key id to filter")]
        public Guid? TagKeyId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The value to filter")]
        public string Value { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The value is required")]
        public bool? ValueRequired { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "Filtered", HelpMessage = "The display on report")]
        public bool? DisplayOnReport { get; set; }


        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                this.WritePagedObject(
                    Connection.ApiClient.Tagging.GetTagsPaginated(
                        ParameterSetName.Equals("Filtered")
                             ? new Api.Contracts.Requests.Tagging.TagListOptions
                                   {
                                       AssetId = AssetId,
                                       AssetType = AssetType,
                                       DatecenterId = DataCenterId,
                                       TagKeyId = TagKeyId,
                                       TagKeyName = TagKeyName,
                                       Value = Value,
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