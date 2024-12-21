abstract class Animal
{
    public string Name { get; set; }
    public abstract void Speak();
    public abstract void displayInfo();
}

class Dog : Animal
{
    public string Breed { get; set; }

    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }

    public override void displayInfo()
    {
        Console.WriteLine($"Dog info: {Breed}");
    }
}

class Cat : Animal
{
    public int Age { get; set; }

    public override void Speak()
    {
        Console.WriteLine("Cat meows");
    }

    public override void displayInfo()
    {
        Console.WriteLine($"Cat info: {Age}");
    }
}
