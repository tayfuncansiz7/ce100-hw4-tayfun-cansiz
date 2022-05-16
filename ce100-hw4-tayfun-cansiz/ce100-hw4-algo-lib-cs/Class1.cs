using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ce100_hw4_algo_lib_cs
{
    public class Activity_Selection
    {

        /**
        *
        *	  @name   printMaxActivities (Print Activity Selection Problem)
        *
        *	  @brief Print Activity Selection Problem
        *
        *	  Print Activity Selection Problem
        *
        *	  @param  [in] s [\b int]  s
        *	  
        *	  @param  [in] f [\b int]  f
        *	  
        *	  @param  [in] n [\b int]  n
        *	  
        *	  
        **/



        public static int printMaxActivities(int[] s, int[] f, int n)
        {
            int i, j;


            // The first activity always gets selected
            i = 0;

            // Consider rest of the activities
            for (j = 1; j < n; j++)
            {
                // If this activity has start time greater than or
                // equal to the finish time of previously selected
                // activity, then select it
                if (s[j] >= f[i])
                {
                    i = j;
                }
            }

            return i;
        }

    }

    public class Knapsack_Problem
    {
        // A utility function that returns
        // maximum of two integers
        public static int max(int a, int b)
        {
            return (a > b) ? a : b;
        }


        /**
        *
        *	  @name   knapSack (Knapsack Function)
        *
        *	  @brief Knapsack Function
        *
        *	  Knapsack Function
        *
        *	  @param  [in] W [\b int]  W
        *	  
        *	  @param  [in] wt [\b int]  wt
        *	  
        *	  @param  [in] val [\b int]  val
        *	  
        *	  @param  [in] n [\b int]  n
        *	  
        *	  
        **/


        public static int knapSack(int W, int[] wt, int[] val, int n)
        {

            // Base Case
            if (n == 0 || W == 0)
                return 0;

            // If weight of the nth item is
            // more than Knapsack capacity W,
            // then this item cannot be
            // included in the optimal solution
            if (wt[n - 1] > W)
                return knapSack(W, wt,
                                val, n - 1);

            // Return the maximum of two cases:
            // (1) nth item included
            // (2) not included
            else
                return max(val[n - 1]
                           + knapSack(W - wt[n - 1], wt,
                                      val, n - 1),
                           knapSack(W, wt, val, n - 1));
        }


        /**
        *
        *	  @name   knapSack (Print Knapsack Function)
        *
        *	  @brief Print Knapsack Function
        *
        *	  Print Knapsack Function
        *
        *	  @param  [in] W [\b int]  W
        *	  
        *	  @param  [in] wt [\b int]  wt
        *	  
        *	  @param  [in] val [\b int]  val
        *	  
        *	  @param  [in] n [\b int]  n
        *	  
        *	  
        **/

        // Prints the items which are put
        // in a knapsack of capacity W
        public static int printknapSack(int W, int[] wt, int[] val, int n)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];

            // Build table K[][] in bottom up manner
            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] +
                                K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            // stores the result of Knapsack
            int res = K[n, W];

            w = W;
            for (i = n; i > 0 && res > 0; i--)
            {

                // either the result comes from the top
                // (K[i-1][w]) or from (val[i-1] + K[i-1]
                // [w-wt[i-1]]) as in Knapsack table. If
                // it comes from the latter one/ it means
                // the item is included.
                if (res == K[i - 1, w])
                    continue;
                else
                {
                    // Since this weight is included its
                    // value is deducted
                    res = res - val[i - 1];
                    w = w - wt[i - 1];
                }
            }
            return res;
        }

    }

    public class BFS_Problem
    {
        // No. of vertices    
        public static int _v;

        //Adjacency Lists
        public static LinkedList<int>[] _adj;

        public static void Graph(int V)
        {
            _adj = new LinkedList<int>[V];
            for (int i = 0; i < _adj.Length; i++)
            {
                _adj[i] = new LinkedList<int>();
            }
            _v = V;
        }

        // Function to add an edge into the graph
        public static void AddEdge(int v, int w)
        {
            _adj[v].AddLast(w);

        }

        /**
        *
        *	  @name   BFS (BFS Function)
        *
        *	  @brief BFS Function
        *
        *	  BFS Function
        *
        *	  @param  [in] s [\b int]  s
        *	  

        *	  
        **/


        // Prints BFS traversal from a given source s
        public static string BFS(int s)
        {
            string arr = "";

            // Mark all the vertices as not
            // visited(By default set as false)
            bool[] visited = new bool[_v];
            for (int i = 0; i < _v; i++)
                visited[i] = false;

            // Create a queue for BFS
            LinkedList<int> queue = new LinkedList<int>();

            // Mark the current node as
            // visited and enqueue it
            visited[s] = true;
            queue.AddLast(s);

            while (queue.Any())
            {

                // Dequeue a vertex from queue
                // and print it
                s = queue.First();
                arr += (s + ",");
                queue.RemoveFirst();

                // Get all adjacent vertices of the
                // dequeued vertex s. If a adjacent
                // has not been visited, then mark it
                // visited and enqueue it
                LinkedList<int> list = _adj[s];


                foreach (var val in list)
                {
                    if (!visited[val])
                    {
                        visited[val] = true;
                        queue.AddLast(val);
                    }
                }
            }
            return arr.Remove(arr.Length - 2);
        }


    }

    public class DFS_Problem
    {
        // No. of vertices 
        public static int _V; // Number of Vertices
                              //Adjacency Lists
        public static LinkedList<int>[] adj; // adjacency lists

        // Constructor
        public static void graph(int V)
        {

            adj = new LinkedList<int>[V];

            for (int i = 0; i < adj.Length; i++)
            {
                adj[i] = new LinkedList<int>();
            }
            _V = V;
        }

        // To add an edge to graph
        public static void addEdge(int v, int w)
        {
            adj[v].AddLast(w); // Add w to v’s list.
        }



        /**
        *
        *	  @name   DFS_Print (Print DFS Function)
        *
        *	  @brief Print DFS Function
        *
        *	  Print DFS Function
        *
        *	  @param  [in] s [\b int]  s
        *	  
        *	  
        **/

        // prints all not yet visited vertices reachable from s
        public static string DFS_Print(int s)
        {
            // Initially mark all vertices as not visited
            Boolean[] visited = new Boolean[_V];

            // Create a stack for DFS
            Stack<int> stack = new Stack<int>();

            // Push the current source node
            stack.Push(s);
            string print = "";
            while (stack.Count > 0)
            {
                // Pop a vertex from stack and print it
                s = stack.Peek();
                stack.Pop();

                // Stack may contain same vertex twice. So
                // we need to print the popped item only
                // if it is not visited.
                if (visited[s] == false)
                {
                    print += s + ", ";
                    visited[s] = true;
                }

                // Get all adjacent vertices of the popped vertex s
                // If a adjacent has not been visited, then push it
                // to the stack.
                foreach (int v in adj[s])
                {
                    if (!visited[v])
                        stack.Push(v);
                }

            }

            return print.Remove(print.Length - 2);
        }

    }

    public class Topological_Sort_Problem
    {
        // No. of vertices
        public static int V;

        // Adjacency List as ArrayList
        // of ArrayList's
        public static List<List<int>> adjacency;

        // Constructor
        public static void _graph(int v)
        {
            V = v;
            adjacency = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adjacency.Add(new List<int>());
        }

        // Function to add an edge into the graph
        public static void addedge(int v, int w)
        {
            adjacency[v].Add(w);
        }


        /**
       *
       *	  @name   TopologicalSortUtil (Topological Sort Function)
       *
       *	  @brief Topological Sort Function
       *
       *	  Topological Sort Function
       *
       *	  @param  [in] v [\b int]  v
       *	  
       *	  @param  [in] visited [\b int]  visited
       *	  
       *	  @param  [in] stack [\b int]  stack
       *	  
       *	  
       **/

        // A recursive function used by topologicalSort
        public static void TopologicalSortUtil(int v, bool[] visited, Stack<int> stack)
        {

            // Mark the current node as visited.
            visited[v] = true;

            // Recur for all the vertices
            // adjacent to this vertex
            foreach (var vertex in adjacency[v])
            {
                if (!visited[vertex])
                    TopologicalSortUtil(vertex, visited, stack);
            }

            // Push current vertex to
            // stack which stores result
            stack.Push(v);
        }

        // The function to do Topological Sort.
        // It uses recursive topologicalSortUtil()
        public static string TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited
            var visited = new bool[V];
            string print = "";
            // Call the recursive helper function
            // to store Topological Sort starting
            // from all vertices one by one
            for (int i = 0; i < V; i++)
            {
                if (visited[i] == false)
                    TopologicalSortUtil(i, visited, stack);
            }

            // Print contents of stack
            foreach (var vertex in stack)
            {
                print += vertex + ", ";
            }

            return print.Remove(print.Length - 2);

        }

    }

    public class SCC_Problem
    {
        /**
       *
       *	  @name   SCCProblem (SCC Function)
       *
       *	  @brief SCC Function
       *
       *	  SCC Function
       *
       *	  @param  [in] v [\b int]  v
       *	  
       *	  
       **/

        public int V;
        public LinkedList<int>[] adj;
        public int Time;
        public void addEdge(int v, int w)
        {
            adj[v].AddLast(w);
        }
        public SCC_Problem(int v)
        {
            V = v;
            adj = new LinkedList<int>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new LinkedList<int>();
            }
        }
        public void SCCUtil(int u, int[] low, int[] disc, bool[] stackMember, Stack<int> stack)
        {
            low[u] = disc[u] = Time++;
            stack.Push(u);
            stackMember[u] = true;
            foreach (int v in adj[u])
            {
                if (disc[v] == -1)
                {
                    SCCUtil(v, low, disc, stackMember, stack);
                    low[u] = Math.Min(low[u], low[v]);
                }
                else if (stackMember[v])
                {
                    low[u] = Math.Min(low[u], disc[v]);
                }
            }
            if (low[u] == disc[u])
            {
                int v;
                do
                {
                    v = stack.Pop();
                    Console.WriteLine(v + " ");
                    stackMember[v] = false;
                } while (v != u);
            }
        }
        public int SCC()
        {
            int[] low = new int[V];
            int[] disc = new int[V];
            bool[] stackMember = new bool[V];
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < V; i++)
            {
                disc[i] = -1;
                low[i] = -1;
            }
            for (int i = 0; i < V; i++)
            {
                if (disc[i] == -1)
                {
                    SCCUtil(i, low, disc, stackMember, stack);
                }
            }
            return 0;
        }

    }
}