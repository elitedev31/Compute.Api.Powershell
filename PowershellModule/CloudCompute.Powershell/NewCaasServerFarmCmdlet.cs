using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.VIP;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
    [Cmdlet(VerbsCommon.New, "CaasServerFarm")]
    [OutputType(typeof(ServerFarm))]
    public class NewCaasServerFarmCmdlet:PsCmdletCaasBase
    {

        /// <summary>
        /// The network to manage the VIP settings
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", ValueFromPipeline = true)]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The name for the server farm
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The name for the server farm")]
        public string Name { get; set; }


        /// <summary>
        /// The server farm predictor
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The server farm predictor ")]
        public ServerFarmPredictorType Predictor { get; set; }

        /// <summary>
        /// The first real server to be added to the server farm
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The first real server to be added to the server farm")]
        public RealServer RealServer { get; set; }


        /// <summary>
        /// The first real server port to be added to the server farm
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The first real server port to be added to the server farm")]
        [ValidateRange(1,65535)]
        public int RealServerPort { get; set; }

        /// <summary>
        /// The probe to be added to the server farm
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The probe to be added to the server farm")]
        public Probe Probe { get; set; }


        /// <summary>
        /// The network to add the public ip addresses
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Return the ServerFarm object")]
        public SwitchParameter PassThru { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            try
            {


                string probeId = null;
                if (Probe != null)
                    probeId = Probe.id;

                var status = CaaS.ApiClient.CreateServerFarm(Network.id, Name, Predictor, RealServer.id, RealServerPort, probeId).Result;
                if (status != null && PassThru.IsPresent)
                {

                   
         
                    var regexObj = new Regex(@"\x28id\x3A([-\w]*)\x29");
                    var match = regexObj.Match(status.resultDetail);
                    if (match.Success && match.Groups.Count > 1)
                    {
                        var serverfarm = new ServerFarm()
                        {
                            id = match.Groups[1].Value,
                            name = Name,
                            predictor = Predictor
                       };

                        WriteObject(serverfarm);
                    }
                    else
                    {
                        WriteError(new ErrorRecord(new CloudComputePsException("object Id not returned from API"), "-1", ErrorCategory.InvalidData, status));
                    }
            
                }
                WriteDebug(
                        string.Format(
                            "{0} resulted in {1} ({2}): {3}",
                            status.operation,
                            status.result,
                            status.resultCode,
                            status.resultDetail));


                
            }
            catch (AggregateException ae)
            {
                ae.Handle(
                    e =>
                    {
                        if (e is ComputeApiException)
                        {
                            WriteError(new ErrorRecord(e, "-2", ErrorCategory.InvalidOperation, CaaS));
                        }
                        else //if (e is HttpRequestException)
                        {
                            ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, CaaS));
                        }
                        return true;
                    });
            }
           

        }
        
    }
}
