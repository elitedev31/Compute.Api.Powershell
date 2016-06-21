// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSCmdletCaasServerBase.cs" company="">
// 
// </copyright>
// <summary>
//   This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace DD.CBU.Compute.Powershell
{
    using System.Management.Automation;
    using Api.Contracts.Network20;

    /// <summary>
    ///     This base Cmdlet is used for authenticating cmdlets that requires an active CaaS Connection.
    /// </summary>
    [OutputType(typeof(ServerType))]
    public abstract class PsCmdletCaasServerBase : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the server.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The server to action on")]
        public ServerType Server { get; set; }

        /// <summary>
        ///     Switch to return the server object after execution
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the Server object after execution")]
        public SwitchParameter PassThru { get; set; }


        /// <summary>
        ///     The begin processing.
        /// </summary>
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        /// <summary>
        ///     The process record.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            if (PassThru.IsPresent)
                WriteObject(Server);
        }
    }
}