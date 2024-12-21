using System;
using System.Threading;

class TetrisGame
{
    static int[,] grid = new int[20, 10]; // Lưới trò chơi
    static int score = 0;                // Điểm số
    static int speed = 150;              // Tốc độ khối rơi (ms)

    static void Main()
    {
        Console.CursorVisible = false;   // Ẩn con trỏ
        Console.Title = "Tetris Game";   // Tiêu đề cửa sổ

        DrawFrame();                     // Vẽ khung bao quanh

        while (true)
        {
            int[,] block = GenerateBlock(); // Khối mới
            int x = 0, y = 4;              // Vị trí khởi đầu

            bool blockPlaced = false;
            while (!blockPlaced)
            {
                // Xử lý di chuyển theo phím
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (CanMove(block, x, y - 1)) y--;
                            break;
                        case ConsoleKey.RightArrow:
                            if (CanMove(block, x, y + 1)) y++;
                            break;
                        case ConsoleKey.DownArrow:
                            if (CanMove(block, x + 1, y)) x++;
                            break;
                        case ConsoleKey.Spacebar:
                            block = RotateBlock(block);
                            if (!CanMove(block, x, y)) block = RotateBlock(block, true); // Undo xoay nếu va chạm
                            break;
                    }
                }

                // Tự động rơi xuống
                if (CanMove(block, x + 1, y))
                {
                    ClearBlock(block, x, y);
                    x++;
                }
                else
                {
                    PlaceBlock(block, x, y);
                    blockPlaced = true;
                }

                // Vẽ lưới và khối
                DrawGrid();
                DrawBlock(block, x, y);
                Thread.Sleep(speed);
            }

            // Kiểm tra hàng đầy và xử lý
            ClearFullLines();

            // Kiểm tra điều kiện game over
            if (IsGameOver())
            {
                Console.Clear();
                Console.WriteLine($"Game Over! Your score: {score}");
                break;
            }
        }
    }

    static void DrawFrame()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < 22; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                if (i == 0 || i == 21 || j == 0 || j == 11)
                {
                    Console.SetCursorPosition(j * 2, i);
                    Console.Write("■");
                }
            }
        }
        Console.ResetColor();
    }

    static int[,] GenerateBlock()
    {
        Random rand = new Random();
        int type = rand.Next(5);
        return type switch
        {
            0 => new int[,] { { 1, 1, 1, 1 } }, // Khối I
            1 => new int[,] { { 1, 1 }, { 1, 1 } }, // Khối O
            2 => new int[,] { { 0, 1, 0 }, { 1, 1, 1 } }, // Khối T
            3 => new int[,] { { 1, 1, 0 }, { 0, 1, 1 } }, // Khối Z
            4 => new int[,] { { 0, 1, 1 }, { 1, 1, 0 } }, // Khối S
            _ => new int[,] { { 1, 1, 1 }, { 1, 0, 0 } }, // Khối L
        };
    }

    static int[,] RotateBlock(int[,] block, bool undo = false)
    {
        int rows = block.GetLength(0);
        int cols = block.GetLength(1);
        int[,] rotated = new int[cols, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                rotated[j, rows - 1 - i] = undo ? block[rows - 1 - i, j] : block[i, j];
            }
        }
        return rotated;
    }

    static bool CanMove(int[,] block, int x, int y)
    {
        for (int i = 0; i < block.GetLength(0); i++)
        {
            for (int j = 0; j < block.GetLength(1); j++)
            {
                if (block[i, j] == 1)
                {
                    int newX = x + i;
                    int newY = y + j;

                    // Kiểm tra biên và va chạm
                    if (newX < 0 || newX >= 20 || newY < 0 || newY >= 10 || grid[newX, newY] == 1)
                        return false;
                }
            }
        }
        return true;
    }

    static void PlaceBlock(int[,] block, int x, int y)
    {
        for (int i = 0; i < block.GetLength(0); i++)
        {
            for (int j = 0; j < block.GetLength(1); j++)
            {
                if (block[i, j] == 1)
                {
                    grid[x + i, y + j] = 1;
                }
            }
        }
    }

    static void ClearFullLines()
    {
        for (int i = 0; i < 20; i++)
        {
            bool isFull = true;
            for (int j = 0; j < 10; j++)
            {
                if (grid[i, j] == 0)
                {
                    isFull = false;
                    break;
                }
            }
            if (isFull)
            {
                score += 100;
                for (int k = i; k > 0; k--)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        grid[k, j] = grid[k - 1, j];
                    }
                }
                for (int j = 0; j < 10; j++)
                {
                    grid[0, j] = 0;
                }
            }
        }
    }

    static bool IsGameOver()
    {
        for (int j = 0; j < 10; j++)
        {
            if (grid[0, j] == 1) return true;
        }
        return false;
    }

    static void DrawGrid()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.SetCursorPosition((j + 1) * 2, i + 1);
                Console.Write(grid[i, j] == 1 ? "■" : " ");
            }
        }
    }

    static void DrawBlock(int[,] block, int x, int y)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        for (int i = 0; i < block.GetLength(0); i++)
        {
            for (int j = 0; j < block.GetLength(1); j++)
            {
                if (block[i, j] == 1)
                {
                    Console.SetCursorPosition((y + j + 1) * 2, x + i + 1);
                    Console.Write("■");
                }
            }
        }
    }

    static void ClearBlock(int[,] block, int x, int y)
    {
        for (int i = 0; i < block.GetLength(0); i++)
        {
            for (int j = 0; j < block.GetLength(1); j++)
            {
                if (block[i, j] == 1)
                {
                    Console.SetCursorPosition((y + j + 1) * 2, x + i + 1);
                    Console.Write(" ");
                }
            }
        }
    }
}
