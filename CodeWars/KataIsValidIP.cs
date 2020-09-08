using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public static class KataIsValidIP
    {
        #region Other members results
        //public static bool is_valid_IP(string IpAddres)
        //{
        //    return Regex.IsMatch(IpAddres, @"\b((25[0-5]|2[0-4][0-9]|[1]?[0-9][0-9]?)(\.|$)){4}\b");
        //}

        //public static bool is_valid_IP(string IpAddres)
        //{
        //    IPAddress ip;
        //    bool validIp = IPAddress.TryParse(IpAddres, out ip);
        //    return validIp && ip.ToString() == IpAddres;
        //}
        #endregion

        public static bool IsValidIP(string ipAddres)
        {
            return ipAddres.Split('.').Where(x => string.IsNullOrEmpty(x) != true
                                                  && x.ToCharArray().All(c => char.IsDigit(c))
                                                  && 0 <= int.Parse(x) && int.Parse(x) <= 255 && !(x.StartsWith("0") && x.Count() > 1)).ToList().Count() == 4;
        }

        [Test]
        public static void TestCases()
        {
            Assert.AreEqual(true, IsValidIP("0.0.0.0"));
            Assert.AreEqual(true, IsValidIP("12.255.56.1"));
            Assert.AreEqual(true, IsValidIP("137.255.156.100"));
            Assert.AreEqual(false, IsValidIP(""));
            Assert.AreEqual(false, IsValidIP("abc.def.ghi.jkl"));
            Assert.AreEqual(false, IsValidIP("123.456.789.0"));
            Assert.AreEqual(false, IsValidIP("12.34.56"));
            Assert.AreEqual(false, IsValidIP("12.34.56.00"));
            Assert.AreEqual(false, IsValidIP("12.34.56.7.8"));
            Assert.AreEqual(false, IsValidIP("12.34.256.78"));
            Assert.AreEqual(false, IsValidIP("1234.34.56"));
            Assert.AreEqual(false, IsValidIP("pr12.34.56.78"));
            Assert.AreEqual(false, IsValidIP("12.34.56.78sf"));
            Assert.AreEqual(false, IsValidIP("12.34.56 .1"));
            Assert.AreEqual(false, IsValidIP("12.34.56.-1"));
            Assert.AreEqual(false, IsValidIP("123.045.067.089"));
        }

    }
}