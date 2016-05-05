namespace DD.CBU.Compute.Powershell.Mcp20
{
    using System;
    using System.Management.Automation;
    using DD.CBU.Compute.Api.Client;
    using DD.CBU.Compute.Api.Contracts.Network20;
    using DD.CBU.Compute.Powershell.Mcp20.Model;
    using System.Linq;
    /// <summary>
    ///     The new Port List CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasPortList")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasPortListCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain id")]
        public string NetworkDomainId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The Port List name")]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "The Port List description")]
        public string Description { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Define one or more individual Portes or ranges of Portes. Use New CaasPortRangeType command to create type")]
        public PortListPort[] Port { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true, HelpMessage = "Define one or more individual Port Lists on the same Network Domain")]
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
                var portList = new createPortList
                {
                    networkDomainId = NetworkDomainId,
                    name = Name,
                    description = Description,
                    childPortListId = ChildPortListId,
                    port = Port != null ? 
                        Port.Select(x => new PortRangeType
                        {
                            begin = x.Begin.Value,
                            end = x.End.HasValue ? x.End.Value : (ushort)0,
                            endSpecified = x.End.HasValue
                        }).ToArray()
                        : null,
                };

                response = Connection.ApiClient.Networking.FirewallRule.CreatePortList(portList).Result;
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