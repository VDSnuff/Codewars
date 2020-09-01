using Microsoft.VisualBasic;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{

    public static class KataUniqueInOrder
    {
        #region Other members results
        //public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        //{
        //    return iterable.Where((x, i) => i == 0 || !x.Equals(iterable.ToArray()[i - 1]));
        //}

        #endregion
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
        {
            List<T> uList = new List<T>();
            T prev = default; 
            foreach (var item in iterable)
            {
                if (!item.Equals(prev)) uList.Add(item);
                prev = item;
            }

            return uList;
        }
    }

    [TestFixture]
    public class UniqueInOrderTest
    {
        [TestFixture]
        public class SolutionTest
        {
            ////[Test]
            ////public void EmptyTest()
            ////    {
            ////        Assert.AreEqual("", KataUniqueInOrder.UniqueInOrder(""));
            ////   }
            [Test]
            public void Test1()
            {
                Assert.AreEqual("ABCDAB", KataUniqueInOrder.UniqueInOrder("AAAABBBCCDAABBB"));
            }
        }
    }
}