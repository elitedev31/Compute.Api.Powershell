using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    /// <summary>
    ///     The Set Caas Server Nic Connection state
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "CaasServerNicConnection")]
    [OutputType(typeof(ResponseType))]
    public class SetCaasServerNicConnectionCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets Nic Id.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Nic Id to be Connected/Disconnected")]
        public Guid NicId { get; set; }

        /// <summary>
        /// Gets or sets Connection State
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Nic Connection State")]
        public bool ConnectionState { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var connectionDetails = new SetConnectivityDetailsType[]
                {
                    new SetConnectivityDetailsType
                    {
                        id = NicId.ToString(),
                        connected = ConnectionState
                    }
                };

                var connectivityType = new SetNicConnectivityType
                {
                    Items = connectionDetails,
                    ItemsElementName = new ItemsChoiceType[] { ItemsChoiceType.nic }
                };


                response = Connection.ApiClient.ServerManagement.Server.SetNicConnectivity(connectivityType).Result;
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