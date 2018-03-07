// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasServerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get deployed server cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;

    /// <summary>
    ///     The get deployed server cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Find, "CaasServer")]
    [OutputType(typeof(ServerType))]
    public class FindCaasServerCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Get a CaaS server by ServerId
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Server id")]
        public Guid ServerId { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            try
            {
                this.WriteObject(Connection.ApiClient.ServerManagement.Server.GetServer(ServerId).Result);
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