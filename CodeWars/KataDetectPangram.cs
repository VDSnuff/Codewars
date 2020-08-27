using NUnit.Framework;
using System;
using System.Linq;

namespace CodeWars
{

    public static class KataDetectPangram
    {
        #region Other members results
        //public static bool IsPangram(string str)
        //{
        //    return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
        //}

        //public static bool IsPangram(string str)
        //{
        //    return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".All(x => str.ToUpper().Contains(x));
        //}
        #endregion

        public static bool IsPangram(string str)
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
                == string.Concat(str.ToUpper().Distinct().Where(Char.IsLetter).OrderBy(c => c)) ? true : false;
        }
    }

    [TestFixture]
    public class DetectPangramTests
    {
        [Test]
        public void SampleTests()
        {
            Assert.AreEqual(true, KataDetectPangram.IsPangram("The quick brown fox jumps over the lazy dog."));
        }
    }
}