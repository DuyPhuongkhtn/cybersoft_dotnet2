class Effect1
{
    public void effect()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Để hiển thị biểu tượng đặc biệt
        Console.CursorVisible = false;

        string[] tree = {
            "         *         ",
            "        ***        ",
            "       *****       ",
            "      *******      ",
            "     *********     ",
            "    ***********    ",
            "   *************   ",
            "  ***************  ",
            " ***************** ",
            "        |||        ",
            "        |||        "
        };

        Random rand = new Random();
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        // Tạo hiệu ứng tuyết rơi
        char[] snowflakes = { '.', '*', '+', 'o' };

        while (true)
        {
            Console.Clear();

            // Vẽ cây thông
            for (int i = 0; i < tree.Length; i++)
            {
                Console.SetCursorPosition((width - tree[i].Length) / 2, height / 2 - tree.Length / 2 + i);
                foreach (var ch in tree[i])
                {
                    if (ch == '*')
                        Console.ForegroundColor = (ConsoleColor)rand.Next(9, 16); // Màu ngẫu nhiên cho ánh sáng
                    else
                        Console.ForegroundColor = ConsoleColor.Green;

                    Console.Write(ch);
                }
            }

            // Hiệu ứng tuyết rơi
            for (int i = 0; i < 50; i++)
            {
                int snowX = rand.Next(0, width);
                int snowY = rand.Next(0, height / 2);

                Console.SetCursorPosition(snowX, snowY);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(snowflakes[rand.Next(snowflakes.Length)]);
            }

            Thread.Sleep(150); // Tạo hiệu ứng chớp sáng
        }
    }
}