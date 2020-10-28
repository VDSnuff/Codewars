using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public class TestVal
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }

    public class DistinctWithHighestValue
    {
        public static List<TestVal> GetDistinctWithHighestValue()
        {
            List<TestVal> testVals = new List<TestVal>()
            {
                new TestVal() { Name = "3DS", Date = new DateTime(2020, 10, 26, 0, 0, 0) },
                new TestVal() { Name = "3DS", Date = new DateTime(2020, 10, 27, 0, 0, 0) },
                new TestVal() { Name = "3DS", Date = new DateTime(2020, 10, 29, 0, 0, 0) },
                new TestVal() { Name = "GND", Date = new DateTime(2020, 10, 28, 0, 0, 0) }
            };

            return testVals.GroupBy(x => x.Name, (k, g) => g.Aggregate((a, x) => (x.Date < a.Date) ? x : a)).ToList();
        }

        [TestFixture]
        public class IsDistinctWithHighestValue
        {

            [Test]
            public static void CountShouldBeTwo()
            {
                Assert.IsTrue(GetDistinctWithHighestValue().Count() == 2);
            }

            [Test]
            public static void ShouldContain()
            {
                Assert.That(GetDistinctWithHighestValue().Any(x => x.Name == "3DS" && 0 == DateTime.Compare(x.Date, new DateTime(2020, 10, 26, 0, 0, 0))));
                Assert.That(GetDistinctWithHighestValue().Any(x => x.Name == "GND" && 0 == DateTime.Compare(x.Date, new DateTime(2020, 10, 28, 0, 0, 0))));
            }
        }
    }
}
