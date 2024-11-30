class Book {
    public string bookId;
    public string bookName;
    public string author;
    public double price;

    public Book(string bookId, string bookName, string author, double price) {
        this.bookId = bookId;
        this.bookName = bookName;
        this.author = author;
        this.price = price;
    }

    // dùng virtual để cho phép các class con override lại phương thức này
    // override: ghi đè
    // - dùng lại phương thức của class cha
    // - thay đổi cách thức hoạt động của phương thức
    public virtual void displayInfo() {
        Console.WriteLine($"Book ID: {bookId}, Book Name: {bookName}, Author: {author}, Price: {price}");
    }
}