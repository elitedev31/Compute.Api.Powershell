using System;
using System.IO;
using System.Management.Automation;
using System.Net.FtpClient;
using DD.CBU.Compute.Api.Contracts.Server;
using ICSharpCode.SharpZipLib.Tar;

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
		private const string temporaryFolder = "%TEMP%\\OVAExtraction";

		[Parameter(ParameterSetName = "IndividualFiles", Mandatory = true, HelpMessage = "The path to the OVF file.")]
		public string Ovf { get; set; }

		[Parameter(ParameterSetName = "IndividualFiles", Mandatory = true, HelpMessage = "The path to the virtual image (e.g. VMDK, VHD) file.")]
		public string VirtualImage { get; set; }

		[Parameter(ParameterSetName = "IndividualFiles", Mandatory = false, HelpMessage = "The path to the manifest file")]
		public string Manifest { get; set; }

		[Parameter(ParameterSetName = "Appliance", Mandatory = true, HelpMessage = "The path to an OVA (Virtual Appliance) file.")]
		public string VirtualAppliance { get; set; }

		/// <summary>
		/// Process the record
		/// </summary>
		protected override void ProcessRecord()
		{
			base.ProcessRecord();

			try
			{
				switch (this.ParameterSetName)
				{
					case "Appliance":
						DecompressAppliance();
						UploadCustomerImage();
						break;
					case "IndividualFiles":
						UploadCustomerImage();
						break;
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
						else //if (e is HttpRequestException)
						{
							ThrowTerminatingError(new ErrorRecord(e, "-1", ErrorCategory.ConnectionError, Connection));
						}
						return true;
					});
			}
		}

		void DecompressAppliance()
		{
			using (var fileStream = File.OpenRead(VirtualAppliance))
			{
				TarArchive appliance = TarArchive.CreateInputTarArchive(fileStream);
				Directory.CreateDirectory(temporaryFolder);
				appliance.ExtractContents(temporaryFolder);
				appliance.Close();
			}
			// Get the extracted contents..
			foreach (string file in Directory.GetFiles(temporaryFolder))
			{
				FileInfo fInfo = new FileInfo(file);
				switch (fInfo.Extension)
				{
					case ".ovf":
						Ovf = file;
						break;
					case ".mf":
						Manifest = file;
						break;
					case ".vmdk":
						VirtualImage = file;
						break;
				}
			}
		}

		/// <summary>
		/// Uploads the customer image to the FTP site.
		/// </summary>
		/// <returns>An asynchronous task.</returns>
		void UploadCustomerImage()
		{
			string host = Connection.ApiClient.FtpHost;

			if (String.IsNullOrEmpty(host))
			{
				WriteError(new ErrorRecord(
					new NotSupportedException("Cannot establish FTP host for non standard API endpoints, use vendor and location parameters to construct a connection."),
 					"invalid-ftp",
					ErrorCategory.InvalidOperation,
					host
				));
				return;
			}

			FtpClient client = new FtpClient
			{
				Host = host,
				EncryptionMode = FtpEncryptionMode.Explicit,
				DataConnectionEncryption = true,
				Credentials = Connection.ApiClient.WebApi.Credentials.GetCredential(new Uri(String.Format("ftp://{0}", host)), "Basic" )
			};

			client.Connect();

			// TODO : Support for building OVF on the fly.
			UploadFile(client, Ovf, 1);
			// TODO : Support for building manifest on the fly.
			UploadFile(client, Manifest, 2);
			UploadFile(client, VirtualImage, 3);

			client.Disconnect();
		}

		private void UploadFile(FtpClient client, string filePath, int cnt)
		{
			string uploadMessage = String.Format("Uploading {0} to {1}", filePath, client.Host);
			WriteVerbose(uploadMessage);
			ProgressRecord myprogress = new ProgressRecord(cnt, uploadMessage, "Progress:");

			using (var fileStream = File.OpenRead(filePath))
			using (var ftpStream = client.OpenWrite(Path.GetFileName(filePath)))
			{
				var buffer = new byte[8 * 1024];
				int count;
				long total = 0;
				long size = fileStream.Length;
				while ((count = fileStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					ftpStream.Write(buffer, 0, count);
					myprogress.PercentComplete = (int)(total / size) * 100;
					WriteProgress(myprogress);
					total += count;
				}
			}
			myprogress.PercentComplete = 100;
			myprogress.StatusDescription = "Complete";
			WriteProgress(myprogress);
		}
	}
}