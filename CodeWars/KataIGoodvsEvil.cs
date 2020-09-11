using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public static class KataIGoodvsEvil
    {
        #region Other members results

        #endregion

        public static string GoodVsEvil(string good, string evil)
        {
            int[] goodArmy = {1, 2, 3, 3, 4, 10 };
            int[] evilArmy = {1, 2, 2, 2, 3, 5, 10};
            int goodForce = good.Split(" ").Zip(goodArmy, (x1, x2) => int.Parse(x1) * x2).Sum();
            int evelForce = evil.Split(" ").Zip(evilArmy, (y1, y2) => int.Parse(y1) * y2).Sum();

            return goodForce == evelForce ? "Battle Result: No victor on this battle field"
                  :goodForce > evelForce ? "Battle Result: Good triumphs over Evil"
                  :"Battle Result: Evil eradicates all trace of Good";
        }
    }

    [TestFixture]
    public class GoodVsEvil
    {
        [Test]
        public static void EvilShouldWin()
        {
            Assert.AreEqual("Battle Result: Evil eradicates all trace of Good", KataIGoodvsEvil.GoodVsEvil("1 1 1 1 1 1", "1 1 1 1 1 1 1"));
        }

        [Test]
        public static void GoodShouldTriumph()
        {
            Assert.AreEqual("Battle Result: Good triumphs over Evil", KataIGoodvsEvil.GoodVsEvil("0 0 0 0 0 10", "0 1 1 1 1 0 0"));
        }

        [Test]
        public static void ShouldBeATie()
        {
            Assert.AreEqual("Battle Result: No victor on this battle field", KataIGoodvsEvil.GoodVsEvil("1 0 0 0 0 0", "1 0 0 0 0 0 0"));
        }
    }
}