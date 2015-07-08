using System.Net;
namespace Compute.Client.UnitTests
{
	public class RequestFileResponseType
	{
		public static RequestFileResponseType AsGoodResponse(string responseFile)
		{
			return new RequestFileResponseType()
			{
				ResponseFile = responseFile,
				Status = HttpStatusCode.OK
			};
		}
		public string ResponseFile { get; set; }
		public HttpStatusCode Status { get; set; }
	}
}
