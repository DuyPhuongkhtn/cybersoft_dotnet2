using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Animal dog = new Dog("Lulu", "Husky");
        dog.Speak(); // lấy hàm Speak của class Dog
        dog.displayInfo(); // lấy hàm displayInfo của class Dog

        // Dùng class Animal để đại diện cho các class con
        List<Animal> animals = new List<Animal>();

        // tạo đối tượng Dog
        Dog dog1 = new Dog("Hehe", "Bulldog");

        // add dog1 vào list animals
        animals.Add(dog1);

        // tạo đối tượng Cat
        Cat cat = new Cat("Meo", "White");
        // add đối tượng cat vào list animals
        animals.Add(cat);

        // in ra list animals
        foreach(var animal in animals) {
            animal.Speak();
            animal.displayInfo();
            Console.WriteLine("========");
        }

        // Lưu list animals vào file json
        // lưu thêm type object vào file json
        // để khi load file lên, ta biết được object nào là Dog, Cat
        // dùng Newtonsoft để lưu type object vào file json
        string json = JsonConvert.SerializeObject(animals, new JsonSerializerSettings {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented
        });
        File.WriteAllText("animals.json", json);
        Console.WriteLine("Lưu file thành công!");

        // Đọc file json
        string jsonFromFile = File.ReadAllText("animals.json");
        List<Animal>? animals1 = 
            JsonConvert.DeserializeObject<List<Animal>>(jsonFromFile, new JsonSerializerSettings {
            TypeNameHandling = TypeNameHandling.All
        });
        Console.WriteLine("Đọc file trước khi update");
        // Root cause:
        // Lỗi vì khi load file lên thì các object trong list animals1
        // không phải là Dog hoặc Cat, mà là Animal

        // Solution
        // Để fix lỗi này, ta cần lưu type của object vào file json
        // để khi load file lên, ta biết được  object nào là Dog,
        // class nào là Cat. Thư viện Newtonsoft.Json sẽ giúp mình làm việc này
        foreach(var animal in animals1) {
            animal.Speak();
            animal.displayInfo();
            Console.WriteLine("========");
        }
    }
}