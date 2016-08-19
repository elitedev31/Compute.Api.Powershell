// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasServerCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Management.Automation;
    using Api.Client;
    using Api.Contracts.General;
    using Api.Contracts.Network20;

    /// <summary>
    ///     The set server state cmdlet.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServer")]
    [OutputType(typeof(ResponseType))]
    [OutputType(typeof(Status), ParameterSetName = new []{"MCP1"})]
    public class SetCaasServerCmdlet : PsCmdletCaasServerBase
    {
        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the server name on CaaS")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the server description")]
        public string Description { get; set; }


        /// <summary>
        ///     Gets or sets the memory in mb.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the server RAM memory. Value must be represent a GB integer (e.g. 1024, 2048, 3072, 4096, etc.)", ParameterSetName= "MCP1")]
        [Obsolete("Please use Set-CaasServerSpec")]
        public int? MemoryInMb { get; set; }

        /// <summary>
        ///     Gets or sets the CPU count.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the number of virtual CPUs.", ParameterSetName = "MCP1")]
        [Obsolete("Please use Set-CaasServerSpec")]
        public int? CpuCount { get; set; }

        /// <summary>
        ///     Gets or sets the private IP.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Set the privateIp of the server", ParameterSetName = "MCP1")]
        public string PrivateIp { get; set; }

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
                var isMcp2 = Server.networkInfo != null;
                if (MemoryInMb.HasValue || CpuCount.HasValue || !string.IsNullOrEmpty(PrivateIp))
                {
                    if (isMcp2)
                    {
                        WriteError(new ErrorRecord(new ArgumentException("Please use Set-CaasServerSpec to update Memory and CPU"), "-3", ErrorCategory.InvalidArgument, Connection));
                        return;
                    }
                    var status = Connection.ApiClient.ServerManagementLegacy.Server.ModifyServer(Server.id, "", "", MemoryInMb ?? 0, CpuCount ?? 0, PrivateIp).Result;
                    WriteObject(status);
                }

                if (!string.IsNullOrEmpty(Name) || !string.IsNullOrEmpty(Description))
                {
                    var editServerResponse = Connection.ApiClient.ServerManagement.Server.EditServerMetadata(new editServerMetadata { id = Server.id, name = Name, description = Description, descriptionSpecified = !string.IsNullOrEmpty(Description)}).Result;
                    WriteObject(editServerResponse);
                }
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