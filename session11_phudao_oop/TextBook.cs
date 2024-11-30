class TextBook: Book {
    public string subject;
    public string grade;

    public TextBook(
        string bookId,
        string bookName,
        string author,
        double price,
        string subject,
        string grade
    ): base(bookId, bookName, author, price) {
        this.subject = subject;
        this.grade = grade;
    }

    public override void displayInfo(){
        base.displayInfo(); // gọi lại phương thức displayInfo() của class cha
        Console.WriteLine($"Subject: {subject}, Grade: {grade}");
    }
}