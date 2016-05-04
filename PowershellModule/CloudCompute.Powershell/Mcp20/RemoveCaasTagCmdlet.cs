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
        [Parameter(Mandatory = true, ValueFromPipeline = true,  HelpMessage = "The Asset type")]
        public AssetType AssetType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The UUID of the asset")]
        public string AssetId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Type of tagKey Id or Name elements.")]

        public TagKeyNameIdType TagKeyNameIdType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Value of tagKey Id or Name elements.")]
        public string TagKeyNameIdValue { get; set; }

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
                                Items = new[] { TagKeyNameIdValue },
                                ItemsElementName = new[] { (TagKeyNameIdChoice)TagKeyNameIdType }
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