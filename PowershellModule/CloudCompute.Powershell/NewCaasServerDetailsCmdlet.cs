namespace DD.CBU.Compute.Powershell
{
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
        /// The machine name
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The machine name")]
        public string Name { get; set; }

        /// <summary>
        /// The description of the machine (optional)
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "The description of the machine")]
        public string Description { get; set; }

        /// <summary>
        /// The administrator password of the machine
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The administrator password")]
        public string AdminPassword { get; set; }

        /// <summary>
        /// The state of the machine after deployment (powered on or off)
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Will the machine be started after deployment (true|false)")]
        public bool IsStarted { get; set; }

        /// <summary>
        /// The OS image to use for deployment
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The OS Server Image to use for deployment")]
        public DeployedImageWithSoftwareLabelsType OsServerImage { get; set; }

        /// <summary>
        /// The network to deploy the machine to
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The network to deploy the machine to")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        /// The process record method.
        /// </summary>
        protected override void ProcessRecord()
        {
            base.ProcessRecord();

            WriteObject(
                new CaasServerDetails
                    {
                        AdministratorPassword = AdminPassword,
                        Name = Name,
                        Description = Description,
                        IsStarted = IsStarted,
                        Network = Network,
                        OsImage = OsServerImage
                    });
        }
    }
}