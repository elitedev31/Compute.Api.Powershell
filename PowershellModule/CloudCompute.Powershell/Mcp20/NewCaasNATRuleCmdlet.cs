using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using Api.Contracts.Network;

    /// <summary>
    ///     The new NAT Rule CmdLet
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasNatRule")]
    [OutputType(typeof(ResponseType))]
    public class NewCaasNatRuleCmdlet : PSCmdletCaasWithConnectionBase
    {
        /// <summary>
        ///     Gets or sets the network domain.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The network domain")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
		///     Gets or sets the Internal IP Address.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Firewall rule name")]
        public string InternalIP { get; set; }

        /// <summary>
        ///     Gets or sets the External IP Address.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The Firewall rule name")]
        public string ExternalIP { get; set; }
      
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            ResponseType response = null;
            base.ProcessRecord();
            try
            {
                var natrule = new createNatRule
                {
                    Item = NetworkDomain.id,
                    internalIp = InternalIP,
                    externalIp = ExternalIP
                };

                response = Connection.ApiClient.Networking.Nat.CreateNatRule(natrule).Result;
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