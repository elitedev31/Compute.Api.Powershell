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
    public class SetCaasTagKeyCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Asset type")]
        public AssetType AssetType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The UUID of the asset")]
        public string AssetId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Tag Key name or Id value to the Tag Key being applied to the asset. Use New CaasTagKeyValueToApply command to create type")]
        public TagKeyValue TagKeyValue { get; set; }

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

                if (TagKeyValue.IdentificationType == TagKeyNameIdType.TagKeyName)
                {
                    var applyByName = new ApplyTagType
                                          {
                                              tagKeyName = TagKeyValue.Identification,
                                              value = TagKeyValue.Value,
                                              valueSpecified = !string.IsNullOrEmpty(TagKeyValue.Value)
                                          };
                    applyTag.tag = new[] { applyByName };
                }
                else
                {
                    var applyById = new ApplyTagByIdType
                    {
                        tagKeyId = TagKeyValue.Identification,
                        value = TagKeyValue.Value,
                        valueSpecified = !string.IsNullOrEmpty(TagKeyValue.Value)
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