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
        [Parameter(Mandatory = true, HelpMessage = "The Asset type")]
        public AssetType AssetType { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The UUID of the asset")]
        public string AssetId { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Tag Key name to identify the Tag Key being applied to the asset.")]
        public ApplyTagType[] Tag { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Tag Key id to identify the Tag Key being applied to the asset.")]
        public ApplyTagByIdType[] TagById { get; set; }

        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                response =
                    Connection.ApiClient.Tagging.ApplyTags(
                        new applyTags
                            {
                                assetType = AssetType.ToString().ToUpperInvariant(),
                                assetId = AssetId,
                                tag = Tag,
                                tagById = TagById,
                            }).Result;
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