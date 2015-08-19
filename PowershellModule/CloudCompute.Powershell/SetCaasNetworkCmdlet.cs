// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SetCaasNetworkCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set caas network cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The set caas network cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Set, "CaasNetwork")]
	public class SetCaasNetworkCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets the network.
		/// </summary>
		[Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Set the server name on CaaS")]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     Gets or sets the name.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "NetworkName", HelpMessage = "Set new name for the network")]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the description.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "NetworkName", 
			HelpMessage = "Set the new description for the network")]
		public string Description { get; set; }

		/// <summary>
		///     Gets or sets a value indicating whether multicast.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "Multicast", HelpMessage = "Enable/Disable multicast on the network")
		]
		public bool Multicast { get; set; }

		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				Status status = null;
				switch (ParameterSetName)
				{
					case "Multicast":
						status = Connection.ApiClient.NetworkingLegacy.Network.SetNetworkMulticast(Network.id, Multicast).Result;
						break;
					default:
						status = Connection.ApiClient.NetworkingLegacy.Network.ModifyNetwork(Network.id, Name, Description).Result;
						break;
				}

				status = Connection.ApiClient.NetworkingLegacy.Network.ModifyNetwork(Network.id, Name, Description).Result;
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