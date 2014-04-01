namespace DD.CBU.Compute.Powershell
{
    using System.Linq;
    using System.Management.Automation;
    using System.Security.Authentication;

    /// <summary>
    /// This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
    /// </summary>
    public abstract class PSCmdletCaasBase : PSCmdlet
    {
        /// <summary>
        /// The CaaS connection created by <see cref="NewCaasConnectionCmdlet"/> 
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The CaaS Connection created by New-ComputeServiceConnection")]
        public ComputeServiceConnection CaaS { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            // If CaaS connection is NOT set via parameter, get it from the PS session
            if (CaaS == null)
            {
                // TODO: Choose the correct connection in case of more than one connections in one session
                CaaS = SessionState.GetComputeServiceConnections().FirstOrDefault();
                if (CaaS == null)
                    this.ThrowTerminatingError(
                        new ErrorRecord(
                            new AuthenticationException("Cannot find a valid CaaS connection"),
                            "-1",
                            ErrorCategory.AuthenticationError,
                            this));
            }
        }
    }
}
