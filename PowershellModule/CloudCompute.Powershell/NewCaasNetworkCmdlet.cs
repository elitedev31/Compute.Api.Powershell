// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasNetworkCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The "New-CaasNetwork" Cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network;
using DD.CBU.Compute.Api.Contracts.Datacenter;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	/// The "New-CaasNetwork" Cmdlet.
	/// </summary>
	/// <remarks>
	/// Deploys a new network in a specified data centre location.
	/// </remarks>
	[Cmdlet(VerbsCommon.New, "CaasNetwork")]
	public class NewCaasNetworkCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "A unique name for the new network to deploy")]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the datacentre.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "DataCentre", 
			HelpMessage = "The data centre location where the network will be deployed.", ValueFromPipeline = true)]
		public DatacenterWithMaintenanceStatusType Datacentre { get; set; }

		/// <summary>
		/// Gets or sets the location.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Location", 
			HelpMessage = "The data centre location where the network will be deployed.", ValueFromPipeline = true)]
		public string Location { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		[Parameter(HelpMessage = "The description of the network")]
		public string Description { get; set; }

		/// <summary>
		/// Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				string location = Location;
				if (ParameterSetName == "DataCentre")
					location = Datacentre.location;
				Status status = Connection.ApiClient.CreateNetwork(Name, location, Description).Result;
				if (status != null)
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
		}
	}
}