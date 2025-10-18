
using System.Reflection.PortableExecutable;

namespace KTreeTwo
{
    public class Tree
    {
        private const int MaxChild = 20;

        public Node Root;

        public Tree()
        {
            Root = null;
        }

        /// <summary>
        /// Add leaf node.
        /// </summary>
        /// <param name="a">int</param>
        public void Add(int a)
        {
            if (Root == null)
            {
                Root = new Node(a);
            }

            Root.Add(Root, a);
        }

        /// <summary>
        /// Get tree height.
        /// </summary>
        /// <returns>int</returns>
        public int Height()
        {
            if (Root == null)
            {
                return 0;
            }

            return Root.Height();
        }

        /// <summary>
        /// Count nodes in tree.
        /// </summary>
        /// <returns>int</returns>
        public int Count()
        {
            if (Root == null)
                return 0;
            else
                return Root.Count(Root);
        }


        /// <summary>
        /// Get data from leaves.
        /// </summary>
        /// <returns>list</returns>
        public List<int> GetData()
        {
            if (Root == null)
            {
                return new List<int>();
            }

            return Root.GetData();
        }

        /// <summary>
        /// Get Keys from index nodes.
        /// </summary>
        /// <returns>list</returns>
        public List<int> GetKey()
        {
            if (Root == null)
            {
                return new List<int>();
            }

            return Root.GetKey();
        }

        /// <summary>
        /// Does data exist?
        /// </summary>
        /// <param name="a">int</param>
        /// <returns>bool</returns>
        public bool Exist(int a)
        {
            if (Root == null)
                return false;

            return Root.Exist(Root, a);
        }

        /// <summary>
        /// Remove data from leaf.
        /// </summary>
        /// <param name="a">int</param>
        public void Remove(int a)
        {
            if (Root == null)
                return;
            Root.Remove(Root, a);
            if (Root.IsLeaf() && Root.IsEmpty())
            {
                Root = null;
            }
        }

        /// <summary>
        /// Rebuild Tree.
        /// </summary>
        public void Rebuild()
        {
            if (Root == null)
                return;

            List<int> list = Root.GetData();
            list.Sort();
            Root = Build(list, 0, list.Count - 1, MaxChild);
        }

        /// <summary>
        /// Build Balanced Tree.
        /// </summary>
        /// <param name="list">list</param>
        /// <param name="start">int</param>
        /// <param name="end">int</param>
        /// <param name="size">int</param>
        /// <returns></returns>
        public Node Build(List<int> list, int start, int end, int size)
        {
            Node a = new Node(0);
            if (start + size > end)
            {
                // leaf
                a.Key = 0;
                a.Data = list.GetRange(start, end - start + 1);
                return a;
            }

            // index 
            int mid = (start + end) / 2;
            a.Key = list[mid + 1];
            a.Left = Build(list, start, mid, size);
            a.Right = Build(list, mid + 1, end, size);
            return a;
        }

        /// <summary>
        /// Write to file.
        /// </summary>
        /// <param name="fileName">string</param>
        public void WriteToFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                Root.WriteToStream(sw);
            }
        }

        /// <summary>
        /// Read file
        /// </summary>
        /// <param name="fileName">string</param>
        public void ReadFile(string fileName)
        {
            List<int> list = new List<int>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    int a = 0;
                    if (int.TryParse(line, out a))
                    {
                        list.Add(a);
                    }
                }
            }

            Root = Build(list, 0, list.Count - 1, MaxChild);
        }


    }
}
