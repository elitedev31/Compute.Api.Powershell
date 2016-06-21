namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.Network20;

    /// <summary>
    ///     The set server reconfigure cmdlet.
    /// </summary>
    [Cmdlet("Set", "CaasServerSpec")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasServerSpecCmdlet : PsCmdletCaasServerBase
    {
        /// <summary>
        ///     Gets or sets the memory in mb.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the server RAM memory. Value must be represent a GB integer (e.g. 1, 2, 3, 4, etc.)")]
        public uint? MemoryInGb { get; set; }

        /// <summary>
        ///     Gets or sets the CPU count.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the number of virtual CPUs.")]
        public uint? CpuCount { get; set; }

        /// <summary>
        ///     Gets or sets the CPU cores per socket.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the number of CPU cores per socket.")]
        public uint? CoresPerSocket { get; set; }


        /// <summary>Gets or sets the CPU speed.</summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the CPU Speed of the server. The available speed Id can be retrieved using (Get-CaasDataCentre).hypervisor.cpuSpeed")]
        public string CpuSpeed { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            SetServerTask();
            base.ProcessRecord();
        }

        /// <summary>
        ///     Edit the server details the state of the server
        /// </summary>
        private void SetServerTask()
        {
            try
            {
                var isMcp1 = Server.networkInfo == null;
                if (isMcp1 && (CoresPerSocket.HasValue || !string.IsNullOrEmpty(CpuSpeed)))
                {
                    WriteError(new ErrorRecord(new ArgumentException("Cannot update CoresPerSocket or CPUSpeed for MCP1 Servers"), "-4", ErrorCategory.InvalidArgument, Server));
                    return;
                }

                var reconfigureServer = new ReconfigureServerType
                {
                    id = Server.id, 
                    coresPerSocket = CoresPerSocket.HasValue ? CoresPerSocket.Value : 0, 
                    coresPerSocketSpecified = CoresPerSocket.HasValue, 
                    cpuCount = CpuCount.HasValue ? CpuCount.Value : 0, 
                    cpuCountSpecified = CpuCount.HasValue, 
                    memoryGb = MemoryInGb.HasValue ? MemoryInGb.Value : 0, 
                    memoryGbSpecified = MemoryInGb.HasValue, 
                    cpuSpeed = string.IsNullOrEmpty(CpuSpeed) ? null : CpuSpeed
                };
                var status = Connection.ApiClient.ServerManagement.Server.ReconfigureServer(reconfigureServer).Result;
                WriteObject(status);             
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
                        else
                        {
                            // if (e is HttpRequestException)
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }
    }
}