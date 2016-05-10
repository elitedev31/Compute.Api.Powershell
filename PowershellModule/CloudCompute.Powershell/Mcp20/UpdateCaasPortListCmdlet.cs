using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System.Linq;

    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The Edit Port List CMD Let
    /// </summary>
    [Cmdlet("Update", "CaasPortList")]
    [OutputType(typeof(ResponseType))]
    public class UpdateCaasPortListCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true, ParameterSetName = "Filtered", HelpMessage = "The Port list id")]
        public Guid Id { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Port List description")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual Ports or ranges of Ports. Use New CaasPortRangeType command to create type")]
        public PortListPort[] Port { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual Port Lists on the same Network Domain")]
        public string[] ChildPortListId { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var port = Port != null
                    ? Port.Select(x => new EditPortListPort
                    {
                        begin = x.Begin ?? 0,
                        end = x.End ?? 0,
                        beginSpecified = x.Begin.HasValue,
                        endSpecified = x.End.HasValue,
                    }).ToArray()
                    : null;

                var portList = new editPortList
                {
                    id = Id.ToString(),
                    description = Description,
                    port = port,
                    childPortListId = ChildPortListId,
                };

                response = Connection.ApiClient.Networking.FirewallRule.EditPortList(portList).Result;
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

            WriteObject(response);
        }
    }
}