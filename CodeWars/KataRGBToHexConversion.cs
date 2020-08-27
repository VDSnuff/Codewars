using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public static class KataValidateCreditCardNumber
    {
        #region Other members results

        //public bool validate(string n)
        //{

        //    return n.Select(c => (int)char.GetNumericValue(c))
        //      .Where(x => x != -1)
        //      .Reverse()
        //      .Select((x, i) => (i % 2 == 1) ? 2 * x : x)
        //      .Select(x => (x > 9) ? x - 9 : x)
        //      .Sum() % 10 == 0;
        //}

    #endregion

    public static bool Validate(string n)
        {
            var cNum = n.Replace(" ", "").Select(x => char.GetNumericValue(x)).ToArray();
            if (cNum.Length % 2 == 0 && cNum.Select((x, i) => { if (i % 2 == 0) x = x * 2 > 9 ? (x * 2) - 9 : x * 2; return x; }).Sum() % 10 == 0) return true;
            else if (cNum.Length % 2 != 0 && cNum.Skip(1).Select((x, i) => { if (i % 2 == 0) x = x * 2 > 9 ? (x * 2) - 9 : x * 2; return x; }).Append(cNum[0]).Sum() % 10 == 0) return true;
            else return false;
        }
    }

    [TestFixture]
    public class ValidateCreditCardNumberTests
    {
        [Test]
        public void FixedTests()
        {
            Assert.AreEqual(false, KataValidateCreditCardNumber.Validate("477 073 360"));
            Assert.AreEqual(true, KataValidateCreditCardNumber.Validate("5422 0148 5514"));
            Assert.AreEqual(true, KataValidateCreditCardNumber.Validate("8314 7046 0245"));
            Assert.AreEqual(false, KataValidateCreditCardNumber.Validate("6654 6310 43044"));
            Assert.AreEqual(true, KataValidateCreditCardNumber.Validate("0768 2757 5685 6340"));
            Assert.AreEqual(false, KataValidateCreditCardNumber.Validate("7164 6207 74042"));
            Assert.AreEqual(true, KataValidateCreditCardNumber.Validate("8383 7332 3570 8514"));
            Assert.AreEqual(true, KataValidateCreditCardNumber.Validate("481 135"));
            Assert.AreEqual(true, KataValidateCreditCardNumber.Validate("355 032 5363"));
       }
   }
}