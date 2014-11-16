using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
    using System.Linq;
    using System.Management.Automation;
    using System.Security.Authentication;

    /// <summary>
    /// This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
    /// </summary>
    [OutputType(typeof(ServerWithBackupType))]
    public abstract class PsCmdletCaasServerBase : PsCmdletCaasBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
        public ServerWithBackupType Server { get; set; }

        /// <summary>
        /// Switch to return the server object after execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the Server object after execution")]
        public SwitchParameter PassThru { get; set; }


        protected override void BeginProcessing()
        {
            base.BeginProcessing();
          

        }
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (PassThru.IsPresent)
                WriteObject(Server);
        }
    }
}

