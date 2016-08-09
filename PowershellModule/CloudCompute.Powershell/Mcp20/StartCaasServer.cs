using System;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;
using System.Management.Automation;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    /// Stop Server
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "CaasServer")]
    public class StartCaasServer : PsCmdletCaasServerBase
    {
        /// <summary>
        ///     Stop Caas Server
        /// </summary>
        /// 
        
        protected override void ProcessRecord()
        {
            try
            {
                ResponseType status = null;
                Guid serverId = Guid.Parse(Server.id);
                status = Connection.ApiClient.ServerManagement.Server.StartServer(serverId).Result;

                if (status != null)
                {
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.message,
                            status.responseCode,
                            status.error
                            )
                        );
                }
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
