class ReferenceBook: Book {
    public string topic;
    public string publisher;

    public ReferenceBook(
        string bookId,
        string bookName,
        string author,
        double price,
        string topic,
        string publisher
    ): base(bookId, bookName, author, price) {
        this.topic = topic;
        this.publisher = publisher;
    }

    public override void displayInfo(){
        base.displayInfo(); // gọi lại phương thức displayInfo() của class cha
        Console.WriteLine($"Topic: {topic}, Publisher: {publisher}");
    }
}