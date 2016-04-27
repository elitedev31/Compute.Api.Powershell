using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The new Tag Key CMDLET
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasTagKey")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasTagKeyCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The name of tag key")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The description of tag key")]
        public string Description { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Whether value can be considered optional when the Tag Key is applied to a Cloud asset")]
        public bool ValueRequired { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Whether the Tag Key will be displayed on reports")]
        public bool DisplayOnReport { get; set; }
        
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var createTagKey = new createTagKeyType
                                       {
                                           name = Name,
                                           description = Description,
                                           displayOnReport = DisplayOnReport,
                                           valueRequired = ValueRequired
                                       };
                response = Connection.ApiClient.Tagging.CreateTagKey(createTagKey).Result;
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