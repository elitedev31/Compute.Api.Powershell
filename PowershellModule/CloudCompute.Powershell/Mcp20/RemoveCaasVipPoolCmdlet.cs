using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The Remove VIP Pool Rule CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "CaasVipPool")]
    [OutputType(typeof(ResponseType))]
    public class RemoveCaasVipPoolCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the VIP Pool.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The VIP Pool")]
        public PoolType VipPool { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {    
                response = Connection.ApiClient.Networking.VipPool.DeletePool(Guid.Parse(VipPool.id)).Result;
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