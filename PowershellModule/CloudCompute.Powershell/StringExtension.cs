namespace DD.CBU.Compute.Powershell
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Extension methods for strings
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Truncate the string to the specified number of characters.
        /// </summary>
        /// <param name="toTruncate">
        /// The string to truncate.
        /// </param>
        /// <param name="maxLength">
        /// The maximum number of characters that the string should contain.
        /// </param>
        /// <returns>
        /// The truncated string, unless the string is already less than or equal to the specified maximum length (in which case the original string is returned).
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="toTruncate"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="maxLength"/> is less than 0.
        /// </exception>
        public static string Truncate(this string toTruncate, int maxLength)
        {
            if (toTruncate == null)
                throw new ArgumentNullException("toTruncate");

            if (maxLength < 0)
                throw new ArgumentOutOfRangeException("maxLength", "Maximum string length cannot be less than 0.");

            if (maxLength == 0)
                return string.Empty;

            if (toTruncate.Length <= maxLength)
                return toTruncate;

            return toTruncate.Substring(0, maxLength);
        }

        /// <summary>
        /// Splits the string by the given size
        /// </summary>
        /// <param name="text">Input string</param>
        /// <param name="length">Length to be split by</param>
        /// <returns>Parts of the Input String</returns>
        public static IEnumerable<string> SplitByLength(this string text, int length)
        {
            int index = 0;
            if (text.Length == 0)
                yield break;

            while (index < text.Length)
            {
                // take the min of remain text and the length
                int charCount = Math.Min(length, text.Length - index);
                yield return text.Substring(index, charCount);
                index += length;
            }
        }

        /// <summary>
        /// Converts the supplied text to user friendly text.
        /// </summary>
        /// <param name="text">
        /// The text to convert.
        /// </param>
        /// <returns>
        /// The converted text.
        /// </returns>
        public static string ToFriendlyText(this string text)
        {
            return ConvertText(text, false);
        }

        /// <summary>
        /// Converts the supplied text to camel case text.
        /// </summary>
        /// <param name="text">
        /// The text to convert.
        /// </param>
        /// <returns>
        /// The converted text.
        /// </returns>
        public static string ToCamelCase(this string text)
        {
            return ConvertText(text, true);
        }

        public static string ReplaceFirst(this string text, string search, string replace)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            if (string.IsNullOrWhiteSpace(search))
            {
                throw new ArgumentNullException(nameof(search));
            }

            if (string.IsNullOrWhiteSpace(replace))
            {
                throw new ArgumentNullException(nameof(replace));
            }

            int pos = text.IndexOf(search, StringComparison.InvariantCultureIgnoreCase);
            if (pos < 0)
            {
                return text;
            }

            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        /// <summary>
        /// Converts the supplied text to user friendly camel-case text.
        /// </summary>
        /// <param name="text">
        /// The text to convert.
        /// </param>
        /// <param name="removeSpaces">
        /// A value indicating whether spaces should be removed.
        /// </param>
        /// <returns>
        /// The converted text.
        /// </returns>
        private static string ConvertText(string text, bool removeSpaces)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            var result = new StringBuilder(text.Length);
            var previous = ' ';

            for (var i = 0; i < text.Length; i++)
            {
                var character = text[i];

                if (character == '_')
                    character = ' ';

                if (previous == ' ')
                    character = character.ToString().ToUpper()[0];
                else
                    character = character.ToString().ToLower()[0];

                if (character != ' ' || !removeSpaces)
                    result.Append(character);

                previous = character;
            }

            return result.ToString();
        }
    }
}