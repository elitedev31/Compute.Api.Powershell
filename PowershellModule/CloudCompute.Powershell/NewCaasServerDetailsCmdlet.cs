using DD.CBU.Compute.Api.Contracts.Image;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
    using DD.CBU.Compute.Api.Contracts.Server;
    using System.Management.Automation;

    /// <summary>
    /// The new CaaS Server Details cmdlet.
    /// This will be used to deploy a new VM.
    /// </summary>
    [Cmdlet(VerbsCommon.New, "CaasServerDetails")]
    [OutputType(typeof(CaasServerDetails))]
    public class NewCaasServerDetailsCmdlet : Cmdlet
    {
        /// <summary>
        /// The VM name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VM name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the machine (optional)
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The description of the VM")]
        public string Description { get; set; }

        /// <summary>
        /// The administrator password of the machine
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The VM administrator password")]
        public string AdminPassword { get; set; }

        /// <summary>
        /// The state of the VM after deployment (powered on or off)
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Will the VM be started after deployment (true|false)")]
        public bool IsStarted { get; set; }

        /// <summary>
        /// The OS image to use for deployment
        /// </summary>
        [Alias ("OsServerImage")]
        [Parameter(Mandatory = true, HelpMessage = "The OS or Customer Server Image to use for deployment")]
        public ImagesWithDiskSpeedImage ServerImage { get; set; }

        /// <summary>
        /// The network to deploy the machine to
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The network to deploy the machine to")]
        public NetworkWithLocationsNetwork Network { get; set; }
        
        /// <summary>
        /// The privateIp address of the machine
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The network private IP address that will be assigned to the machine.")]
        public string PrivateIp { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            if(!string.IsNullOrEmpty(PrivateIp) 
                && Network!=null )
                      ThrowTerminatingError(new ErrorRecord(new PSArgumentException("Please use Network or PrivateIP paramenter not both"), "-1", ErrorCategory.InvalidArgument, null));
            if (string.IsNullOrEmpty(PrivateIp)
             && Network == null)
                     ThrowTerminatingError(new ErrorRecord(new PSArgumentException("You must specify either a Network or PrivateIP paramenter"), "-1", ErrorCategory.InvalidArgument, null));

            WriteObject(
                new CaasServerDetails
                    {
                        AdministratorPassword = AdminPassword,
                        Name = Name,
                        Description = Description,
                        IsStarted = IsStarted,
                        Network = Network,
                        Image = ServerImage,
                        PrivateIp = PrivateIp
                    });
        }
    }
}