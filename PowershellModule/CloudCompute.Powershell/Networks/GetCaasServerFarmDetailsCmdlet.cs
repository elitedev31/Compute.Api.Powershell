// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasServerFarmDetailsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get caas server farm details cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The get caas server farm details cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasServerFarmDetails")]
	[OutputType(typeof (ServerFarmDetails))]
	public class GetCaasServerFarmDetailsCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The network to manage the VIP settings
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }


		/// <summary>
		///     The network to manage the VIP settings
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", ValueFromPipeline = true)]
		public ServerFarm ServerFarm { get; set; }


		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				ServerFarmDetails serverfarmdetails =
					Connection.ApiClient.NetworkingLegacy.NetworkVip.GetServerFarmDetails(Network.id, ServerFarm.id).Result;
				if (serverfarmdetails != null)
					WriteObject(serverfarmdetails);
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