// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasServerNic.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS Virtual Machine cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Client.Network20;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The new CaaS Server NIC CmdLet
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasServerNic")]
	[OutputType(typeof (ResponseType))]
	public class NewCaasServerNicCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The Virtual Server
		/// </summary>
		[Parameter(Mandatory = false, ValueFromPipeline = true, 
			HelpMessage = "The server on which the nic will be deployed")]
		public ServerType Server { get; set; }

		/// <summary>
		///     Gets or sets the server id.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server ID")]
		public string ServerId { get; set; }

		/// <summary>
		///     Gets or sets the primary network.
		/// </summary>
		[Parameter(Mandatory = true, ParameterSetName = "Vlan", HelpMessage = "The server's primary network")]
		public VlanType Vlan { get; set; }

		/// <summary>
		///     Gets or sets the primary private IP.
		/// </summary>
		[Parameter(Mandatory = false, ParameterSetName = "PrivateIp", 
			HelpMessage = "The private network private IP address that will be assigned to the machine.")]
		public string PrimaryPrivateIp { get; set; }

		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			ResponseType response = null;
			base.ProcessRecord();
			try
			{
				var nic = new AddNicType
				{
					serverId = Server != null ? Server.id : ServerId, 
					PrivateIPv4 = PrimaryPrivateIp, 
					VLANId = Vlan.id
				};

				response = Connection.ApiClient.AddNicToServer(nic).Result;
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