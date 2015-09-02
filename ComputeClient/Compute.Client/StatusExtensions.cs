using DD.CBU.Compute.Api.Contracts.General;

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>	The status extensions. </summary>
	public static class StatusExtensions
	{
		/// <summary>	The Status extension method that query if 'status' is successful. </summary>
		/// <param name="status">	The status to act on. </param>
		/// <returns>	true if successful, false if not. </returns>
		public static bool IsSuccessful(this Status status)
		{
			return status.result == "SUCCESS";
		}
	}
}
