using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net.FtpClient;
using System.Text;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Powershell
{
	class GetCaasExportedImageCmdlet
		: PSCmdlet
	{

		private void DownloadFile(FtpClient client, string filePath, int cnt)
		{
			string uploadMessage = string.Format("Uploading {0} to {1}", filePath, client.Host);
			WriteVerbose(uploadMessage);
			var myprogress = new ProgressRecord(cnt, uploadMessage, "Progress:");

			using (FileStream fileStream = File.OpenRead(filePath))
			using (Stream ftpStream = client.OpenWrite(Path.GetFileName(filePath)))
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
