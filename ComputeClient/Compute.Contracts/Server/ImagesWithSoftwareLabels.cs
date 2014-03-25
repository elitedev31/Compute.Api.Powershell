using System.Collections.Generic;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		An XML-serialisable data contract that represents a container details about multiple deployed CaaS software image.
	/// </summary>
	[XmlRoot("DeployedImagesWithSoftwareLabels", Namespace = XmlNamespaceConstants.Server)]
	public class ImagesWithSoftwareLabels
	{
		/// <summary>
		///		The image details.
		/// </summary>
		readonly List<ImageDetail> _images = new List<ImageDetail>();

		/// <summary>
		///		Create a new <see cref="ImagesWithSoftwareLabels"/>.
		/// </summary>
		public ImagesWithSoftwareLabels()
		{
		}

		/// <summary>
		///		The image details.
		/// </summary>
		[XmlElement("DeployedImageWithSoftwareLabels", Namespace = XmlNamespaceConstants.Server)]
		public List<ImageDetail> Images
		{
			get
			{
				return _images;
			}
		}
	}
}
