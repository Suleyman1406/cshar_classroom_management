using System;
namespace ClassroomManagement.Core.Exceptions
{
	public class ClassNotFoundException:Exception
	{
		public ClassNotFoundException()
		{
		}
		public ClassNotFoundException(string message) : base(message)
        {
        }
    }
}

