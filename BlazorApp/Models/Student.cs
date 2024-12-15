namespace BlazorApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Encapsulation: Use private fields with public properties
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (!value.Contains("@"))
                {
                    throw new ArgumentException("Invalid email format.");
                }
                _email = value;
            }
        }

        // Constructor Overloading (Polymorphism)
        public Student() { }

        public Student(int id, string name, int age, string email)
        {
            Id = id;
            Name = name;
            Age = age;
            Email = email;
        }
        // Method Overloading (Polymorphism)
        public void UpdateDetails(string name)
        {
            Name = name;
        }

        public void UpdateDetails(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Inheritance and Abstraction: Use a base class for shared properties
        public override string ToString()
        {
            return $"Student: {Name}, Age: {Age}, Email: {Email}";
        }
    }

    public class UndergraduateStudent : Student
    {
        public string Major { get; set; }

        public UndergraduateStudent(int id, string name, int age, string email, string major)
            : base(id, name, age, email)
        {
            Major = major;
        }

        public override string ToString()
        {
            return base.ToString() + $", Major: {Major}";
        }
    }

    public class GraduateStudent : Student
    {
        public string ResearchTopic { get; set; }

        public GraduateStudent(int id, string name, int age, string email, string researchTopic)
            : base(id, name, age, email)
        {
            ResearchTopic = researchTopic;
        }

        public override string ToString()
        {
            return base.ToString() + $", Research Topic: {ResearchTopic}";
        }
    }
}
