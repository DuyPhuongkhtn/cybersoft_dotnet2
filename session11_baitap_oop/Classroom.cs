class Classroom {
    // thuộc tính
    public string classId;
    public string className;
    public List<Student> students;

    // constructor
    public Classroom(string classId, string className) {
        this.classId = classId;
        this.className = className;
        this.students = new List<Student>();
    }

    //  phương thức thêm sinh viên vào lớp
    public void addStudent(Student student) {
        students.Add(student);
        Console.WriteLine($"Student {student.studentName} added to class {className}");
    }

    // phương thức hiển thị dánh sách sinh viên trong lớp
    public void showStudents() {
        Console.WriteLine($"\n ----Students in class {className}----");
        foreach (Student student in students) {
            // Console.WriteLine($"Student ID: {student.studentId}, Student Name: {student.studentName}, Age: {student.age}");
            student.displayInfo();
        }
    }

    // phương thức tìm kiếm sinh viên theo mã sinh viên
    public void findStudentByStudentId(string studentId) {
        // C1: Dùng vòng lặp
        foreach (Student student in students) {
            if(student.studentId == studentId) {
                student.displayInfo();
                return;
            }
        }
        // trong trường hợp duyệt hết danh sách mà không có sinh viên nào.
        Console.WriteLine($"Student with ID {studentId} not found in class {className}");
    }
}