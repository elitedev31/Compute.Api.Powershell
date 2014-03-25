using System;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Represents detailed information for a user-created CaaS image (with labels for its included software).
	/// </summary>
	[XmlRoot("ImageWithSoftwareLabels", Namespace = XmlNamespaceConstants.Server)]
	public class CustomImageDetail
		: ImageDetail, ICustomImageDetail
	{
		/// <summary>
		///		Create a new <see cref="CustomImageDetail"/>.
		/// </summary>
		public CustomImageDetail()
		{
		}

		/// <summary>
		///		The Id of the server from which the image was created.
		/// </summary>
		[XmlElement("sourceServerId", Namespace = XmlNamespaceConstants.Server)]
		public Guid? SourceServerId
		{
			get;
			set;
		}

		// TODO: Capture custom image status.
	}
}
