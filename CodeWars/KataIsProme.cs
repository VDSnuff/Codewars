using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public static class KataIsPrime
    {
        #region Other members results

        #endregion

        public static bool IsPrime(int n)
        {
            //return n != 0 && (from i in Enumerable.Range(2, n - 1).AsParallel()
            //        where Enumerable.Range(1, (int)Math.Sqrt(i)).All(j => j == 1 || i % j != 0)
            //        select i).ToList().Any(x => x == n);

            //if (n <= 1)
            //    return false;

            //// Check from 2 to n-1 
            //for (int i = 2; i < n; i++)
            //    if (n % i == 0)
            //        return false;

            //return true;
            //if (n <= 1) return false;
            //if (n == 2 || n == 3) return true;
            //if (n % 2 != 0 && n % 3 != 0) return true;
            //else return false;

            //if (n == 0 || n <= 1) return false;
            //else
            //{
            //    for (int i = 2; i <= n / 2; ++i)
            //    {
            //        if (n % i == 0)
            //        {
            //            return false;
            //        }
            //    }

            //    return true;
            //}

            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(n));

            for (int i = 3; i <= boundary; i += 2)
                if (n % i == 0)
                    return false;

            return true;

        }

        [TestFixture]
        public class IsPrimeTest
        {
            private static IEnumerable<TestCaseData> sampleTestCases
            {
                get
                {
                    yield return new TestCaseData(0).Returns(false);
                    yield return new TestCaseData(1).Returns(false);
                    yield return new TestCaseData(2).Returns(true);
                    yield return new TestCaseData(3).Returns(true);
                    yield return new TestCaseData(23).Returns(true);
                    yield return new TestCaseData(29).Returns(true);
                    yield return new TestCaseData(31).Returns(true);
                    yield return new TestCaseData(36).Returns(false);
                    yield return new TestCaseData(37).Returns(true);
                }
            }

            [Test, TestCaseSource("sampleTestCases")]
            public bool SampleTest(int n) => KataIsPrime.IsPrime(n);
        }
    }
}