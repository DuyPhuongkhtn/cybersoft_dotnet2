class Effect2 {
    public void effect() {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // để hiện thị những ký tự đặc biệt
        Console.CursorVisible = false; // ẩn con trỏ

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
        int width = Console.WindowWidth; // lấy chiều rộng của cửa sổ console
        int height = Console.WindowHeight; // lấy chiều cao của cửa sổ console

        // tạo hiệu ứng tuyết rơi
        char[] snowflakes = {'.', '*', '+', 'o', '-'}; // các ký tự tuyết rơi

        // while (true) {
        //     Console.Clear(); // xóa

        //     // vẽ cây thông
        //     // for(int  i = 0; )
        // }
    }
}