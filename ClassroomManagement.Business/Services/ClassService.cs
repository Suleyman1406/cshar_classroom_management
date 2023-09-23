using System;
using ClassroomManagement.Core.Models;
using DataAccess.Context;

namespace ClassroomManagement.Business.Services
{
	public class ClassService
	{
		public void Add()
		{
            Console.Write("Title gir: ");
            string name = Console.ReadLine();
            Console.Write("Desc gir: ");
            string desc = Console.ReadLine();

            Class classroom = new Class(name, desc);

            AppDbContext<Class>.datas.Add(classroom);
        }

        public void ShowClasses()
        {
            if (AppDbContext<Class>.datas.Count == 0)
            {
                Console.WriteLine("Her hansi bir class tapilmadi.");
                return;
            }
            Console.WriteLine("Classlar: ");

            foreach (Class classroom in AppDbContext<Class>.datas)
            {
                classroom.PrintInfo();
            }
        }

        public void AddStudentToClass(Student student)
        {
            Class? chosenClass = ChooseClass();
            if(chosenClass is null)
            {
                Console.WriteLine("Class Tapilmadi");
                return;
            }

            if (chosenClass.students.Contains(student))
            {
                Console.WriteLine("Bu classa telebe daha once elave edilib.");
                return;
            }

            chosenClass.students.Add(student);
            Console.WriteLine("Telebe classa elave edildi");
        }

        public Class? ChooseClass()
        {
            if (AppDbContext<Class>.datas.Count == 0)
            {
                return null;
            }
            ShowClasses();
            Console.Write("Secmek istediyiniz classin id'ni girin: ");
            int chosenClassId = int.Parse(Console.ReadLine());

            return AppDbContext<Class>.datas.FirstOrDefault((classroom) => classroom.Id == chosenClassId);

        }

        public void ShowStudents()
        {
            Class? chosenClass = ChooseClass();
            if (chosenClass is null)
            {
                Console.WriteLine("Class Tapilmadi");
                return;
            }

            if(chosenClass.students.Count == 0)
            {
                Console.WriteLine("Classroomda telebe yoxdur");
                return;
            }

            Console.WriteLine("Classroomdaki userlar: ");

            foreach(Student student in chosenClass.students)
            {
                student.PrintInfo();
            }

        }
	}
}

