using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public static class KataRGBToHexConversion
    {
        #region Other members results
        //public static string Rgb(int r, int g, int b)
        //{
        //    return Math.Clamp(r, 0, 255).ToString("X2") + Math.Clamp(g, 0, 255).ToString("X2") + Math.Clamp(b, 0, 255).ToString("X2");
        //}

        //My new:
        //public static string Rgb(int r, int g, int b)
        //{
        //    return string.Format("{0:X2}{1:X2}{2:X2}",
        //      Math.Clamp(r, 0, 255).ToString("X2"),
        //      Math.Clamp(g, 0, 255).ToString("X2"),
        //      Math.Clamp(b, 0, 255).ToString("X2")
        //   );
        //}
        #endregion

        public static string Rgb(int r, int g, int b)
        {
            return string.Format("{0:X2}{1:X2}{2:X2}",
              r = r > 255 ? 255 :
                     r < 0 ? 0 : r,
              g = g > 255 ? 255 :
                     g < 0 ? 0 : g,
              b = b > 255 ? 255 :
                     b < 0 ? 0 : b
           );
        }
    }

    [TestFixture]
    public class RGBToHexConversionTests
    {
        [Test]
        public void FixedTests()
        {
            Assert.AreEqual("FFFFFF", KataRGBToHexConversion.Rgb(255, 255, 255));
            Assert.AreEqual("FFFFFF", KataRGBToHexConversion.Rgb(255, 255, 300));
            Assert.AreEqual("000000", KataRGBToHexConversion.Rgb(0, 0, 0));
            Assert.AreEqual("9400D3", KataRGBToHexConversion.Rgb(148, 0, 211));
            Assert.AreEqual("9400D3", KataRGBToHexConversion.Rgb(148, -20, 211), "Handle negative numbers.");
            Assert.AreEqual("90C3D4", KataRGBToHexConversion.Rgb(144, 195, 212));
            Assert.AreEqual("D4350C", KataRGBToHexConversion.Rgb(212, 53, 12), "Consider single hex digit numbers.");
        }
    }
}