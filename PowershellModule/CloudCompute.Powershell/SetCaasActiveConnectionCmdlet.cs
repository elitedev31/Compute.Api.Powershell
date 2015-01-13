using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
     [Cmdlet(VerbsCommon.Set, "CaasActiveConnection")]
     [OutputType(typeof(ComputeServiceConnection))]
    public class SetCaasActiveConnectionCmdlet : PSCmdlet
    {
        /// <summary>
        /// Name for this connection
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Connection name to be set as active.")]
        public string Name { get; set; }


         protected override void ProcessRecord()
         {
             base.ProcessRecord();

             try
             {
                 SessionState.SetDefaultComputeServiceConnection(Name);

             }
             catch (AggregateException ae)
             {
                 ae.Handle(
                     e =>
                     {
                         ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError,Name));
                         return true;
                     });
             }
      

         }
    }
}
