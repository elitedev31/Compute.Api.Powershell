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
        [Parameter(Mandatory = true, ParameterSetName = "With_PortListId", HelpMessage = "The Port list id")]
        public Guid Id { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "With_PortList", HelpMessage = "The Port list id")]
        public PortListType PortList { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Port List description")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                _descriptionSpecified = true;
            }
        }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual Ports or ranges of Ports. Use New CaasPortRangeType command to create type")]
        public PortListPort[] Port
        {
            get { return _port; }
            set
            {
                _port = value;
                _portSpecified = true;
            }
        }

        [Parameter(Mandatory = false,
            HelpMessage = "Define one or more individual Port Lists on the same Network Domain")]
        public string[] ChildPortListId
        {
            get { return _childPortIdList; }
            set
            {
                _childPortIdList = value;
                _childPortListIdSpecified = true;
            }
        }

        [Parameter(Mandatory = false, HelpMessage = "Define one or more individual Port Lists on the same Network Domain")]
        public PortListType[] ChildPortList
        {
            get { return _childPortList; }
            set
            {
                _childPortList = value;
                _childPortListIdSpecified = true;
            }
        }

        private PortListType[] _childPortList;
        /// <summary>
        /// Inner description value
        /// </summary>
        private string _description;

        /// <summary>
        /// Description changed
        /// </summary>
        private bool _descriptionSpecified;

        /// <summary>
        /// Inner Port List
        /// </summary>
        private string[] _childPortIdList;

        /// <summary>
        /// Port List specified
        /// </summary>
        private bool _childPortListIdSpecified;

        /// <summary>
        /// Inner Port
        /// </summary>
        private PortListPort[] _port;

        /// <summary>
        /// Inner Port specified
        /// </summary>
        private bool _portSpecified;
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                if (PortList != null)
                {
                    Id = Guid.Parse(PortList.id);
                }

                var port = Port != null
                    ? Port.Select(x => new EditPortListPort
                    {
                        begin = x.Begin ?? 0,
                        end = x.End ?? 0,
                        beginSpecified = x.Begin.HasValue,
                        endSpecified = x.End.HasValue,
                    }).ToArray()
                    : null;

                if (ChildPortList != null && ChildPortList.Length > 0)
                {
                    ChildPortListId = ChildPortList.Select(x => x.id).ToArray();
                }

                var portList = new editPortList
                {
                    id = Id.ToString(),
                    description = Description,
                    descriptionSpecified = _descriptionSpecified,
                    port = port,
                    portSpecified = _portSpecified,
                    childPortListId = ChildPortListId,
                    childPortListIdSpecified = _childPortListIdSpecified,
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