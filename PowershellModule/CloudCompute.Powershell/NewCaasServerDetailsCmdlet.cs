// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasServerDetailsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Server Details cmdlet.
//   This will be used to deploy a new VM.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Management.Automation;
using DD.CBU.Compute.Api.Contracts.Image;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The new CaaS Server Details cmdlet.
	///     This will be used to deploy a new VM.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasServerDetails")]
	[OutputType(typeof (CaasServerDetails))]
	public class NewCaasServerDetailsCmdlet : Cmdlet
	{
		/// <summary>
		///     The VM name
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VM name")]
		public string Name { get; set; }

		/// <summary>
		///     The description of the machine (optional)
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The description of the VM")]
		public string Description { get; set; }

		/// <summary>
		///     The administrator password of the machine
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The VM administrator password")]
		[ValidateLength(8, 50)]
		public string AdminPassword { get; set; }

		/// <summary>
		///     The state of the VM after deployment (powered on or off)
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "Will the VM be started after deployment (true|false)")]
		public bool IsStarted { get; set; }

		/// <summary>
		///     The OS image to use for deployment
		/// </summary>
		[Alias("OsServerImage")]
		[Parameter(Mandatory = true, HelpMessage = "The OS or Customer Server Image to use for deployment")]
		public ImagesWithDiskSpeedImage ServerImage { get; set; }

		/// <summary>
		///     The network to deploy the machine to
		/// </summary>		
        [Parameter(Mandatory = true, ParameterSetName = "MCP1_WithNetwork", HelpMessage = "The network to deploy the machine to.")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     Gets or sets the primary network.
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP2_WithVlan", HelpMessage = "The server's primary vlan")]
        public VlanType PrimaryVlan { get; set; }

        /// <summary>
        ///     The Network Domain deploy the VM
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "MCP2_WithVlan", HelpMessage = "The network domain in which server will be deployed")]
        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = "MCP2_WithPrivateIp", HelpMessage = "The network domain in which server will be deployed")]
        public NetworkDomainType NetworkDomain { get; set; }

        /// <summary>
        ///     The privateIp address of the machine
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "MCP1_WithPrivateIp", HelpMessage = "The network private IP address that will be assigned to the machine.")]
        [Parameter(Mandatory = true, ParameterSetName = "MCP2_WithPrivateIp", HelpMessage = "The network private IP address that will be assigned to the machine.")]
        public string PrivateIp { get; set; }

		/// <summary>
		///     The process record method.
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
                    NetworkDomain = NetworkDomain,
                    PrimaryVlan = PrimaryVlan,
					Image = ServerImage, 
					PrivateIp = PrivateIp
				});
		}
	}
}