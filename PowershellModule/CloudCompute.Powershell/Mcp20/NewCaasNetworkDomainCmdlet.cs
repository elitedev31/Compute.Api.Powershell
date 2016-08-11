using System;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Powershell.Contracts;
using DD.CBU.Compute.Api.Contracts.Generic;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    [Cmdlet(VerbsCommon.New, "CaasNetworkDomain")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasNetworkDomainCmdlet: WaitableCmdlet
    {
        /// <summary>
		///     Gets or sets the network domain location.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network domain datacenterId")]
        [Alias("Location")]
        public string DatacenterId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The  Network Domain name")]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The  Network Domain description")]
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the NetworkDomainType.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Network Domain Type")]
        public NetworkDomainServiceType Type { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                response =
                    Connection.ApiClient.Networking.NetworkDomain.DeployNetworkDomain(
                        new DeployNetworkDomainType
                        {
                            name = Name,
                            description = Description,
                            datacenterId = DatacenterId,
                            type = Type.ToString().ToUpperInvariant()
                        }).Result;
                if (response != null)
                    WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            response.operation,
                            response.message,
                            response.requestId,
                            response.responseCode));

                Guid networkDomainId = Guid.Parse(response.info.First(nvp => nvp.name == "networkDomainId").value);

                WaitForFailureOrCompletion(response, networkDomainId);
            }

            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(
                                new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, Connection));
                        }
                        else
                        {
                            ThrowTerminatingError(
                                new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
                        }

                        return true;
                    });
            }
        }

        public override void Update(Guid objectId, ref IEntityStatusV2 provisionedObject)
        {
            provisionedObject = Connection.ApiClient.Networking.NetworkDomain.GetNetworkDomain(objectId).Result;
        }
    }
}
