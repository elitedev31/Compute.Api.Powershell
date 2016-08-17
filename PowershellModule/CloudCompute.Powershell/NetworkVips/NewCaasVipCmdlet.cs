// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasVipCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS VIP Real cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using System.Net;
using System.Text.RegularExpressions;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Vip;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The new CaaS VIP Real cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.New, "CaasVip")]
	[OutputType(typeof (Vip))]
	public class NewCaasVipCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The network to manage the VIP settings
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", 
			ValueFromPipelineByPropertyName = true)]
		public NetworkWithLocationsNetwork Network { get; set; }


		/// <summary>
		///     The name for the VIP
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The name for the VIP")]
		public string Name { get; set; }


		/// <summary>
		///     The server farm for the VIP
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The server farm for the VIP", ValueFromPipeline = true, 
			ParameterSetName = "ServerFarm")]
		public ServerFarm ServerFarm { get; set; }


		/// <summary>
		///     The persistence profile for the VIP
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The persistence profile for the VIP", ValueFromPipeline = true, 
			ParameterSetName = "PersistenceProfile")]
		public PersistenceProfile PersistenceProfile { get; set; }


		/// <summary>
		///     The port to VIP. valid range 1-65535
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The port to VIP. valid range 1-65535")]
		[ValidateRange(1, 65535)]
		public int Port { get; set; }


		/// <summary>
		///     The protocol for the VIP. valid TCP or UDP
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The protocol for the VIP. valid TCP or UDP")]
		public VipProtocol Protocol { get; set; }


		/// <summary>
		///     The Vip status
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The Vip status")]
		public bool InService { get; set; }

		/// <summary>
		///     The vip reply to ICMP status
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The vip reply to ICMP status")]
		public bool ReplyToIcmp { get; set; }

		/// <summary>
		///     The Vip status
		/// </summary>
		[Parameter(Mandatory = false, 
			HelpMessage =
				"The Vip IP address, If you do not supply an IP address, the next available public IP address from your network's public IP block(s)  will be assigned."
			)]
		public IPAddress IpAddress { get; set; }

		/// <summary>
		///     The network to add the public ip addresses
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Return the RealServer object")]
		public SwitchParameter PassThru { get; set; }

		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				string targetid = string.Empty;
				VipTargetType targetType;
				string targetName = string.Empty;
				if (ParameterSetName.Equals("ServerFarm"))
				{
					targetid = ServerFarm.id;
					targetType = VipTargetType.SERVER_FARM;
					targetName = ServerFarm.name;
				}
				else
				{
					targetid = PersistenceProfile.id;
					targetType = VipTargetType.PERSISTENCE_PROFILE;
					targetName = PersistenceProfile.name;
				}

				string ipAddress = IpAddress != null ? IpAddress.ToString() : string.Empty;


				Status status =
					Connection.ApiClient.NetworkingLegacy.NetworkVip.CreateVip(Network.id, Name, Port, Protocol, targetType, targetid, 
						ReplyToIcmp, InService, 
						ipAddress).Result;
				if (status != null && PassThru.IsPresent)
				{
					// Regex to extract the Id from the status result detail: Real-Server (id:b1a3aea6-37) created
					var regexObj = new Regex(@"\x28id\x3A([-\w]*)\x29");
					Match match = regexObj.Match(status.resultDetail);
					if (match.Success && match.Groups.Count > 1)
					{
						var vip = new Vip
						{
							id = match.Groups[1].Value, 
							name = Name, 
							port = Port, 
							protocol = Protocol, 
							vipTargetId = targetid, 
							vipTargetType = targetType, 
							ipAddress = ipAddress, 
							replyToIcmp = ReplyToIcmp, 
							vipTargetName = targetName, 
							inService = InService, 
						};
						WriteObject(vip);
					}
					else
					{
						WriteError(new ErrorRecord(new CloudComputePsException("object Id not returned from API"), "-1", 
							ErrorCategory.InvalidData, status));
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