using ClassroomManagement.Core.Common;

namespace ClassroomManagement.Core.Models
{
	public class Class:BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public List<Student> students;

        public Class(string title, string description)
        {
            Title = title;
            Description = description;
            students = new();
        }
    }
}

