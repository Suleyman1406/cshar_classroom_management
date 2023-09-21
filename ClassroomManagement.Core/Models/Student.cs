using System;
using ClassroomManagement.Core.Common;

namespace ClassroomManagement.Core.Models
{
	public class Student:BaseEntity
	{
		public static int count = 1;
		public string Name { get; set; }
		public int Age { get; set; }

        public Student(string name, int age)
        {
            Name = name;
            Age = age;
			Id = count++;
        }
	}
}

