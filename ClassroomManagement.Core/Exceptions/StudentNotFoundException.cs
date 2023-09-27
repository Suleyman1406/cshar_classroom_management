using System;
namespace ClassroomManagement.Core.Exceptions
{
	public class StudentNotFoundException:Exception
	{
		public StudentNotFoundException()
		{
		}
        public StudentNotFoundException(string message) : base(message)
        {
        }
    }
}

