// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCaasServerVMwareToolsCmdlet.cs" company="">
//   
// </copyright>
// <summary>
//   The set server state cmdlet.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Management.Automation;
using DD.CBU.Compute.Api.Client;
using DD.CBU.Compute.Api.Contracts.General;
using DD.CBU.Compute.Api.Contracts.Network20;

namespace DD.CBU.Compute.Powershell.Mcp20
{
	/// <summary>
	///     The set server state cmdlet.
	/// </summary>
	[Cmdlet("Update", "CaasCustomerImageMetadata")]
    [OutputType(typeof(ResponseType))]
	public class UpdateCaasCustomerImageMetadataCmdlet : PSCmdletCaasWithConnectionBase
    {

        [Parameter(Mandatory = true, ParameterSetName = "CustomerImage", ValueFromPipeline = true,HelpMessage = "The customer image")]
        public CustomerImageType CustomerImage
	    {	        
	        set { this.ImageId = Guid.Parse(value.id); }
	    }

	    [Parameter(Mandatory = true, ParameterSetName = "CustomerImageId", HelpMessage = "The id of the customer image")]
        public Guid ImageId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The description of the customer image")]
        public string Description { get; set; }


        [Parameter(Mandatory = false, HelpMessage = "The cpu speed of the customer image")]
        public string CpuSpeed { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The id of the operating system")]
        public string OperatingSystemId { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The disk details of the customer image")]
        public ImageMetadataTypeDisk[] DiskSpeeds { get; set; }

        /// <summary>
        ///     The process record method.
        /// </summary>
        protected override void ProcessRecord()
		{
			try
			{
			    ResponseType response =
			        Connection.ApiClient.ServerManagement.ServerImage.EditCustomerImageMetadata(new ImageMetadataType()
			        {
			            id = ImageId.ToString(),
			            description = Description,
			            cpuSpeed = CpuSpeed,
			            operatingSystemId = OperatingSystemId,
			            disk = DiskSpeeds
			        }).Result;

				if (response != null)
					WriteDebug(
						string.Format(
							"{0} resulted in {1} :{2}", 
							response.operation, 
							response.responseCode, 
							response.message));

                WriteObject(response);
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

			base.ProcessRecord();
		}
	}
}