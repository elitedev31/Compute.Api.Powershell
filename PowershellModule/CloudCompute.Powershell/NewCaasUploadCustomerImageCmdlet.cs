using System;
using System.IO;
using System.Management.Automation;
using System.Net.FtpClient;
using DD.CBU.Compute.Api.Contracts.Server;

namespace DD.CBU.Compute.Powershell
{
	using Api.Client;

	/// <summary>
	///	The "New-CaasUploadCustomerImage" Cmdlet.
	/// </summary>
	/// <remarks>
	///	Upload a new customer image.
	/// </remarks>
	[Cmdlet(VerbsCommon.New, "CaasUploadCustomerImage")]
	[OutputType(typeof(ServerImageWithStateType))]
	public class NewCaasUploadCustomerImageCmdlet : PsCmdletCaasBase
	{
		[Parameter(Mandatory = true, HelpMessage = "The path to the OVF file.")]
		public string OvfPath { get; set; }

		[Parameter(Mandatory = true, HelpMessage = "The path to the virtual image (e.g. VMDK, VHD) file.")]
		public string VirtualImagePath { get; set; }

		/// <summary>
		/// Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				UploadCustomerImage();
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
						else //if (e is HttpRequestException)
						{
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}
						return true;
					});
			}
		}

		/// <summary>
		/// Uploads the customer image to the FTP site.
		/// </summary>
		/// <returns>An asynchronous task.</returns>
		void UploadCustomerImage()
		{
			string host = String.Format("ftps-{0}.cloud-vpn.net", Connection.ApiClient.WebApi.Region);
			FtpClient client = new FtpClient
			{
				Host = host,
				EncryptionMode = FtpEncryptionMode.Implicit,
				DataConnectionEncryption = true,
				Credentials = Connection.ApiClient.WebApi.Credentials.GetCredential(new Uri(String.Format("ftps://{0}", host)), "Basic" )
			};

			// TODO: get credentials from connection object.

			client.Connect();

			using (var fileStream = File.OpenRead(OvfPath))
			using (var ftpStream = client.OpenWrite(Path.GetFileName(OvfPath)))
			{
				var buffer = new byte[8 * 1024];
				int count;
				while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					ftpStream.Write(buffer, 0, count);
				}
			}

			using (var fileStream = File.OpenRead(VirtualImagePath))
			using (var ftpStream = client.OpenWrite(Path.GetFileName(VirtualImagePath)))
			{
				var buffer = new byte[8 * 1024];
				int count;
				while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					ftpStream.Write(buffer, 0, count);
				}
			}

			client.Disconnect();
		}
	}
}