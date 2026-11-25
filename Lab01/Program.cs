using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab01_02
{
    class Student
    {
        private int id;
        private string name;
        private int age;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Student()
        {
        }

        public Student(int id, string name, int age)
        {
            this.id = id;
            this.name = name;
            this.age = age;
        }

        public void Show()
        {
            Console.WriteLine("ID: {0} | Tên: {1} | Tuổi: {2}", this.Id, this.Name, this.Age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Student> studentList = new List<Student>
            {
                new Student(1, "An", 16),
                new Student(2, "Bình", 14),
                new Student(3, "Anh", 18),
                new Student(4, "Cường", 19),
                new Student(5, "Dũng", 15),
                new Student(6, "Em", 17)
            };

            Console.WriteLine("1. Toàn bộ danh sách học sinh:");
            DisplayStudentList(studentList);
            Console.WriteLine();

            Console.WriteLine("2. Danh sách học sinh có tuổi từ 15 đến 18:");
            DisplayStudentsByAgeRange(studentList, 15, 18);
            Console.WriteLine();

            Console.WriteLine("3. Danh sách học sinh có tên bắt đầu bằng chữ \"A\":");
            DisplayStudentsByNamePrefix(studentList, "A");
            Console.WriteLine();

            Console.WriteLine("4. Tổng tuổi của tất cả học sinh:");
            DisplayTotalAge(studentList);
            Console.WriteLine();

            Console.WriteLine("5. Học sinh có tuổi lớn nhất:");
            DisplayOldestStudents(studentList);
            Console.WriteLine();

            Console.WriteLine("6. Danh sách học sinh sắp xếp theo tuổi tăng dần:");
            SortStudentsByAgeAscending(studentList);
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }

        static void DisplayStudentsByAgeRange(List<Student> studentList, int minAge, int maxAge)
        {
            var students = studentList.Where(s => s.Age >= minAge && s.Age <= maxAge).ToList();
            DisplayStudentList(students);
        }

        static void DisplayStudentsByNamePrefix(List<Student> studentList, string prefix)
        {
            var students = studentList.Where(s => s.Name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        static void DisplayTotalAge(List<Student> studentList)
        {
            int totalAge = studentList.Sum(s => s.Age);
            Console.WriteLine("Tổng tuổi: {0}", totalAge);
        }

        static void DisplayOldestStudents(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }
            int maxAge = studentList.Max(s => s.Age);
            var oldestStudents = studentList.Where(s => s.Age == maxAge).ToList();
            DisplayStudentList(oldestStudents);
        }

        static void SortStudentsByAgeAscending(List<Student> studentList)
        {
            var sortedStudents = studentList.OrderBy(s => s.Age).ToList();
            DisplayStudentList(sortedStudents);
        }
    }
}