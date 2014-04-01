namespace DD.CBU.Compute.Powershell
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Security.Authentication;
    using System.Threading.Tasks;

    /// <summary>
    /// The get deployed server/s cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "CaasDeployedServer")]
    [OutputType(typeof(ServersWithBackupServer[]))]
    public class GetCaasDeployedServerCmdlet : Cmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true,
            HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            //if (CaaS != null)
            //{
            //    WriteDebug("Received CaaS connection as a paramenter");
            //    return;
            //}
            //WriteDebug("Trying to retrieve the CaaS connection from the runspace");
            //var caas = Runspace.DefaultRunspace.SessionStateProxy.GetVariable("CaasConnection");
            //if (!(caas is ComputeServiceConnection))
            //{
            //    ThrowTerminatingError(
            //        new ErrorRecord(
            //            new InvalidRunspaceStateException("CaaS connection is not a valid object"),
            //            "-1",
            //            ErrorCategory.InvalidType,
            //            caas));
            //}
            //else
            //{
            //    var caasConnection = caas as ComputeServiceConnection;
            //    if (!caasConnection.ApiClient.IsLoggedIn)
            //    {
            //        ThrowTerminatingError(new ErrorRecord(new AuthenticationException(), "-1", ErrorCategory.PermissionDenied, caas));
            //    }
            //}
        }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            var servers = GetNetworksTask().Result;
            if (servers.Any())
            {
                WriteObject(servers, true);
            }
        }

        /// <summary>
        /// Gets the network servers from the CaaS
        /// </summary>
        /// <returns>The images</returns>
        private async Task<IEnumerable<ServersWithBackupServer>> GetNetworksTask()
        {
            return await CaaS.ApiClient.GetDeployedServers();
        }
    }
}