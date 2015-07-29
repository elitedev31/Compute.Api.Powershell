namespace DD.CBU.Compute.Api.Client.Exceptions
{
	using System;
	using System.Runtime.Serialization;

	/// <summary>
	/// The api host not found exception.
	/// </summary>
	[Serializable]
	public class ApiHostNotFoundException : ComputeApiException
	{
		/// <summary>
		/// The message.
		/// </summary>
		const string message = "Known Cloud API hostname not found with this vendor and region combination.";

		/// <summary>
		/// Gets or sets the vendor.
		/// </summary>
		public KnownApiVendor Vendor { get; set; }

		/// <summary>
		/// Gets or sets the region.
		/// </summary>
		public KnownApiRegion Region { get; set; }
		/// <summary>
		/// Initialises a new instance of the <see cref="ApiHostNotFoundException"/> class.
		/// </summary>
		/// <param name="vendor">
		/// The vendor.
		/// </param>
		/// <param name="region">
		/// The region.
		/// </param>
		public ApiHostNotFoundException(KnownApiVendor vendor, KnownApiRegion region)
			: base(ComputeApiError.BadRequest, message)
		{
			Vendor = vendor;
			Region = region;
		}

		/// <summary>
		/// Initialises a new instance of the <see cref="ApiHostNotFoundException"/> class.
		/// </summary>
		/// <param name="info">
		/// The info.
		/// </param>
		/// <param name="context">
		/// The context.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// </exception>
		protected ApiHostNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			Vendor = (KnownApiVendor)info.GetValue("Vendor", typeof(KnownApiVendor));
			Region = (KnownApiRegion)info.GetValue("Region", typeof(KnownApiRegion));
		}
		
		/// <summary>
		/// Get exception data for serialisation.
		/// </summary>
		/// <param name="info">
		/// A <see cref="SerializationInfo"/> serialisation data store that will hold the serialized exception data.
		/// </param>
		/// <param name="context">
		/// A <see cref="StreamingContext"/> value that indicates the source of the serialised data.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// The <paramref name="info"/> parameter is null.
		/// </exception>
		/// <exception cref="SerializationException">
		/// The class name is <c>null</c> or <see cref="Exception.HResult"/> is zero (0).
		/// </exception>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
				throw new ArgumentNullException("info");

			base.GetObjectData(info, context);
			info.AddValue("Vendor", Vendor);
			info.AddValue("Region", Region);
		}

		/// <summary>
		/// Gets the message.
		/// </summary>
		public override string Message
		{
			get
			{
				return String.Format("{0}, Region:{1}, Vendor{2}", base.Message, Region.ToString(), Vendor.ToString());
			}
		}
	}
}
