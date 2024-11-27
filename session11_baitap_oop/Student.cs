class Student {
    public string studentId;
    public string studentName;
    public int age;

    public Student(string studentId, string studentName, int age) {
        this.studentId = studentId;
        this.studentName = studentName;
        this.age = age;
    }

    // phương thức hiển thị thông tin sinh viên
    public void displayInfo() {
        Console.WriteLine($"ID: {studentId}, Name: {studentName}, Age: {age}");
    }
}