using System;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Provides read-only access to information about a deployed CaaS image (with labels for its included software).
	/// </summary>
	public interface IImageDetail
	{
		/// <summary>
		///		The image Id.
		/// </summary>
		Guid Id
		{
			get;
		}

		/// <summary>
		///		The image name.
		/// </summary>
		string Name
		{
			get;
		}

		/// <summary>
		///		The image description.
		/// </summary>
		string Description
		{
			get;
		}

		/// <summary>
		///		The specifications of the image's associated virtual machine template.
		/// </summary>
		MachineSpecification MachineSpecification
		{
			get;
		}

		/// <summary>
		///		The UTC date / time that the image was created.
		/// </summary>
		/// <remarks>
		///		Optional, if the image is a custom (user-created) image.
		/// </remarks>
		DateTime? CreatedUtc
		{
			get;
		}

		/// <summary>
		///		The location in which the image exists.
		/// </summary>
		string Location
		{
			get;
		}
	}
}