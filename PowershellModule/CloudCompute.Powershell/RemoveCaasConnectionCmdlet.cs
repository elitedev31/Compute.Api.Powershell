using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
     [Cmdlet(VerbsCommon.Remove, "CaasConnection")]
     public class RemoveCaasConnectionCmdlet:PSCmdlet
    {
        /// <summary>
        /// Name for this connection
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, HelpMessage = "Connection name to be removed from session.")]
        public string Name { get; set; }


         protected override void ProcessRecord()
         {
             base.ProcessRecord();

             try
             {
                 
                 SessionState.RemoveComputeServiceConnection(Name);


             }
             catch (AggregateException ae)
             {
                 ae.Handle(
                     e =>
                     {
                         ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Name));
                         return true;
                     });
             }
         }
    }
}
