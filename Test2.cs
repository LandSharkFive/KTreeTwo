
using KTreeTwo;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public sealed class Test
    {
        [TestMethod]
        public void TestSix()
        {
            List<int> a = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                a.Add(i);
            }

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
            timer.Reset();
            timer.Start();

            foreach (int x in a)
            {
                t.Remove(x);
            }

            timer.Stop();

            myTime = timer.Elapsed;
            Console.Write(myTime.TotalMilliseconds);
            Console.WriteLine(" ms");

            int data = t.GetData().Count;
            Assert.IsTrue(data == 0);

        }

        [TestMethod]
        public void TestSeven()
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

            var timer = new Stopwatch();
            timer.Start();

            t.Rebuild();

            timer.Stop();

            TimeSpan myTime = timer.Elapsed;
            Console.Write(myTime.TotalMilliseconds);
            Console.WriteLine(" ms");

            timer.Reset();

            timer.Start();

            for (int i = 0; i < 1000; i++)
            {
                t.Exist(i);
            }

            timer.Stop();

            myTime = timer.Elapsed;
            Console.Write(myTime.TotalMilliseconds);
            Console.WriteLine(" ms");

            int data = t.GetData().Count;
            Assert.IsTrue(data == 1000);
        }


    }
}
