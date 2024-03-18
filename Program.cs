using AdvancedArchitect_CoChi.Performance;
using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        // Nhập số đỉnh và số cạnh của đồ thị
        Console.WriteLine("Nhập số đỉnh và số cạnh của đồ thị:");
        string[] nm = Console.ReadLine().Split();
        int n = int.Parse(nm[0]);
        int m = int.Parse(nm[1]);

        // Khởi tạo đồ thị
        Graph graph = new Graph(n);

        // Nhập các cạnh của đồ thị
        Console.WriteLine("Nhập các cạnh của đồ thị:");
        for (int i = 0; i < m; ++i)
        {
            string[] edge = Console.ReadLine().Split();
            int u = int.Parse(edge[0]);
            int v = int.Parse(edge[1]);
            graph.AddEdge(u, v);
        }

        // Tính và in ra số thành phần liên thông của đồ thị
        Console.WriteLine("Số thành phần liên thông của đồ thị là: " + graph.CountConnectedComponents());
        Console.ReadLine();

        // In danh sách các đỉnh trong từng thành phần liên thông
        bool[] visited = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (!visited[i])
            {
                List<int> connectedComponent;
                graph.BFS_list(i, visited, out connectedComponent);
                graph.PrintConnectedComponent(connectedComponent);
            }
        }

        Console.ReadLine();

        // Test performance
        Console.WriteLine("Kiểm tra hiệu năng:");
        PerformanceTest.MeasurePerformance();
        Console.ReadLine();

        // Test BFS with bool[] visited
        Console.WriteLine("Performance test for BFS with bool[] visited:");
        AdvancedArchitect_CoChi.Performance.BFSPerformanceTester.TestBFSWithBoolArray();

        // Test BFS with HashSet<int> visited
        Console.WriteLine("\nPerformance test for BFS with HashSet<int> visited:");
        AdvancedArchitect_CoChi.Performance.BFSPerformanceTester.TestBFSWithHashSet();

        // Compare performance of BFS with bool[] visited and HashSet<int> visited
        BFSPerformanceTester.CompareBFSPerformance();

        Console.ReadLine();


        //Tối ưu hiệu năng 1 
        ConnectedComponentGraph g = new ConnectedComponentGraph(7);

        // Thêm cạnh vào đồ thị
        g.AddEdge(1, 2);
        g.AddEdge(1, 3);
        g.AddEdge(2, 3);
        g.AddEdge(5, 6);
        g.AddEdge(6, 7);
        g.AddEdge(5, 7);

        HashSet<int> visitedOpPer = new HashSet<int>();

        Console.WriteLine("Tối ưu hóa hiệu suất BFS starting from vertex 1:");
        g.BFS(0, visitedOpPer); // Start BFS from vertex 1 (index 0)
        Console.WriteLine("Số thành phần liên thông của đồ thị theo BFS mới là: " + g.CountConnectedComponents());

        Console.ReadLine();

        Console.ReadLine();
    }
}
