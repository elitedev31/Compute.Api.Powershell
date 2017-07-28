// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasServerDiskCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.General;

    [Cmdlet(VerbsCommon.Remove, "CaasServerIsoFile", SupportsShouldProcess = true)]
    public class RemoveCaasServerIsoFileCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The id of ISO File")]
        public string Id { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                WriteObject(Connection.ApiClient.ServerManagement.Server.RemoveIsoFile(new IdType { id = Id }).Result);
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
                            ThrowTerminatingError(
                                new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }
    }
}