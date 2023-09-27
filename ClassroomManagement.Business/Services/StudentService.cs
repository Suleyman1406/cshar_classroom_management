using System;
using ClassroomManagement.Core.Exceptions;
using ClassroomManagement.Core.Models;
using DataAccess.Context;

namespace ClassroomManagement.Business.Services
{
    public class StudentService
    {
        public StudentService()
        {
        }

        public void Add()
        {
            Console.Write("Ad gir: ");
            string name = Console.ReadLine();
            Console.Write("Yas gir: ");
            int age = int.Parse(Console.ReadLine());

            Student student = new Student(name, age);
            AppDbContext<Student>.datas.Add(student);
        }

        public void ShowStudents()
        {
            if (AppDbContext<Student>.datas.Count == 0)
            {
                throw new StudentNotFoundException("There is no student!");
            }
            Console.WriteLine("Telebeler: ");

            foreach (Student student in AppDbContext<Student>.datas)
            {
                student.PrintInfo();
            }
        }

        public void EditStudent()
        {

            Student chosenStudent = ChooseStudent();

            Console.WriteLine("\nTapilan user bilgisi:");
            chosenStudent.PrintInfo();

            Console.Write("Ad gir: ");
            string name = Console.ReadLine();
            Console.Write("Yas gir: ");
            int age = int.Parse(Console.ReadLine());

            chosenStudent.Name = name;
            chosenStudent.Age = age;

            Console.WriteLine("Edit tamamlandi");

        }

        public Student ChooseStudent()
        {
            ShowStudents();
            Console.Write("Secmek istediyiniz studentin id'ni girin: ");
            int chosenStudentId = int.Parse(Console.ReadLine());

            Student? student = AppDbContext<Student>.datas.FirstOrDefault((student) => student.Id == chosenStudentId);

            if (student is null)
            {
                throw new StudentNotFoundException($"Student not found with id {chosenStudentId}");
            }

            return student;
        }

        public void ShowStudentClasses()
        {
            Student s1 = ChooseStudent();

            List<Class> studentClasses = AppDbContext<Class>.datas.FindAll((classroom) => classroom.students.Contains(s1));


            if (studentClasses.Count == 0)
            {
                Console.WriteLine("Telebe her hansi bir classda deyil.");
                return;
            }

            Console.WriteLine("Telebenin oldugu class(lar).");

            foreach (Class classroom in studentClasses)
            {
                classroom.PrintInfo();
            }

        }

        public void Delete()
        {
            Student chosenStudent = ChooseStudent();
            AppDbContext<Student>.datas.Remove(chosenStudent);
        }




    }
}

