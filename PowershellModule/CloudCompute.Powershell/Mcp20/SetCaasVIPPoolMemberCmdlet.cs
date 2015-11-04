using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The set VIP pool member cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasVipPoolMember")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasVIPPoolMemberCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the Vip pool member.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The VIP pool member")]
        public PoolMemberType PoolMember { get; set; }
        
        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Is VIP pool member enabled?")]
        public bool Enabled { get; set; }
        
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var poolMember = new editPoolMember
                {
                    id = PoolMember.id,
                    status = Enabled ? "ENABLED" : "DISABLED"
                };

                response = Connection.ApiClient.Networking.VipPool.EditPoolMember(poolMember).Result;
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