using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;
    using Api.Contracts.Requests.Network20;

    [Cmdlet(VerbsCommon.Get, "CaasVipPool")]
    [OutputType(typeof(PoolType))]
    public class GetCaasVipPoolCmdlet : PSCmdletCaasWithConnectionBase
    {        
        /// <summary>
        ///     Gets or sets VIP Pool id.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "Filtered", ValueFromPipeline = true, HelpMessage = "The VIP Pool id")]
        public Guid PoolId { get; set; }

        protected override void ProcessRecord()
        {
            PoolType vipPool = new PoolType();
            base.ProcessRecord();

            try
            {
                vipPool = Connection.ApiClient.Networking.VipPool.GetPool(PoolId).Result;
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

            WriteObject(vipPool);            
        }
    }
}
