using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Linq;

    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The remove Tag CMDLET
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasTag")]
    [OutputType(typeof(ResponseType))]
    public class RemoveCaasTagCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The Asset type")]
        public AssetType AssetType { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The UUID of the asset")]
        public string AssetId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_TagKeyName", HelpMessage = "Value of tagKey Name elements.")]
        public string TagKeyName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_TagKeyId", HelpMessage = "Value of tagKey Id elements.")]
        public string TagKeyId { get; set; }

        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                response =
                    Connection.ApiClient.Tagging.RemoveTags(
                        new RemoveTagsType
                            {
                                assetId = AssetId,
                                assetType = AssetType.ToString().ToUpperInvariant(),
                                Items = new[] { ParameterSetName.Equals("With_TagKeyName") ? TagKeyName : TagKeyId },
                                ItemsElementName = new[] { ParameterSetName.Equals("With_TagKeyName") ? TagKeyNameIdChoice.tagKeyName : TagKeyNameIdChoice.tagKeyId }
                            }).Result;
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