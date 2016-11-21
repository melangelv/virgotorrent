using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virgo
{
    /// <summary>
    /// Does Bencoding/Bdecoding.
    /// </summary>
    public class BCoder
    {
        public static int DecodeInteger(String number)
        {
            // Check for string.
            if (number == null)
                throw new ArgumentException("number can not be null.");
            if (String.IsNullOrWhiteSpace(number))
                throw new ArgumentException("number can not be empty.");
            // Must start with an "i".
            if (number[0] != "i"[0])
                throw new ArgumentException("number has to start with an \"i\".");
            // Must end with an "e".
            if (number[number.Length - 1] != "e"[0])
                throw new ArgumentException("number has to end with an \"e\".");
            if (number.Length < 3)
                throw new ArgumentException("number yields empty value.");
            // Extract the contained number. (skip i and e.)
            String contents = number.Substring(1, number.Length - 2);
            // Check for minus-only.
            if (contents.Equals("-"))
                throw new ArgumentException("number can not be just a minus.");
            if (contents.Equals("-0"))
                throw new ArgumentException("number can not be negative zero.");
            if (contents[0] == "0"[0] && contents.Length > 1)
                throw new ArgumentException("number can not start with zero.");
            if (String.IsNullOrWhiteSpace(contents))
                throw new ArgumentException("number yields empty value.");

            // Convert it to integer.
            int result = 0;
            bool succeeded = int.TryParse(contents, out result);
            if (!succeeded)
                throw new ArgumentException("it is not a number.");
            return result;
        }

        public static string EncodeInteger(int number)
        {
            return "i" + Convert.ToString(number) + "e";
        }

        public static string DecodeString(string content)
        {
            // Check string.
            if (content == null)
                throw new ArgumentException("string is null.");

            // Try to get the length of string.
            string len = content.Split(":"[0])[0];
            int length = 0;
            bool islen = int.TryParse(len, out length);

            if (!islen)
                throw new ArgumentException("string does not length-prefixed.");

            string decodedString = new string(content.Skip(len.Length + 1).Take(length).ToArray());

            if (decodedString.Length != length)
                throw new ArgumentException("string length overshooted.");

            return decodedString;
        }

        public static string EncodeString(string content)
        {
            // Check string.
            if (String.IsNullOrWhiteSpace(content))
                throw new ArgumentException("content can not be empty.");

            StringBuilder builder = new StringBuilder();
            builder.Append(Convert.ToString(content.Length));
            builder.Append(":");
            builder.Append(content);

            return builder.ToString();
        }
    }
}
