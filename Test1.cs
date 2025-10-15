
using KTreeTwo;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestOne()
        {
            List<int> a = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                a.Add(i);
            }

            Tree t = new Tree();
            foreach (int x in a)
            {
                t.Add(x);
            }

            int height = t.Height();
            Assert.IsTrue(height == 98);

            int count = t.Count();
            Assert.AreEqual(count, 197);

            int data = t.GetData().Count();
            Assert.IsTrue(data == 1000);

            for (int i = 0; i < 1000; i++)
            {
                t.Remove(i);
            }

            height = t.Height();
            Assert.IsTrue(height == 98);

            count = t.Count();
            Assert.AreEqual(count, 197);

            data = t.GetData().Count();
            Assert.IsTrue(data == 0);
        }

        [TestMethod]
        public void TestTwo()
        {
            List<int> a = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                a.Add(i);
            }

            Tree t = new Tree();
            foreach (int x in a)
            {
                t.Add(x);
            }

            t.Rebuild();

            int height = t.Height();
            Assert.IsTrue(height == 6);

            int count = t.Count();
            Assert.AreEqual(count, 127);

            int data = t.GetData().Count();
            Assert.IsTrue(data == 1000);

            for (int i = 0; i < 1000; i++)
            {
                t.Remove(i);
            }

            height = t.Height();
            Assert.IsTrue(height == 6);

            count = t.Count();
            Assert.AreEqual(count, 127);

            data = t.GetData().Count();
            Assert.IsTrue(data == 0);
        }

        [TestMethod]
        public void TestThree()
        {
            List<int> a = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                a.Add(i);
            }

            Tree t = new Tree();
            foreach (int x in a)
            {
                t.Add(x);
            }

            foreach (int x in a)
            {
                Assert.IsTrue(t.Exist(x));
            }

        }

        [TestMethod]
        public void TestFour()
        {
            Random rnd = new Random();

            List<int> a = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                a.Add(rnd.Next(10000));
            }

            // All keys must be unique.
            a = a.Distinct().ToList();

            Tree t = new Tree();

            // timing
            var timer = new Stopwatch();
            timer.Start();

            foreach (int x in a)
            {
                t.Add(x);
            }

            timer.Stop();

            TimeSpan myTime = timer.Elapsed;
            Console.Write(myTime.TotalMilliseconds);
            Console.WriteLine(" ms");

            foreach (int x in a)
            {
                Assert.IsTrue(t.Exist(x));
            }

            foreach (int x in a)
            {
                t.Remove(x);
            }

            int data = t.GetData().Count();
            Assert.IsTrue(data == 0);
        }


    }
}
