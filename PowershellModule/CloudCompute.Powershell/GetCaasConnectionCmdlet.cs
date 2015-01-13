using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.Get,"CaasConnection")]
    [OutputType(typeof(KeyValuePair<string,ComputeServiceConnection>[]))]
    public class GetCaasConnectionCmdlet:PSCmdlet
    {
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            WriteObject(SessionState.GetComputeServiceConnections(),true);



        }
    }
}
