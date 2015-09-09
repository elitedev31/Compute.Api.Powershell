// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NewCaasProbeCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The new CaaS VIP Real cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
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
	[Cmdlet(VerbsCommon.New, "CaasProbe")]
	[OutputType(typeof (Probe))]
	public class NewCaasProbeCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The network to manage the VIP settings
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The network to manage the VIP settings", ValueFromPipeline = true)]
		public NetworkWithLocationsNetwork Network { get; set; }

		/// <summary>
		///     The name for the real server
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The name for the probe")]
		public string Name { get; set; }

		/// <summary>
		///     Gets or sets the type.
		/// </summary>
		[Parameter(Mandatory = true, HelpMessage = "The type of probe. One of (TCP, UDP, HTTP, HTTPS, ICMP)")]
		public ProbeType Type { get; set; }

		/// <summary>
		///     Gets or sets the port.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The port to probe. valid range 1-65535")]
		[ValidateRange(1, 65535)]
		public int Port { get; set; }

		/// <summary>
		///     Gets or sets the probe interval seconds.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "The interval to probe in seconds. valid range 15-65535")]
		[ValidateRange(15, 65535)]
		[PSDefaultValue(Value = 120, Help = "default value 120")]
		public int ProbeIntervalSeconds { get; set; }

		/// <summary>
		///     The error count before server fail.
		/// </summary>
		/// <remarks>
		/// </remarks>
		[Parameter(Mandatory = false, 
			HelpMessage = "The number of errors before declaring a server failure. valid range 1-65535")]
		[ValidateRange(1, 65535)]
		[PSDefaultValue(Value = 3, Help = "default value 3")]
		public int ErrorCountBeforeServerFail { get; set; }


		/// <summary>
		///     The success count before server enable.
		/// </summary>
		/// <remarks>
		/// </remarks>
		[Parameter(Mandatory = false, 
			HelpMessage = "The number of sucesses before reenable a failed server. valid range 1-65535")]
		[ValidateRange(1, 65535)]
		[PSDefaultValue(Value = 3, Help = "default value 3")]
		public int SuccessCountBeforeServerEnable { get; set; }


		/// <summary>
		///     The failed probe interval seconds.
		/// </summary>
		/// <remarks>
		/// </remarks>
		[Parameter(Mandatory = false, 
			HelpMessage = "The number of sucesses before reenable a failed server. valid range 15-65535")]
		[ValidateRange(15, 65535)]
		[PSDefaultValue(Value = 300, Help = "default value 300")]
		public int FailedProbeIntervalSeconds { get; set; }


		/// <summary>
		///     The max reply wait seconds.
		/// </summary>
		/// <remarks>
		/// </remarks>
		[Parameter(Mandatory = false, 
			HelpMessage = "The max number of seconds to wait for a response from a server. valid range 2-65535")]
		[ValidateRange(2, 65535)]
		[PSDefaultValue(Value = 10, Help = "default value 10")]
		public int MaxReplyWaitSeconds { get; set; }


		/// <summary>
		///     The request method.
		/// </summary>
		/// <remarks>
		/// </remarks>
		[Parameter(Mandatory = false, 
			HelpMessage = "Required if type is HTTP/HTTPS. The request method to be used for the request Url ")]
		[PSDefaultValue(Value = ProbeRequestMethod.GET, Help = "default GET")]
		public ProbeRequestMethod RequestMethod { get; set; }


		/// <summary>
		///     The status code upper bound.
		/// </summary>
		/// <remarks>
		/// </remarks>
		[Parameter(Mandatory = false, HelpMessage = "The lower bound of the HTTP status code to be matched. valid range 0-999"
			)]
		[ValidateRange(0, 999)]
		[PSDefaultValue(Value = 200, Help = "default value 200")]
		public int StatusCodeUpperBound { get; set; }

		/// <summary>
		///     The status code lower bound.
		/// </summary>
		/// <remarks>
		/// </remarks>
		[Parameter(Mandatory = false, HelpMessage = "The upper bound of the HTTP status code to be matched. valid range 0-999"
			)]
		[ValidateRange(0, 999)]
		[PSDefaultValue(Value = 200, Help = "default value 200")]
		public int StatusCodeLowerBound { get; set; }

		/// <summary>
		///     Gets or sets the request url.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Applicable if type is HTTP/HTTPS. The Url to be requested ")]
		public string RequestUrl { get; set; }


		/// <summary>
		///     Gets or sets the match content.
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Applicable if type is HTTP/HTTPS. The content to be matched.")]
		public string MatchContent { get; set; }

		/// <summary>
		///     The network to add the public ip addresses
		/// </summary>
		[Parameter(Mandatory = false, HelpMessage = "Return the Probe object")]
		public SwitchParameter PassThru { get; set; }


		/// <summary>
		///     The process record.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();
			try
			{
				Status status =
					Connection.ApiClient.NetworkingLegacy.NetworkVip.CreateProbe(Network.id, Name, Type, Port, ProbeIntervalSeconds, 
						ErrorCountBeforeServerFail, 
						SuccessCountBeforeServerEnable, FailedProbeIntervalSeconds, MaxReplyWaitSeconds, StatusCodeLowerBound, 
						StatusCodeUpperBound, RequestMethod, RequestUrl, MatchContent).Result;
				if (status != null && PassThru.IsPresent)
				{
					// Regex to extract the Id from the status result detail: Real-Server (id:b1a3aea6-37) created
					var regexObj = new Regex(@"\x28id\x3A([-\w]*)\x29");
					Match match = regexObj.Match(status.resultDetail);
					if (match.Success && match.Groups.Count > 1)
					{
						var probe = new Probe
						{
							id = match.Groups[1].Value, 
							name = Name, 
							type = Type, 
							port = Port, 
							probeIntervalSeconds = ProbeIntervalSeconds, 
							errorCountBeforeServerFail = ErrorCountBeforeServerFail, 
							successCountBeforeServerEnable = SuccessCountBeforeServerEnable, 
							failedProbeIntervalSeconds = FailedProbeIntervalSeconds, 
							maxReplyWaitSeconds = MaxReplyWaitSeconds
						};
						if (Type.Equals(ProbeType.HTTP) || Type.Equals(ProbeType.HTTPS))
						{
							probe.statusCodeRange = new[]
							{
								new ProbeStatusCodeRange {lowerBound = StatusCodeLowerBound, upperBound = StatusCodeUpperBound}
							};
							probe.requestMethod = RequestMethod;
							probe.requestUrl = RequestUrl;
							probe.matchContent = MatchContent;
						}

						WriteObject(probe);
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