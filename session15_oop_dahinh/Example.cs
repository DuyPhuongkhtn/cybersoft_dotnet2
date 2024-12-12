abstract class Animal {
    private string name;
    public string Name {
        get { return name; }
        set { name = value; }
    }

    public Animal(string name) {
        this.name = name;
    }

    public abstract void Speak();
    public abstract void displayInfo();
}

class Dog: Animal {
    private string breed; // giống cún
    public string Breed {
        get { return breed; }
        set { breed = value; }
    }

    public Dog(string name, string breed): base(name) {
        this.breed = breed;
    }

    public override void Speak(){
        Console.WriteLine("Gâu gâu");
    }

    public override void displayInfo()
    {
        Console.WriteLine($"Name: {Name}, Breed: {Breed}");
    }
}

class Cat: Animal {
    private string color;
    public string Color {
        get { return color; }
        set { color = value; }
    }

    public Cat(string name, string color): base(name) {
        this.color = color;
    }

    public override void Speak() {
        Console.WriteLine("Meo meo");
    }

    public override void displayInfo(){
        Console.WriteLine($"Name: {Name}, Color: {Color}");
    }
}