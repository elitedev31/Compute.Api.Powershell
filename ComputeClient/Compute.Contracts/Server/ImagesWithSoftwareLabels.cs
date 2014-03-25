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
		///		Create a new <see cref="ImagesWithSoftwareLabels"/>.
		/// </summary>
		public ImagesWithSoftwareLabels()
		{
		    Images = new List<ImageDetail>();
		}

	    /// <summary>
	    ///		The image details.
	    /// </summary>
	    [XmlElement("DeployedImageWithSoftwareLabels", Namespace = XmlNamespaceConstants.Server)]
	    public List<ImageDetail> Images { get; private set; }
	}
}
