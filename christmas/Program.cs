using System;
using System.Threading;

class ChristmasCard
{
    static void Main()
    {
        Console.Clear();

        // Hiệu ứng tuyết rơi kết hợp cây thông và lời chúc
        CombinedEffect();

        // Reset màu sắc console
        Console.ResetColor();

        Console.WriteLine("\nNhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }

    
    static void CombinedEffect()
    {
        Random rand = new Random();
        int width = Console.WindowWidth;
        int height = Console.WindowHeight - 5; // Dành không gian cho cây thông và lời chúc
        char[] snowChars = { '*', '.', '+', '❄', ' ' }; // Ký tự tuyết

        string[] tree = {
            "        *        ",
            "       ***       ",
            "      *****      ",
            "     *******     ",
            "    *********    ",
            "   ***********   ",
            "  *************  ",
            " *************** ",
            "        ||        "
        };

        string[] wishes = {
            "🎄 Chúc bạn một mùa Giáng sinh an lành và hạnh phúc!",
            "✨ Tràn đầy niềm vui và tình yêu thương!",
            "🎅 Chúc mừng năm mới 2025!",
            "❤️ Hãy tận hưởng những khoảnh khắc tuyệt vời bên gia đình và bạn bè!",
            "❄️ Nguyện chúc phước lành đến với bạn và người thân!"
        };

        // Khởi tạo màn hình tuyết rơi
        char[,] snowScreen = new char[height, width];

        // Hiển thị tuyết rơi
        while (true)
        {
            // Cập nhật tuyết rơi
            for (int row = height - 1; row > 0; row--)
            {
                for (int col = 0; col < width; col++)
                {
                    snowScreen[row, col] = snowScreen[row - 1, col];
                }
            }

            // Tạo tuyết mới
            for (int col = 0; col < width; col++)
            {
                snowScreen[0, col] = rand.Next(10) < 2 ? snowChars[rand.Next(snowChars.Length)] : ' ';
            }

            // Hiển thị tuyết rơi
            Console.Clear();
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    Console.ForegroundColor = snowScreen[row, col] == ' ' ? ConsoleColor.Black : ConsoleColor.White;
                    Console.Write(snowScreen[row, col]);
                }
                Console.WriteLine();
            }

            // Hiển thị nhiều cây thông Noel ở giữa màn hình
            for (int treeIndex = 0; treeIndex < 2; treeIndex++) // Draw two trees
            {
                Console.ForegroundColor = ConsoleColor.Green;

                int treeStartRow = height / 2 - tree.Length / 2;
                int treeStartCol = (width / 3) * (treeIndex + 1) - tree[0].Length / 2;

                // Draw each tree with colored lights
                for (int i = 0; i < tree.Length - 1; i++) // Exclude the trunk from the tree part
                {
                    Console.SetCursorPosition(treeStartCol, treeStartRow + i);
                    string line = tree[i];

                    // Randomly color tree lights (simulating Christmas lights)
                    char[] lineChars = line.ToCharArray();
                    for (int j = 0; j < lineChars.Length; j++)
                    {
                        if (lineChars[j] == '*') // Where lights can be
                        {
                            Console.ForegroundColor = GetRandomLightColor();
                        }
                        Console.Write(lineChars[j]);
                    }
                    Console.ResetColor(); // Reset color after drawing each line
                }

                // Now draw the tree trunk
                Console.ForegroundColor = ConsoleColor.DarkYellow; // Color for the tree trunk
                Console.SetCursorPosition(treeStartCol, treeStartRow + tree.Length - 1);
                Console.Write(tree[tree.Length - 1]); // Draw the trunk
                Console.ResetColor(); // Reset the color after drawing the trunk
            }

            // Hiển thị lời chúc ở dưới cùng
            Console.ForegroundColor = ConsoleColor.Red;
            int wishStartRow = height - wishes.Length;
            for (int i = 0; i < wishes.Length; i++)
            {
                Console.SetCursorPosition((width - wishes[i].Length) / 2, wishStartRow + i);
                Console.Write(wishes[i]);
            }

            Thread.Sleep(100); // Tốc độ khung hình
        }
    }

    // Hàm chọn màu ngẫu nhiên cho đèn Noel
    static ConsoleColor GetRandomLightColor()
    {
        Random rand = new Random();
        ConsoleColor[] lightColors = {
            ConsoleColor.Yellow,
            ConsoleColor.Cyan,
            ConsoleColor.Red,
            ConsoleColor.Magenta,
            ConsoleColor.Green,
            ConsoleColor.Blue
        };

        return lightColors[rand.Next(lightColors.Length)];
    }
}
