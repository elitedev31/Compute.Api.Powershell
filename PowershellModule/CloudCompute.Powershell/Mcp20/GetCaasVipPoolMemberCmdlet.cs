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

    [Cmdlet(VerbsCommon.Get, "CaasVipPoolMember")]
    [OutputType(typeof(PoolMemberType))]
    public class GetCaasVipPoolMemberCmdlet : PSCmdletCaasWithConnectionBase
    {        
        /// <summary>
        ///     Gets or sets VIP Pool Member Id
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The VIP pool member id")]
        public Guid MemberId { get; set; }

        protected override void ProcessRecord()
        {
            PoolMemberType poolMember = new PoolMemberType();
            base.ProcessRecord();

            try
            {
                poolMember = Connection.ApiClient.Networking.VipPool.GetPoolMember(MemberId).Result;
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

            WriteObject(poolMember);            
        }
    }
}
