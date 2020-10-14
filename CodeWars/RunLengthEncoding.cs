using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWars
{

    public static class RunLengthEncoding
    {
        #region Other members results
        #endregion

        //My first attempt => not proper (do not cover => aaaabbccca case).
        public static string EncodingTest(string str)
        {
            string result = String.Empty;
            int count = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i - 1] == str[i] && i + 1 != str.Length) count++;
                else
                {
                    if (i + 1 == str.Length) count++;
                    result += count + str[i - 1].ToString();
                    count = 1;
                }
            }
            return result;
        }

        // From https://www.geeksforgeeks.org/run-length-encoding/
        public static string Encoding_geeksforgeeks(string str)
        {
            string result = String.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                // Count occurrences of current character
                int count = 1;
                while (i < str.Length - 1 && str[i] == str[i + 1])
                {
                    count++;
                    i++;
                }
                result += count.ToString() + str[i];
            }
            return result;
        }

        // Repeating from scratch to summarize
        public static string Encoding(string str)
        {
            string result = String.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                int count = 1; 
                while (i < str.Length - 1 && str[i] == str[i + 1])
                {
                    count++;
                    i++;
                }
                result += count.ToString() + str[i];
            }

            return result;
        }


    [TestFixture]
        public class RunLengthEncodingTests
        {
            [Test]
            public void SampleTests()
            {
                Assert.AreEqual("4a2b3c", RunLengthEncoding.Encoding("aaaabbccc"));
                Assert.AreEqual("4a2b3c1a", RunLengthEncoding.Encoding("aaaabbccca"));
            }
        }
    }
}