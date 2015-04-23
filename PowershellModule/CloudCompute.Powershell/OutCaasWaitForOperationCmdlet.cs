using DD.CBU.Compute.Api.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
    /// <summary>
    /// Monitor CaaS provisioning progress 
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "CaasServerOperation")]
    [OutputType(typeof(ServerWithBackupType))]
    public class OutCaasWaitForOperationCmdlet : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
        public ServerWithBackupType Server { get; set; }

        private ProgressRecord _operationprogressRecord;
        private ProgressRecord OperationProgressRecord {
            get 
            {
                if (_operationprogressRecord == null)
                    _operationprogressRecord = new ProgressRecord(0, "Waiting...", "Waiting..");
                return _operationprogressRecord;
            } 
            }

        protected override void ProcessRecord()
        {
           

            DateTime starttime = DateTime.Now;
            try
            {
                bool operationInProgress = false;
                bool waitingToStart = true;
                ServerWithBackupType server = null;

                // initial loop to cover for any delay on the CaaS API, do while state of the server is normal (max 5 min)
                do
                {
                    var servers = this.GetDeployeServers(Server.id).Result;
                    if (servers != null)
                    {
                        server = servers.First();
                        waitingToStart = server.state.Equals("normal",StringComparison.InvariantCultureIgnoreCase);
                        OperationProgressRecord.Activity = "Waiting CaaS to start the operation...CaaS server state still NORMAL";
                        OperationProgressRecord.StatusDescription =  String.Format("If your operation does not change the server state do not use this cmdlet. Waiting another {0} minutes", (starttime.AddMinutes(5) - DateTime.Now).Minutes.ToString());
                        OperationProgressRecord.RecordType = ProgressRecordType.Processing;

                        WriteProgress(OperationProgressRecord);
                    }
                    if (waitingToStart)
                        Thread.Sleep(3000);
                    if(starttime.AddMinutes(5)<=DateTime.Now)
                        WriteError(new ErrorRecord(new TimeoutException("The wait operation timeout, as CaaS did not change not start in 5 minutes"), "-1", ErrorCategory.OperationTimeout, Connection));
                    

                } while (waitingToStart);
                OperationProgressRecord.RecordType = ProgressRecordType.Completed;
                OperationProgressRecord.PercentComplete = 100;
                WriteProgress(OperationProgressRecord);
                //do while state of the server contains pending
                operationInProgress = true;
                do
                {   //query the API to get the server progress
                    var servers = this.GetDeployeServers(Server.id).Result;
                    if (servers != null)
                    {
                        server = servers.First();

                        if (server.status!=null) 
                        {
                            string activity = server.status.action.Replace('_', ' ').ToTitleCase();
                            string stepname = string.Empty;
                            string activitytemplate = string.Empty;
                            string activitydescription = "Provisioning...";
                            int activityPercentComplete = 0;
                            if (server.status.step != null)
                            {
                                activity = server.status.action.Replace('_', ' ').ToTitleCase();
                                stepname = server.status.step.name.Replace('_', ' ').ToTitleCase();
                                activitytemplate = "{0} - Step {1} of {2}";
                                activitydescription = string.Format(activitytemplate, stepname, server.status.step.number, server.status.numberOfSteps);
                                activityPercentComplete = server.status.step.percentComplete;
                            }
                            OperationProgressRecord.Activity =activity ;
                            OperationProgressRecord.StatusDescription = activitydescription;
                            OperationProgressRecord.PercentComplete = activityPercentComplete;
                            OperationProgressRecord.RecordType = ProgressRecordType.Processing;
                            WriteProgress(OperationProgressRecord);
                        }
                        operationInProgress = server.state.ToLower().Contains("pending");
                        if(operationInProgress)
                            Thread.Sleep(7000);
                    }
                } while (operationInProgress);
                OperationProgressRecord.PercentComplete =100;
                OperationProgressRecord.RecordType = ProgressRecordType.Completed;
                WriteProgress(OperationProgressRecord);
              
                

                WriteObject(server);
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


            base.ProcessRecord();


        }


        private async Task<IEnumerable<ServerWithBackupType>> GetDeployeServers(string serverId)
        {
            return await Connection.ApiClient.GetDeployedServers(serverId, null, null, null);
        }

    }
}
