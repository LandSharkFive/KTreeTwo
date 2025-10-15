
using KTreeTwo;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public sealed class Test4
    {
        [TestMethod]
        public void TestFourteen()
        {
            Random rnd = new Random();

            List<int> a = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                a.Add(rnd.Next(10000));
            }

            // Remove duplicates
            a = a.Distinct().ToList();

            // timing
            var timer = new Stopwatch();
            timer.Start();

            Tree t = new Tree();
            foreach (int x in a)
            {
                t.Add(x);
            }

            timer.Stop();
            TimeSpan myTime = timer.Elapsed;
            Console.WriteLine("build " + myTime.TotalMilliseconds + " ms");
            Console.WriteLine();

            t.Rebuild();

            Console.WriteLine("height " + t.Height());
            Console.WriteLine("nodes " + t.Count());
            Console.WriteLine("data " + t.GetData().Count());
            Console.WriteLine("memory " + Util.GetMemory());
            Console.WriteLine();


            foreach (int x in a)
            {
                t.Remove(x);
            }

            Console.WriteLine("height " + t.Height());
            Console.WriteLine("nodes " + t.Count());
            Console.WriteLine("data " + t.GetData().Count());
            Console.WriteLine("memory " + Util.GetMemory());
            Console.WriteLine();
        }
    
    
    }
}
