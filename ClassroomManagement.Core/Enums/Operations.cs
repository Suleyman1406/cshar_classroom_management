using System;
namespace ClassroomManagement.Core.Enums
{
	public enum ConsoleOperations
	{
		STUDENT = 1,
		CLASS = 2,
		EXIT = 3
	}
	public enum StudentOperations
	{
		ADD = 1,
		PRINT = 2,
		UPDATE = 3,
		SHOW_CLASSES = 4,
		SHOW_STUDENTS = 5,
		DELETE = 6,
		BACK = 7
    }

	public enum ClassOperations
	{
        ADD = 1,
        PRINT = 2,
        UPDATE = 3,
        ADD_STUDENT = 4,
        REMOVE_STUDENT = 5,
		SHOW_STUDENTS = 6,
		SHOW_CLASSES = 7,
        DELETE = 8,
		BACK = 9,
    }
}

