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

        private static string GoToUntil(string source, string which)
        {
            StringBuilder builder = new StringBuilder();
            foreach(char c in source)
            {
                if (c == which[0])
                {
                    builder.Append(c);
                    return builder.ToString();
                }
                else
                {
                    builder.Append(c);
                }
            }
            return builder.ToString();
        }

        public static List<object> DecodeList(string list)
        {
            // Check string.
            if (String.IsNullOrWhiteSpace(list))
                throw new ArgumentException("list can not be empty.");
            // Check first letter.
            if (list[0] != "l"[0])
                throw new ArgumentException("it does not start a list.");
            // Check last letter.
            if (list[list.Length - 1] != "e"[0])
                throw new ArgumentException("it does not end a list.");

            List<object> data = new List<object>();

            // Scan all the characters.
            int pointer = 1;
            while (pointer < list.Length)
            {
                string current = Convert.ToString(list[pointer]);
                string temp = "";
                switch (current)
                {
                    case "i":
                        // integer.
                        temp = GoToUntil(list.Substring(pointer), "e");
                        data.Add(DecodeInteger(temp));
                        pointer += temp.Length;
                        break;
                    case "l":
                        // nested list.
                        data.Add(DecodeList(list.Substring(pointer)));
                        break;
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "0":
                        // string.
                        string length = GoToUntil(list.Substring(pointer), ":");
                        string self = DecodeString(list.Substring(pointer));
                        data.Add(self);
                        pointer += length.Length + self.Length;
                        break;
                    case "e":
                        // end of object.
                        return data;
                }
                return data;
            }
        }
    }
}
