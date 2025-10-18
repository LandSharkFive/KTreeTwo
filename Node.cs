namespace KTreeTwo
{
    public class Node
    {
        private const int MaxChild = 20;

        public int Key;
        public Node Left, Right; 
        public List<int> Data;


        public Node(int a)
        {
            Key = a;
            Left = null;
            Right = null;
            Data = null;
        }

        /// <summary>
        /// Is Leaf?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsLeaf()
        {
            return Left == null && Right == null;
        }

        /// <summary>
        /// Is leaf empty?
        /// </summary>
        /// <returns>bool</returns>
        public bool IsEmpty()
        {
            return Data == null || Data.Count == 0;
        }

        /// <summary>
        /// Is Overflow?
        /// </summary>
        /// <returns>bool</returns>
        private bool IsOverflow()
        {
            return IsLeaf() && Data.Count > MaxChild;
        }

        /// <summary>
        /// Is Underflow?
        /// </summary>
        /// <returns>bool</returns>
        private bool IsUnderflow()
        {
            return IsLeaf() && IsEmpty();
        }


        /// <summary>
        /// Get Height of node.
        /// </summary>
        /// <returns>int</returns>
        public int Height()
        {
            if (Left == null || Right == null)
            {
                return 0;
            }
            return 1 + Math.Max(Left.Height(), Right.Height());
        }

        /// <summary>
        /// Count nodes.
        /// </summary>
        /// <param name="a">int</param>
        /// <returns>int</returns>
        public int Count(Node a)
        {
            if (a == null)
                return 0;
            else
                return 1 + Count(a.Left) + Count(a.Right);
        }

        /// <summary>
        /// Add leaf node.
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="a">int</param>
        public void Add(Node node, int a)
        {
            Node n = GetLeaf(node, a);
            if (n.IsLeaf())
            {
                n.AddToLeaf(a);
            }
            if (n.IsOverflow())
            {
                n.SplitLeaf(n);
            }

        }

        /// <summary>
        /// Get Leaf for data.
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="a">int</param>
        /// <returns>node</returns>
        private Node GetLeaf(Node node, int a)
        {
            if (node.IsLeaf())
            {
                return node;
            }
            else if (a < node.Key)
            {
                if (node.Left == null)
                {
                    return node;
                }
                return GetLeaf(node.Left, a);
            }
            else if (node.Right == null)
            {
                return node;
            }
            return GetLeaf(node.Right, a);
        }

        /// <summary>
        /// Add to leaf.
        /// </summary>
        /// <param name="a">int</param>
        private void AddToLeaf(int a)
        {
            if (Data == null)
            {
                Data = new List<int>();
            }

            Data.Add(a);
            Data.Sort();
        }


        /// <summary>
        /// Split leaf.
        /// </summary>
        /// <param name="node">node</param>
        private void SplitLeaf(Node node)
        {
            if (node.IsLeaf())
            {
                node.Data.Sort();
                List<int> a = new List<int>();
                List<int> b = new List<int>();
                int middle = node.Data.Count / 2;
                for (int i = 0; i < middle; i++)
                {
                    a.Add(node.Data[i]);
                }
                for (int i = middle; i < node.Data.Count; i++)
                {
                    b.Add(node.Data[i]);
                }
                node.Key = b[0];
                node.Left = new Node(0);
                node.Right = new Node(0);
                node.Left.Data = a;
                node.Right.Data = b;
                node.Data.Clear();
            }
        }

        /// <summary>
        /// Get all data from leaves.
        /// </summary>
        /// <returns>list</returns>
        public List<int> GetData()
        {
            List<int> result = new List<int>();
            if (Left != null)
            {
                result.AddRange(Left.GetData());
            }
            if (IsLeaf())
            {
                result.AddRange(Data);
            }
            if (Right != null)
            {
                result.AddRange(Right.GetData());
            }
            return result;
        }

        /// <summary>
        /// Get keys from index nodes.
        /// </summary>
        /// <returns>list</returns>
        public List<int> GetKey()
        {
            List<int> result = new List<int>();
            if (Left != null)
            {
                result.AddRange(Left.GetKey());
            }
            if (!IsLeaf())
            {
                result.Add(Key);
            }
            if (Right != null)
            {
                result.AddRange(Right.GetKey());
            }
            return result;
        }

        /// <summary>
        /// Does data exist in leaf?
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="a">int</param>
        /// <returns>bool</returns>
        public bool Exist(Node node, int a)
        {
            Node b = GetLeaf(node, a);
            if (b == null)
                return false;
            return b.Data.Contains(a);
        }

        /// <summary>
        /// Remove data from leaf.
        /// </summary>
        /// <param name="node">node</param>
        /// <param name="a">int</param>
        public void Remove(Node node, int a)
        {
            Node n = GetLeaf(node, a);
            if (n == null)
            {
                return;
            }
            if (n.IsLeaf())
            {
                n.Data.Remove(a);
            }
        }

        /// <summary>
        /// Write Data to Stream.
        /// </summary>
        /// <param name="sw">StreamWriter</param>
        public void WriteToStream(StreamWriter sw)
        {
            if (Left != null)
            {
                Left.WriteToStream(sw);
            }
            if (IsLeaf() && !IsEmpty())
            {
                foreach (int x in Data)
                {
                    sw.WriteLine(x);
                }
            }
            if (Right != null)
            {
                Right.WriteToStream(sw);
            }

        }


    }
}
