// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCmdletCaasWithConnectionBase.cs" company="">
//   
// </copyright>
// <summary>
//   This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace DD.CBU.Compute.Powershell
{
    using System.Management.Automation;
    using System.Security.Authentication;

    /// <summary>
    ///     This base Command is used for authenticating command that requires an active CaaS Connection.
    /// </summary>
    public abstract class PSCmdletCaasWithConnectionBase : PSCmdletCaasBase
    {
        /// <summary>
        ///     The CaaS connection created by <see cref="NewCaasConnectionCmdlet" />
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The CaaS Connection created by New-CaasConnection")]
        public ComputeServiceConnection Connection { get; set; }

        private HttpTraceLogger _logger;

        /// <summary>
        ///     The begin processing.
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            _logger = new HttpTraceLogger(this);

            // If CaaS connection is NOT set via parameter, get it from the PS session
            if (Connection == null)
            {
                Connection = SessionState.GetDefaultComputeServiceConnection();
                if (Connection == null)
                    ThrowTerminatingError(
                        new ErrorRecord(
                            new AuthenticationException(
                                "Cannot find a valid connection. Use New-CaasConnection to create or Set-CaasActiveConnection to set a valid connection"),
                            "-1",
                            ErrorCategory.AuthenticationError,
                            this));
            }
            Connection.OnRequestStart += _logger.LogRequestHandler;
        }


        protected override void EndProcessing()
        {
            base.EndProcessing();
            Connection.OnRequestStart -= _logger.LogRequestHandler;
            _logger.LogMessages();
        }
    }
}