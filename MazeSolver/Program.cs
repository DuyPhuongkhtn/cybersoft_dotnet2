using System;
using System.Collections.Generic;
using System.Threading;

class MazeSolver
{
    const char WALL = '#'; // Ký tự tường
    const char PATH = '.'; // Ký tự đường đi
    const char PLAYER = 'P'; // Nhân vật di chuyển
    const char VISITED = '*'; // Đường đã đi

    static int rows = 15; // Kích thước mê cung
    static int cols = 15;
    static char[,] maze;
    static (int, int) start;
    static (int, int) end;

    static void Main(string[] args)
    {
        GenerateMaze();

        Console.WriteLine("Mê cung ngẫu nhiên đã tạo:");
        PrintMaze();

        SelectStartAndEnd();

        Console.WriteLine("\nTìm đường đi ngắn nhất...");
        var path = FindShortestPath();

        if (path != null)
        {
            Console.WriteLine("\nDi chuyển nhân vật theo đường đi...");
            MoveAlongPath(path);
        }
        else
        {
            Console.WriteLine("\nKhông tìm thấy đường đi!");
        }
    }

    static void GenerateMaze()
    {
        Random rand = new Random();
        maze = new char[rows, cols];

        // Tạo mê cung ngẫu nhiên
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                maze[i, j] = rand.Next(0, 100) < 20 ? WALL : PATH; // 20% là tường
            }
        }
    }

    static void SelectStartAndEnd()
    {
        Console.WriteLine("\nNhập tọa độ điểm bắt đầu (hàng và cột, cách nhau bởi khoảng trắng):");
        start = ReadValidPosition();
        maze[start.Item1, start.Item2] = 'S';

        Console.WriteLine("Nhập tọa độ điểm kết thúc (hàng và cột, cách nhau bởi khoảng trắng):");
        end = ReadValidPosition();
        maze[end.Item1, end.Item2] = 'E';
    }

    static (int, int) ReadValidPosition()
    {
        while (true)
        {
            try
            {
                var input = Console.ReadLine().Split();
                int row = int.Parse(input[0]);
                int col = int.Parse(input[1]);

                if (row >= 0 && row < rows && col >= 0 && col < cols && maze[row, col] != WALL)
                {
                    return (row, col);
                }
                else
                {
                    Console.WriteLine("Vị trí không hợp lệ (ngoài phạm vi hoặc là tường). Vui lòng nhập lại:");
                }
            }
            catch
            {
                Console.WriteLine("Định dạng không hợp lệ. Vui lòng nhập lại (vd: 0 0):");
            }
        }
    }

    static void PrintMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                PrintCell(i, j);
            }
            Console.WriteLine();
        }
    }

    static void PrintCell(int i, int j)
    {
        Console.ResetColor();
        switch (maze[i, j])
        {
            case '#': // Tường
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case '.': // Đường đi
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 'S': // Điểm bắt đầu
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 'E': // Điểm kết thúc
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case 'P': // Nhân vật
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case '*': // Đường đã đi
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
        Console.Write(maze[i, j] + " ");
        Console.ResetColor();
    }

    static List<(int, int)> FindShortestPath()
    {
        int[] dRow = { -1, 1, 0, 0 };
        int[] dCol = { 0, 0, -1, 1 };

        Queue<((int, int) position, List<(int, int)> path)> queue = new Queue<((int, int), List<(int, int)>)>();
        HashSet<(int, int)> visited = new HashSet<(int, int)>();

        queue.Enqueue((start, new List<(int, int)> { start }));
        visited.Add(start);

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            var position = current.position;
            var path = current.path;

            if (position == end)
                return path;

            for (int i = 0; i < 4; i++)
            {
                int newRow = position.Item1 + dRow[i];
                int newCol = position.Item2 + dCol[i];

                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols &&
                    !visited.Contains((newRow, newCol)) &&
                    maze[newRow, newCol] != WALL)
                {
                    visited.Add((newRow, newCol));
                    var newPath = new List<(int, int)>(path) { (newRow, newCol) };
                    queue.Enqueue(((newRow, newCol), newPath));
                }
            }
        }
        return null;
    }

    static void MoveAlongPath(List<(int, int)> path)
    {
        foreach (var step in path)
        {
            Console.Clear();

            // Đánh dấu đường đã đi
            if (step != start && step != end)
                maze[step.Item1, step.Item2] = VISITED;

            // Hiển thị nhân vật tại vị trí hiện tại
            maze[step.Item1, step.Item2] = PLAYER;
            PrintMaze();

            // Trả lại ô trước đó thành VISITED nếu không phải điểm bắt đầu/kết thúc
            if (step != start && step != end)
                maze[step.Item1, step.Item2] = VISITED;

            Thread.Sleep(300); // Tạm dừng 0.3 giây
        }
    }
}
