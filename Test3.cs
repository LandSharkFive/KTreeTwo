
using KTreeTwo;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public sealed class Test2
    {
        [TestMethod]
        public void TestSix()
        {
            List<int> a = new List<int> { 1914, 8964, 9645, 2156, 5449, 1771, 4372, 1245, 7417, 7401, 4945, 5337, 8370, 2857, 8398,
                6077, 8006, 1272, 8775, 1482 };

            Tree t = new Tree();

            foreach (int x in a)
            {
                t.Add(x);
            }

            foreach (int x in a)
            {
                t.Remove(x);
            }

            int data = t.GetData().Count;
            Assert.IsTrue(data == 0);
        }

        [TestMethod]
        public void TestSeven()
        {
            List<int> a = new List<int> {774, 6681, 109, 3322, 2849, 1663, 1636, 7383, 5077, 3386, 8635,
                2169, 8203, 4415, 1760, 5554, 3411, 9459, 7291, 6751 };

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

            for (int i = 0; i < a.Count; i++)
            {
                t.Exist(i);
            }

            timer.Stop();

            myTime = timer.Elapsed;
            Console.Write(myTime.TotalMilliseconds);
            Console.WriteLine(" ms");

            int data = t.GetData().Count;
            Assert.AreEqual(data, 20);
        }


    }
}
