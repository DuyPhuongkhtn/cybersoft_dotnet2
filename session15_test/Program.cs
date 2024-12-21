using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Animal> animals = new List<Animal>();

        // Nhập dữ liệu cho Dog
        Console.WriteLine("Enter details for Dog:");
        Console.Write("Enter the name of the dog: ");
        string dogName = Console.ReadLine();
        Console.Write("Enter the breed of the dog: ");
        string dogBreed = Console.ReadLine();

        Dog dog = new Dog
        {
            Name = dogName,
            Breed = dogBreed
        };
        animals.Add(dog);

        // Nhập dữ liệu cho Cat
        Console.WriteLine("\nEnter details for Cat:");
        Console.Write("Enter the name of the cat: ");
        string catName = Console.ReadLine();
        Console.Write("Enter the age of the cat: ");
        int catAge;
        while (!int.TryParse(Console.ReadLine(), out catAge))
        {
            Console.Write("Invalid input. Please enter a valid age for the cat: ");
        }

        Cat cat = new Cat
        {
            Name = catName,
            Age = catAge
        };
        animals.Add(cat);
        Console.WriteLine("ahihi");
        animals[1].displayInfo();

        // Hiển thị danh sách động vật
        Console.WriteLine("\nList of animals:");
        foreach (var animal in animals)
        {
            Console.WriteLine($"{animal.Name} says:");
            animal.Speak();
        }

        // Serialize dữ liệu thành JSON
        string json = JsonConvert.SerializeObject(animals, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        });

        Console.WriteLine("\nSerialized JSON:");
        Console.WriteLine(json);

        // Đọc dữ liệu JSON từ file
        string json1 = File.ReadAllText("animals.json");

        // Deserialize lại dữ liệu, Newtonsoft.Json sẽ tự động ép kiểu về các lớp con đúng
        List<Animal> animals1 = JsonConvert.DeserializeObject<List<Animal>>(json1, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All
        });

        foreach (var animal in animals1)
        {
            Console.WriteLine($"{animal.Name} says:");
            animal.Speak();  // Gọi phương thức Speak của từng lớp cụ thể (Dog, Cat)
            Console.WriteLine("======");
            animal.displayInfo();  // Gọi phương thức displayInfo của từng lớp cụ thể (Dog, Cat)
        }
    }
}