using System;

class Program
{
    static void Main()
    {
        // ╔ ═ ╦ ║ ╚ ╩ ╝
        var game = new Game2048();

        while (true)
        {
            Console.Clear();
            game.PrintGrid();

            if (game.IsGameOver())
            {
                Console.WriteLine("Game Over!");
                break;
            }

            ConsoleKeyInfo key = Console.ReadKey(true); // Đọc phím nhấn từ người dùng
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    game.Move("up");
                    break;
                case ConsoleKey.DownArrow:
                    game.Move("down");
                    break;
                case ConsoleKey.LeftArrow:
                    game.Move("left");
                    break;
                case ConsoleKey.RightArrow:
                    game.Move("right");
                    break;
                default:
                    Console.WriteLine("Invalid key pressed. Use arrow keys.");
                    break;
            }
        }
    }
}
