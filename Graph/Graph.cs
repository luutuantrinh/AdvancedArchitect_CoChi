using System;
using System.Collections.Generic;

public class Graph
{
    protected int V; // Số đỉnh
    protected List<int>[] adj; // Danh sách kề

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; ++i)
            adj[i] = new List<int>();
    }

    // Thêm cạnh vào đồ thị
    public void AddEdge(int v, int w)
    {
        adj[v - 1].Add(w - 1);
        adj[w - 1].Add(v - 1); // Đồ thị vô hướng, nên cần thêm cả 2 chiều
    }

    // Hàm BFS
    public virtual void BFS(int s, bool[] visited)
    {
        Queue<int> queue = new Queue<int>();
        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            s = queue.Dequeue();
            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }

    

    // Tính số thành phần liên thông
    public int CountConnectedComponents()
    {
        int count = 0;
        bool[] visited = new bool[V];

        for (int i = 0; i < V; ++i)
        {
            if (!visited[i])
            {
                BFS(i, visited);
                count++;
            }
        }

        return count;
    }

    public List<int> BFS_list(int s, bool[] visited, out List<int> connectedComponent)
    {
        connectedComponent = new List<int>(); // Danh sách các đỉnh trong thành phần liên thông
        Queue<int> queue = new Queue<int>();
        visited[s] = true;
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            s = queue.Dequeue();
            connectedComponent.Add(s); // Thêm đỉnh vào thành phần liên thông
            foreach (int i in adj[s])
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
        return connectedComponent;
    }

    // In danh sách các đỉnh trong thành phần liên thông
    public void PrintConnectedComponent(List<int> component)
    {
        Console.Write("Connected Component: ");
        foreach (var vertex in component)
        {
            Console.Write(vertex + 1 + " "); // Đỉnh thực tế là số đỉnh + 1
        }
        Console.WriteLine();
    }


}


