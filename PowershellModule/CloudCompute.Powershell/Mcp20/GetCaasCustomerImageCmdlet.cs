using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.Image;
using DD.CBU.Compute.Api.Contracts.Network;
using DD.CBU.Compute.Api.Contracts.Network20;
using DD.CBU.Compute.Api.Contracts.Requests.Server20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The get CaaS Customer Images cmdlet.
	/// </summary>
	[Cmdlet(VerbsCommon.Get, "CaasCustomerImage")]
	[OutputType(typeof(CustomerImageType))]
    [OutputType(typeof(ImagesWithDiskSpeedImage), ParameterSetName = new []{ "MCP10" })]
    public class GetCaasCustomerImageCmdlet : PSCmdletCaasWithConnectionBase
	{
		/// <summary>
		///     The network to show the images from
		/// </summary>
		[Obsolete("Use DataCenterId/Location to filter the images")]
        [Parameter(Mandatory = false, ParameterSetName = "MCP10", HelpMessage = "Operating System family to filter")]
        public NetworkWithLocationsNetwork Network { get; set; }

        /// <summary>
        ///     Get a customer image by name
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Name of the Image to filter")]
		public string Name { get; set; }

        /// <summary>
        ///     Get a customer image by location
        /// </summary>        
        [Alias("Location")]
		[Parameter(Mandatory = false, HelpMessage = "Data Center Id/ Location to filter")]
		public string DataCenterId { get; set; }

        /// <summary>
        ///     Get a customer image by imageId
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "ImageId to filter")]
		public Guid ImageId { get; set; }

        /// <summary>
        ///     Get a customer image by OS Id
        /// </summary>        
        [Parameter(Mandatory = false, HelpMessage = "Operating System Id to filter")]
		public string OperatingSystemId { get; set; }

        /// <summary>
        ///     Get a customer image by OS family
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Operating System family to filter")]
		public string OperatingSystemFamily { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = "MCP10", HelpMessage = "Explicitly calling MCP 1.0 Api")]
        public SwitchParameter Mcp1 { get; set; }
		/// <summary>
		///     The process record method.
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{				
				IEnumerable<object> resultlist = GetCustomerImages();

				if (resultlist != null && resultlist.Any())
				{
					switch (resultlist.Count())
					{
						case 0:
							WriteError(
								new ErrorRecord(
									new ItemNotFoundException("This command cannot find a matching object with the given parameters."), 
									"ItemNotFoundException", 
									ErrorCategory.ObjectNotFound, 
									resultlist));
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
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}

						return true;
					});
			}
		}

	    /// <summary>
	    ///     Gets the customer images in the network
	    /// </summary>
	    /// <returns>
	    ///     The images
	    /// </returns>
	    private IEnumerable<object> GetCustomerImages()
	    {
	        if (Mcp1.IsPresent)
	        {
	            if (Network != null && string.IsNullOrEmpty(DataCenterId))
	            {
	                DataCenterId = Network.location;
	            }

	            return
	                Connection.ApiClient.GetCustomerServerImages(ImageId == Guid.Empty ? null : ImageId.ToString(), Name, DataCenterId, OperatingSystemId,
	                    OperatingSystemFamily).Result;
	        }

	        ServerCustomerImageListOptions options = new ServerCustomerImageListOptions
	        {
	            Ids = ImageId == Guid.Empty ? null : new Guid[] {ImageId},
	            DatacenterId = DataCenterId,
	            Name = Name,
	            OperatingSystemId = OperatingSystemId,
	            OperatingSystemFamily = OperatingSystemFamily
	        };

	        return Connection.ApiClient.ServerManagement.ServerImage.GetCustomerImages(options).Result.items;
	    }
	}
}