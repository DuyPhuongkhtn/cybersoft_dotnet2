using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

// live game rắn săn mồi => code
// tuần sau: live game xếp hình (teris) => code
// tuần sau nữa: live game caro có AI (minimax) => đang code
// tuần sau nữa: live web chat realtime (signalR), có thể có deploy => plan
// tuần sau nữa: live thuật toán tìm đường đi ngắn nhất (Dijstra)
//.....
// gần tới va lung tung: web tỏ tình bằng c#

class SnakeGame
{
    private static int screenWidth = 60;
    private static int screenHeight = 30;
    private static int score = 0;
    private static List<(int, int)> snake = new List<(int, int)>() { (10, 10) };
    private static (int, int) food = (15, 10);
    private static (int, int) direction = (1, 0);
    private static bool gameOver = false;

    static void Main()
    {
        Console.CursorVisible = false;
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DrawBorder();
        SpawnFood();
        while (!gameOver)
        {
            HandleInput();
            Update();
            Draw();
            Thread.Sleep(150); // Tốc độ di chuyển của rắn chậm hơn
        }
        Console.Clear();
        Console.WriteLine($"Game Over! Your score: {score}");
    }

    private static void DrawBorder()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        for (int y = 0; y <= screenHeight; y++)
        {
            for (int x = 0; x <= screenWidth; x++)
            {
                if (x == 0 || x == screenWidth || y == 0 || y == screenHeight)
                    Console.Write("#");
                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }

    private static void SpawnFood()
    {
        Random rand = new Random();
        do
        {
            food = (rand.Next(1, screenWidth - 1), rand.Next(1, screenHeight - 1));
        } while (snake.Contains(food));
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(food.Item1, food.Item2);
        Console.Write("♥"); // Biểu tượng đồ ăn đẹp hơn
        Console.ResetColor();
    }

    private static void HandleInput()
    {
        if (!Console.KeyAvailable) return;

        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (direction != (0, 1)) direction = (0, -1);
                break;
            case ConsoleKey.DownArrow:
                if (direction != (0, -1)) direction = (0, 1);
                break;
            case ConsoleKey.LeftArrow:
                if (direction != (1, 0)) direction = (-1, 0);
                break;
            case ConsoleKey.RightArrow:
                if (direction != (-1, 0)) direction = (1, 0);
                break;
        }
    }

    private static void Update()
    {
        var head = snake.Last();
        var newHead = (head.Item1 + direction.Item1, head.Item2 + direction.Item2);

        // Kiểm tra va chạm
        if (newHead.Item1 <= 0 || newHead.Item1 >= screenWidth ||
            newHead.Item2 <= 0 || newHead.Item2 >= screenHeight ||
            snake.Contains(newHead))
        {
            gameOver = true;
            return;
        }

        snake.Add(newHead);

        if (newHead == food)
        {
            score++;
            SpawnFood();
        }
        else
        {
            var tail = snake.First();
            snake.RemoveAt(0);
            Console.SetCursorPosition(tail.Item1, tail.Item2);
            Console.Write(" ");
        }
    }

    private static void Draw()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        foreach (var segment in snake)
        {
            Console.SetCursorPosition(segment.Item1, segment.Item2);
            Console.Write("■"); // Biểu tượng thân rắn đẹp hơn
        }
        Console.ResetColor();
    }
}
