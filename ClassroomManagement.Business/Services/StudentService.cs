using System;
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
			if(AppDbContext<Student>.datas.Count == 0)
			{
				Console.WriteLine("Her hansi bir student tapilmadi.");
				return;
			}
			Console.WriteLine("Telebeler: ");

			foreach(Student student in AppDbContext<Student>.datas)
			{
				student.PrintInfo();
			}
		}

		public void EditStudent()
		{

			if (AppDbContext<Student>.datas.Count == 0)
			{
				Console.WriteLine("Student tapilmadi. ");
				return;
			}


			Student? chosenStudent = ChooseStudent();
			if(chosenStudent is null)
			{
				Console.WriteLine("Telebe tapilmadi! ");
				return;
			}

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

		public Student? ChooseStudent()
		{
            if (AppDbContext<Student>.datas.Count == 0)
            {
                return null;
            }

            ShowStudents();
			Console.Write("Secmek istediyiniz studentin id'ni girin: ");
			int chosenStudentId = int.Parse(Console.ReadLine());

			return AppDbContext<Student>.datas.FirstOrDefault((student) => student.Id == chosenStudentId);
		}

		public void ShowStudentClasses()
		{
            if (AppDbContext<Student>.datas.Count == 0)
            {
                Console.WriteLine("Telebe tapilmadi. ");
                return;
            }
            Student? s1 = ChooseStudent();
            if (s1 is null)
            {
                Console.WriteLine("Telebe tapilmadi! ");
                return;
            }

			List<Class> studentClasses = AppDbContext<Class>.datas.FindAll((classroom) => classroom.students.Contains(s1));


			if(studentClasses.Count == 0)
			{
				Console.WriteLine("Telebe her hansi bir classda deyil.");
				return;
			}

			Console.WriteLine("Telebenin oldugu class(lar).");

			foreach(Class classroom in studentClasses)
			{
                classroom.PrintInfo();
			}

        }

		public void Delete()
		{
            if (AppDbContext<Student>.datas.Count == 0)
            {
                Console.WriteLine("Telebe tapilmadi. ");
                return;
            }
            Student? chosenStudent = ChooseStudent();
            if (chosenStudent is null)
            {
                Console.WriteLine("Telebe tapilmadi! ");
                return;
            }

			AppDbContext<Student>.datas.Remove(chosenStudent);
        }




    }
}

