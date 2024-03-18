using System;
using System.Collections.Generic;

public class ConnectedComponentGraph : Graph
{
    public ConnectedComponentGraph(int v) : base(v)
    {
    }

    // Ghi đè phương thức BFS từ lớp Graph
    public override void BFS(int s, bool[] visited)
    {
        base.BFS(s, visited);
    }

    //Tối ưu thuật toán BFS 
    public void BFS(int s, HashSet<int> visited)
    {
        Queue<int> queue = new Queue<int>();
        visited.Add(s);
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            s = queue.Dequeue();
            foreach (int i in base.adj[s]) // Truy cập danh sách kề từ lớp cha
            {
                if (!visited.Contains(i))
                {
                    visited.Add(i);
                    queue.Enqueue(i);
                }
            }
        }
    }
}
