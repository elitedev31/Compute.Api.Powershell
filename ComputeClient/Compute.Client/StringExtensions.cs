// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="">
//   
// </copyright>
// <summary>
//   The string extensions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;

namespace DD.CBU.Compute.Api.Client
{
	/// <summary>
	/// The string extensions.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// The ci.
		/// </summary>
		private static readonly CultureInfo ci = new CultureInfo("en-US");

		/// <summary>
		/// The to query string.
		/// </summary>
		/// <param name="collection">
		/// The collection.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		public static string ToQueryString(this Dictionary<string, string> collection)
		{
			if (collection != null)
			{
				return string.Join("&", 
					collection.Keys.Where(key => !string.IsNullOrWhiteSpace(collection[key]))
						.Select(key => string.Format("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(collection[key]))));
			}

			return string.Empty;
		}

		// Convert all first latter
		/// <summary>
		/// The to title case.
		/// </summary>
		/// <param name="str">
		/// The str.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		public static string ToTitleCase(this string str)
		{
			if (string.IsNullOrEmpty(str))
				return str;
			str = str.ToLower();
			string[] strArray = str.Split(' ');
			if (strArray.Length > 1)
			{
				strArray[0] = ci.TextInfo.ToTitleCase(strArray[0]);
				return string.Join(" ", strArray);
			}

			return ci.TextInfo.ToTitleCase(str);
		}

		/// <summary>
		/// The to title case.
		/// </summary>
		/// <param name="str">
		/// The str.
		/// </param>
		/// <param name="tcase">
		/// The tcase.
		/// </param>
		/// <returns>
		/// The <see cref="string"/>.
		/// </returns>
		public static string ToTitleCase(this string str, TitleCase tcase)
		{
			if (string.IsNullOrEmpty(str))
				return str;
			str = str.ToLower();
			switch (tcase)
			{
				case TitleCase.First:
					string[] strArray = str.Split(' ');
					if (strArray.Length > 1)
					{
						strArray[0] = ci.TextInfo.ToTitleCase(strArray[0]);
						return string.Join(" ", strArray);
					}

					break;
				case TitleCase.All:
					return ci.TextInfo.ToTitleCase(str);
				default:
					break;
			}

			return ci.TextInfo.ToTitleCase(str);
		}
	}

	/// <summary>
	/// The title case.
	/// </summary>
	public enum TitleCase
	{
		/// <summary>
		/// The first.
		/// </summary>
		First, 

		/// <summary>
		/// The all.
		/// </summary>
		All
	}
}