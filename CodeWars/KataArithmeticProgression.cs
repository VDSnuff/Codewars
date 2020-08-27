using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public static class KataArithmeticProgression
    {
        #region Other members results
        //public static int FindMissing(List<int> list)
        //{
        //    return l.Skip(1).Select((x, i) => new { D = x - l[i], V = x + l[i] }).OrderBy(x => x.D).Last().V / 2;
        //}

        //public static int FindMissing(List<int> list)
        //{
        //    var difference = list.Skip(1).Select((x, i) => x - list[i]).GroupBy(x => x).Min(x => x.Key);
        //    return list.Select(x => x + difference).Except(list).First();
        //}
        #endregion

        public static int FindMissing(List<int> list)
        {
            List<int> inc = new List<int>();
            for (int i = 0; i < list.Count() - 1; i++)
            {
                inc.Add(list[i + 1] - list[i]);
            }

            List<int> o = new List<int> { list[0] };
            for (int i = 0; i < list.Count() - 1; i++)
            {
                o.Add(o[i] + inc.Min());
            }

            return o.Except(list).FirstOrDefault();
        }
    }

    [TestFixture]
    public class ArithmeticProgressionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData(new[] { new List<int> { 1, 3, 5, 9, 11 } }).Returns(7);
                yield return new TestCaseData(new[] { new List<int> { 0, 5, 10, 20, 25 } }).Returns(15);
                yield return new TestCaseData(new[] { new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 } }).Returns(10);
                yield return new TestCaseData(new[] { new List<int> { 1040, 1220, 1580 } }).Returns(1400);
            }
        }

        [Test, TestCaseSource("testCases")]
        public int Test(List<int> list) => KataArithmeticProgression.FindMissing(list);
    }
}