using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The update Tag Key CMDLET
    /// </summary>
    [Cmdlet("Update", "CaasTagKey")]
    [OutputType(typeof(ResponseType))]
    public class UpdateCaasTagKeyCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The id of tag key")]
        public string Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The name of tag key")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The description of tag key")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether value can be considered optional when the Tag Key is applied to a Cloud asset")]
        public bool? ValueRequired { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Whether the Tag Key will be displayed on reports")]
        public bool? DisplayOnReport { get; set; }

        private readonly string dummyText = "EmptyValue!!";

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCaasTagKeyCmdlet"/> class.
        /// </summary>
        public UpdateCaasTagKeyCmdlet()
        {
            // assigned a dummy value to description to determine is modified or not
            this.Description = dummyText;
        }

        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var tagKey = new EditTagKeyType
                                 {
                                     id = Id,
                                     name = Name,
                                     nameSpecified = !string.IsNullOrEmpty(Name),
                                     description = Description,
                                     descriptionSpecified = Description != dummyText,
                                     displayOnReport = DisplayOnReport ?? false,
                                     displayOnReportSpecified = DisplayOnReport.HasValue,
                                     valueRequired = ValueRequired ?? false,
                                     valueRequiredSpecified = ValueRequired.HasValue
                                 };
                response = Connection.ApiClient.Tagging.EditTagKey(tagKey).Result;
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

            WriteObject(response);
        }
    }
}