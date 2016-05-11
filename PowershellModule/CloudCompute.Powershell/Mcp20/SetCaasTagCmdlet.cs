using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     Applies a single or multiple Tags to a Cloud asset CMDLET
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasTag")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasTagKeyCmdlet : PSCmdletCaasWithConnectionBase
    {
        
        [Parameter(Mandatory = true, HelpMessage = "The Asset type")]
        public AssetType AssetType { get; set; }

        [Alias("Id")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The UUID of the asset")]
        public string AssetId { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_TagKeyName", HelpMessage = "The Identification of tag key")]
        public string TagKeyName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "With_TagKeyId", HelpMessage = "The Identification of tag key")]
        public string TagKeyId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The value of tag key")]
        public string Value { get; set; }

        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var applyTag = new applyTags
                {
                    assetType = AssetType.ToString().ToUpperInvariant(),
                    assetId = AssetId,
                };

                if (ParameterSetName.Equals("With_TagKeyName"))
                {
                    var applyByName = new ApplyTagType
                    {
                        tagKeyName = TagKeyName,
                        value = Value,
                        valueSpecified = !string.IsNullOrEmpty(Value)
                    };
                    applyTag.tag = new[] { applyByName };
                }
                else
                {
                    var applyById = new ApplyTagByIdType
                    {
                        tagKeyId = TagKeyId,
                        value = Value,
                        valueSpecified = !string.IsNullOrEmpty(Value)
                    };
                    applyTag.tagById = new[] { applyById };
                }

                response = Connection.ApiClient.Tagging.ApplyTags(applyTag).Result;
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