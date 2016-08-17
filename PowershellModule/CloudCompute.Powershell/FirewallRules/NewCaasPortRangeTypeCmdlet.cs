using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
    using DD.CBU.Compute.Powershell.Mcp20.Model;

    /// <summary>
    ///     The new IP Address List CMD Let
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasPortRangeType")]
    [OutputType(typeof(PortListPort))]
    public class NewCaasPortRangeTypeCmdlet : PSCmdletCaasWithConnectionBase
    {
        [Parameter(Mandatory = true, HelpMessage = "The Port Begin of the Range")]
        public ushort Begin { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The Port End of the Range")]
        public ushort? End { get; set; }
        
        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            PortListPort response = null;
            try
            {
                response = new PortListPort { Begin = Begin, End = End };
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