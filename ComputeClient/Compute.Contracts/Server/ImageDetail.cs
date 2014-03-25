using System;
using System.Xml.Serialization;

namespace DD.CBU.Compute.Api.Contracts.Server
{
	/// <summary>
	///		Represents detailed information about a deployed CaaS image (with labels for its included software).
	/// </summary>
	[XmlRoot("DeployedImageWithSoftwareLabels", Namespace = XmlNamespaceConstants.Server)]
	public class ImageDetail
		: IImageDetail
	{
		/// <summary>
		///		Create a new <see cref="ImageDetail"/>.
		/// </summary>
		public ImageDetail()
		{
		}

		/// <summary>
		///		The image Id.
		/// </summary>
		[XmlElement("id", Namespace = XmlNamespaceConstants.Server)]
		public Guid Id
		{
			get;
			set;
		}

		/// <summary>
		///		The image name.
		/// </summary>
		[XmlElement("name", Namespace = XmlNamespaceConstants.Server)]
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		///		The image description.
		/// </summary>
		[XmlElement("description", Namespace = XmlNamespaceConstants.Server)]
		public string Description
		{
			get;
			set;
		}

		/// <summary>
		///		The specifications of the image's associated virtual machine template.
		/// </summary>
		[XmlElement("machineSpecification", Namespace = XmlNamespaceConstants.Server)]
		public MachineSpecification MachineSpecification
		{
			get;
			set;
		}

		/// <summary>
		///		The UTC date / time that the image was created.
		/// </summary>
		/// <remarks>
		///		Optional, if the image is a custom (user-created) image.
		/// </remarks>
		[XmlElement("deployedTime", Namespace = XmlNamespaceConstants.Server)]
		public DateTime? CreatedUtc
		{
			get;
			set;
		}

		/// <summary>
		///		The location in which the image exists.
		/// </summary>
		[XmlElement("location", Namespace = XmlNamespaceConstants.Server)]
		public string Location
		{
			get;
			set;
		}
	}
}
