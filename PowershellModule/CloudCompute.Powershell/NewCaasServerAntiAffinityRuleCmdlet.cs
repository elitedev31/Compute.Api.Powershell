using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Contracts.Server;
using DD.CBU.Compute.Api.Client;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.New, "CaasServerAntiAffinityRule")]
    [OutputType(typeof(AntiAffinityRuleType))]
    public class NewCaasServerAntiAffinityRuleCmdlet:PsCmdletCaasBase
    {

        [Parameter(Mandatory = true, HelpMessage = "The server to add to anti affinity rule")]
        public ServerWithBackupType Server1 { get; set; }
       
        [Parameter(Mandatory = true, HelpMessage = "The server to add to anti affinity rule")]
        public ServerWithBackupType Server2 { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Return the  AntiAffinity object after execution")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            AntiAffinityRuleType rule = null;
            base.ProcessRecord();
            try
            {
                var status = Connection.ApiClient.CreateServerAntiAffinityRule(Server1.id, Server2.id).Result;
                if (status.result == "SUCCESS")
                {
                    var statusadditionalInfo = status.additionalInformation.Single(info => info.name == "antiaffinityrule.id");
                    if (statusadditionalInfo != null && PassThru.IsPresent)
                    {
                        var rules = Connection.ApiClient.GetServerAntiAffinityRules(statusadditionalInfo.value,null,null).Result;
                        if (rules.Any())
                        {
                            rule = rules.First();
                            WriteObject(rule);
                        }

                    }
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
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }
                        return true;
                    });
            }
         
               

        }
    }
}
