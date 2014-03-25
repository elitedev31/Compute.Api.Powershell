using System;

namespace DD.CBU.Compute.Api.Contracts.Server
{	
	/// <summary>
	///		Provides read-only access to detailed information for a user-created CaaS image (with labels for its included software).
	/// </summary>
	public interface ICustomImageDetail
	{
		/// <summary>
		///		The Id of the server from which the image was created.
		/// </summary>
		Guid? SourceServerId
		{
			get;
		}
	}
}