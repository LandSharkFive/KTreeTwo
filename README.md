# K-Tree: A "B+ Tree Lite" Implementation

K-Tree is a high-performance **Leaf-Search Tree** implemented in C#. Unlike a standard Binary Search Tree, K-Tree stores all data elements in sorted "buckets" at the leaf level. This "B+ Tree Lite" architecture minimizes tree height and maximizes cache locality, making it highly efficient for large-scale data handling.



## 🚀 Technical Merit

The K-Tree design offers significant advantages for general-use collections:
* **Reduced Pointer Chasing**: By storing 50–100 elements per leaf, the CPU performs fewer memory jumps to find data.
* **Memory Efficiency**: Internal nodes only store keys for routing, significantly reducing the metadata overhead compared to a node-per-item BST.
* **Sequential Access**: Since data is grouped in leaves, range scans and "find next" operations are faster.
* **O(log n) Performance**: Maintains logarithmic time complexity for Search, Insert, and Remove.

## 📊 Performance Benchmarks

The following metrics demonstrate the efficiency of the bucketed leaf approach:

| Total Items | Search/Insert | Memory Footprint |
| :--- | :--- | :--- |
| **1,000** | 1 ms | 26 MB |
| **10,000** | 2 ms | 27 MB |
| **100,000** | 3 ms | 29 MB |

---

## 🛠 Installation & Build

This is a C# Console-Mode project.

1.  **Requirement**: Visual Studio 2022 / .NET SDK 6.0+.
2.  **Open**: Load KTreeTwo.sln.
3.  **Build**: Use Ctrl+Shift+B to compile.
4.  **Configuration**: The optimal bucket size is between **50 and 100** elements, though this can be tuned in the source code.

## 🧪 Implementation Details

* **Structure**: A hybrid between a Binary Tree (for navigation) and a Sorted List (for storage).
* **Self-Balancing**: The tree uses height-management logic to ensure the path to any leaf remains $O(\log n)$.
* **Persistence Ready**: The leaf-bucket design makes this code an excellent starting point for implementing external disk-based storage or custom databases.

---
*Includes full Unit Test suite for logic validation.*


