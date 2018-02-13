// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveCaasServerDiskCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Remove, "CaasServerSnapshot", SupportsShouldProcess = true)]
    public class RemoveCaasServerSnapshotCmdlet : PsCmdletCaasServerBase
    {
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {
                WriteObject(Connection.ApiClient.ServerManagement.Server.DisableSnapshotService(new Api.Contracts.Network20.ServerIdType { serverId = Server.id }).Result);
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
