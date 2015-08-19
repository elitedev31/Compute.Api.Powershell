// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasNetworkConfigurationCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The get caas network configuration cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Network;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The get caas network configuration cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasNetworkConfiguration")]
	[OutputType(typeof (NetworkConfigurationType[]))]
	public class GetCaasNetworkConfigurationCmdlet : PsCmdletCaasBase
	{
		/// <summary>
		///     Gets or sets the network.
		/// </summary>
		[Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "Set the server name on CaaS")]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				NetworkConfigurationType network = Connection.ApiClient.NetworkingLegacy.Network.GetNetworkConfig(Network.id).Result;
				if (network != null)
					WriteObject(network);
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