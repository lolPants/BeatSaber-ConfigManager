using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BeatSaberConfigManager.Misc
{
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string of dash-separated, or underscore-separated words to a PascalCase string.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>The resulting PascalCase string.</returns>
        public static string ToPascalCase(this string s)
        {
            string[] words = s.Split(new char[3] { '-', '_', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder(words.Sum(x => x.Length));

            foreach (string word in words)
                sb.Append(word[0].ToString().ToUpper() + word.Substring(1));

            return sb.ToString();
        }

        /// <summary>
        /// Removes characters that aren't allowed in a file name.
        /// </summary>
        /// <param name="input">The string to sanitise.</param>
        /// <param name="replacement">[OPTIONAL] String to replace illegal characters with.</param>
        /// <returns>The resulting sanitised string.</returns>
        public static string RemoveIllegalChars(this string input, string replacement = "")
        {
            var regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(input, replacement);
        }

        /// <summary>
        /// Escapes a string for use in a filename.
        /// </summary>
        /// <param name="s">The string to escape.</param>
        /// <returns>The resulting escaped string.</returns>
        public static string PathEscape(this string s)
        {
            // TODO: Add more escape methods
            return s.RemoveIllegalChars()
                .ToPascalCase();
        }
    }
}