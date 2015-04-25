// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpContentExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   Extension methods for working with <see cref="HttpContent" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	/// Extension methods for working with <see cref="HttpContent"/>.
	/// </summary>
	public static class HttpContentExtensions
	{
		/// <summary>
		/// XML-deserialise the specified content
		/// </summary>
		/// <typeparam name="T">
		/// The XML-serialisable type into which the content should be deserialised.
		/// </typeparam>
		/// <param name="content">
		/// The <see cref="HttpContent"/> to deserialise.
		/// </param>
		/// <returns>
		/// An instance of <typeparamref name="T"/> representing the deserialised content.
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="content"/> is <c>null</c>.
		/// </exception>
		public static Task<T> XmlDeserializeAsync<T>(this HttpContent content)
		{
			if (content == null)
				throw new ArgumentNullException("content");

			return content.ReadAsAsync<T>(
				new[]
				{
					new XmlMediaTypeFormatter
					{
						UseXmlSerializer = true
					}
				}
				);
		}
	}
}