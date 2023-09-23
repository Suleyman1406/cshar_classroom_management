using System.Xml.Linq;
using ClassroomManagement.Core.Common;

namespace ClassroomManagement.Core.Models
{
	public class Class:BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public List<Student> students;
        private static int count = 1;

        public Class(string title, string description)
        {
            Title = title;
            Description = description;
            students = new();
            Id = count++;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ID: {Id}, Title: {Title}, Desc: {Description}");
        }
    }
}

