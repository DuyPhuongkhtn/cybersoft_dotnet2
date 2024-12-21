using System;
using System.Collections.Generic;
using System.Linq;

class Game2048
{
    private static readonly int GridSize = 4;
    private List<List<int>> grid;
    private Random random;

    public Game2048()
    {
        grid = new List<List<int>>();
        random = new Random();

        // Khởi tạo lưới grid với giá trị 0
        for (int i = 0; i < GridSize; i++)
        {
            grid.Add(new List<int>(new int[GridSize])); // Tạo một hàng với các giá trị 0
        }

        AddNewTile();
        AddNewTile();
    }

    public void PrintGrid()
    {
        Console.Clear();
        Console.WriteLine("╔═════╦═════╦═════╦═════╗");

        for (int i = 0; i < GridSize; i++)
        {
            Console.Write("║");
            for (int j = 0; j < GridSize; j++)
            {
                int value = grid[i][j];
                string cellContent = value == 0 ? "     " : value.ToString().PadLeft((5 + value.ToString().Length) / 2).PadRight(5);

                SetCellColor(value);
                Console.Write(cellContent);
                Console.ResetColor();
                Console.Write("║");
            }
            Console.WriteLine();

            if (i < GridSize - 1)
            {
                Console.WriteLine("╠═════╬═════╬═════╬═════╣");
            }
        }

        Console.WriteLine("╚═════╩═════╩═════╩═════╝");
    }

    private void SetCellColor(int value)
    {
        switch (value)
        {
            case 0:
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2:
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 4:
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 8:
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case 16:
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
            case 32:
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 64:
                Console.BackgroundColor = ConsoleColor.Magenta;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 128:
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 256:
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 512:
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 1024:
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case 2048:
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.White;
                break;
            default:
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                break;
        }
    }

    public void Move(string direction)
    {
        switch (direction.ToLower())
        {
            case "up":
                MoveUp();
                break;
            case "down":
                MoveDown();
                break;
            case "left":
                MoveLeft();
                break;
            case "right":
                MoveRight();
                break;
            default:
                Console.WriteLine("Invalid move. Use: up, down, left, right.");
                return;
        }

        AddNewTile();
    }

    private void MoveUp()
    {
        for (int col = 0; col < GridSize; col++)
        {
            var temp = GetColumn(col);
            temp = Combine(temp);
            SetColumn(col, temp);
        }
    }

    private void MoveDown()
    {
        for (int col = 0; col < GridSize; col++)
        {
            var temp = GetColumn(col);
            temp.Reverse();
            temp = Combine(temp);
            temp.Reverse();
            SetColumn(col, temp);
        }
    }

    private void MoveLeft()
    {
        for (int row = 0; row < GridSize; row++)
        {
            var temp = GetRow(row);
            temp = Combine(temp);
            SetRow(row, temp);
        }
    }

    private void MoveRight()
    {
        for (int row = 0; row < GridSize; row++)
        {
            var temp = GetRow(row);
            temp.Reverse();
            temp = Combine(temp);
            temp.Reverse();
            SetRow(row, temp);
        }
    }

    private List<int> GetRow(int row)
    {
        return new List<int>(grid[row]);
    }

    private void SetRow(int row, List<int> values)
    {
        grid[row] = values;
    }

    private List<int> GetColumn(int col)
    {
        return grid.Select(row => row[col]).ToList();
    }

    private void SetColumn(int col, List<int> values)
    {
        for (int row = 0; row < GridSize; row++)
        {
            grid[row][col] = values[row];
        }
    }

    private List<int> Combine(List<int> line)
    {
        var newLine = line.Where(x => x != 0).ToList(); // Xóa các ô trống
        for (int i = 0; i < newLine.Count - 1; i++)
        {
            if (newLine[i] == newLine[i + 1])
            {
                newLine[i] *= 2;
                newLine[i + 1] = 0;
            }
        }
        newLine = newLine.Where(x => x != 0).ToList(); // Xóa lại các ô trống
        while (newLine.Count < GridSize)
        {
            newLine.Add(0);
        }
        return newLine;
    }

    private void AddNewTile()
    {
        var emptyCells = new List<(int, int)>();
        for (int i = 0; i < GridSize; i++)
        {
            for (int j = 0; j < GridSize; j++)
            {
                if (grid[i][j] == 0)
                {
                    emptyCells.Add((i, j));
                }
            }
        }

        if (emptyCells.Count == 0) return;

        var (row, col) = emptyCells[random.Next(emptyCells.Count)];
        grid[row][col] = random.Next(1, 101) <= 90 ? 2 : 4;
    }

    public bool IsGameOver()
    {
        for (int row = 0; row < GridSize; row++)
        {
            for (int col = 0; col < GridSize; col++)
            {
                if (grid[row][col] == 0)
                    return false;
                if (col + 1 < GridSize && grid[row][col] == grid[row][col + 1])
                    return false;
                if (row + 1 < GridSize && grid[row][col] == grid[row + 1][col])
                    return false;
            }
        }
        return true;
    }
}
