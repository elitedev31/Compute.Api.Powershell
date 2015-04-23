namespace DD.CBU.Compute.Powershell
{
    using System.Linq;
    using System.Management.Automation;
    using System.Security.Authentication;

    /// <summary>
    /// This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
    /// </summary>
    public abstract class PsCmdletCaasBase : PSCmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = false,ValueFromPipelineByPropertyName = true, HelpMessage = "The CaaS Connection created by New-CaasConnection")]
        public ComputeServiceConnection Connection { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            // If CaaS connection is NOT set via parameter, get it from the PS session
            if (Connection == null)
            {
                Connection = SessionState.GetDefaultComputeServiceConnection();
                if (Connection == null)
                    this.ThrowTerminatingError(
                        new ErrorRecord(
                            new AuthenticationException("Cannot find a valid connection. Use New-CaasConnection to create or Set-CaasActiveConnection to set a valid connection"),
                            "-1",
                            ErrorCategory.AuthenticationError,
                            this));
            }
        }
    }
}
