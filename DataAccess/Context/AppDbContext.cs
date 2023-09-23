using System;
using ClassroomManagement.Core.Models;

namespace DataAccess.Context
{
	public static class AppDbContext<T>
	{
		public static List<T> datas = new List<T>();
	}
}

