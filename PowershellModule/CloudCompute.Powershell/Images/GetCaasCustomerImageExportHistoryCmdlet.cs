// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCaasCustomerImageExportHistoryCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The Get Customer Image Imports cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Image;
using DD.CBU.Compute.Api.Contracts.Requests.Server20;
using DD.CBU.Compute.Api.Contracts.Image20;
using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Powershell
{
	/// <summary>
	///     The Get Customer Image Imports cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasCustomerImageExportHistory")]
	[OutputType(typeof (ImageExportRecord))]
	public class GetCaasCustomerImageExportHistoryCmdlet : PsCmdletCaasPagedWithConnectionBase
    {
        /// <summary>
        /// Image Export ID
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage ="Image Export ID")]
        public string ImageExportId { get; set; }

        /// <summary>
        /// Image ID
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Image ID")]
        public string ImageId { get; set; }

        /// <summary>
        /// Datacenter ID
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Datacenter ID")]
        public string DatacenterId { get; set; }

        /// <summary>
        /// Image name
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Image Name")]
        public string ImageName { get; set; }

        /// <summary>
        /// Ovf Package prefix
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "OVF package prefix")]
        public string OvfPackagePrefix { get; set; }

        /// <summary>
        /// Start time
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Start time")]
        public DateTimeOffset? StartTime { get; set; }

        /// <summary>
        /// End time
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "End time")]
        public DateTimeOffset? EndTime { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "user Name")]
        public string UserName { get; set; }


        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
                var option = new CustomerImageExportHistoryOptions
                {
                    ImageExportId = ImageExportId,
                    ImageId = ImageId,
                    DatacenterId = DatacenterId,
                    ImageName = ImageName,
                    OvfPackagePrefix = OvfPackagePrefix,
                    StartTime = StartTime,
                    EndTime = EndTime,
                    UserName = UserName
                };
                

                IEnumerable<HistoricalImageExportType> resultlist = Connection.ApiClient.ServerManagement.ServerImage.GetCustomerImagesExportHistory(option, PageableRequest).Result.items;
                if (resultlist != null && resultlist.Any())
				{
					switch (resultlist.Count())
					{
						case 0:
							WriteError(
								new ErrorRecord(
									new ItemNotFoundException(
										"This command cannot find a matching object with the given parameters."
										), "ItemNotFoundException", ErrorCategory.ObjectNotFound, resultlist));
							break;					
						default:
							WriteObject(resultlist, true);
							break;
					}
				}
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