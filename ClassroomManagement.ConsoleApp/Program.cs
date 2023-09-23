using ClassroomManagement.Business.Helpers.Extensions;
using ClassroomManagement.Business.Services;
using ClassroomManagement.Core.Enums;
using ClassroomManagement.Core.Models;

bool isContinue = true;


StudentService studentService = new StudentService();
ClassService classService = new ClassService();

while (isContinue)
{
    ConsoleColor.DarkRed.WriteLine("Xos gelmisiniz. Secim edin.");
    ConsoleColor.Blue.WriteLine("1. Telebe Emeliyyatlari. ");
    ConsoleColor.Blue.WriteLine("2. Class Emeliyyatlari. ");
    ConsoleColor.Blue.WriteLine("3. Cixis. ");

    int choice;

    int.TryParse(Console.ReadLine(), out choice);

    switch (choice)
    {
        case (int)ConsoleOperations.STUDENT:
            StudentOperationsLabel:
            Console.WriteLine("Telebe emeliyyatlari: ");
            Console.WriteLine("1. Telebe elave et.");
            Console.WriteLine("2. Telebe bilgilerini goster.");
            Console.WriteLine("3. Telebe bilgilerini guncelle.");
            Console.WriteLine("4. Telebenin oldugu classlari goster.");
            Console.WriteLine("5. Telebeleri sirala");
            Console.WriteLine("6. Telebe sil.");
            Console.WriteLine("7. Ana menuya geri qayit.");
            int studentOperationChoice;

            int.TryParse(Console.ReadLine(), out studentOperationChoice);

            switch (studentOperationChoice)
            {
                case (int)StudentOperations.ADD:
                    studentService.Add();
                    goto StudentOperationsLabel;
                case (int)StudentOperations.PRINT:
                    goto StudentOperationsLabel;
                case (int)StudentOperations.UPDATE:
                    studentService.EditStudent();
                    goto StudentOperationsLabel;
                case (int)StudentOperations.SHOW_CLASSES:
                    studentService.ShowStudentClasses();
                    goto StudentOperationsLabel;
                case (int)StudentOperations.SHOW_STUDENTS:
                    studentService.ShowStudents();
                    goto StudentOperationsLabel;
                case (int)StudentOperations.DELETE:
                    studentService.Delete();
                    goto StudentOperationsLabel;
                case (int) StudentOperations.BACK:
                    break;
                default:
                    Console.WriteLine("Dogru girin");
                    goto StudentOperationsLabel;
            }

            break;
        case (int)ConsoleOperations.CLASS:

        ClassOperationsLabel:
            Console.WriteLine("Class emeliyyatlari: ");
            Console.WriteLine("1. Class elave et.");
            Console.WriteLine("2. Class bilgilerini goster.");
            Console.WriteLine("3. Class bilgilerini guncelle.");
            Console.WriteLine("4. CLassa telebe elave et");
            Console.WriteLine("5. Classdan telebe cixar.");
            Console.WriteLine("6. Tebeleri goster");
            Console.WriteLine("7. Classlari goster");
            Console.WriteLine("8. Classdan sil");
            Console.WriteLine("9. Ana menuya geri qayit.");
            int classOperationChoice;

            int.TryParse(Console.ReadLine(), out classOperationChoice);

            switch (classOperationChoice)
            {
                case (int)ClassOperations.ADD:
                    classService.Add();
                    goto ClassOperationsLabel;
                case (int)ClassOperations.PRINT:
                    goto ClassOperationsLabel;
                case (int)ClassOperations.UPDATE:
                    goto ClassOperationsLabel;
                case (int)ClassOperations.ADD_STUDENT:
                    Student? student= studentService.ChooseStudent();
                    if(student is null)
                    {
                        Console.WriteLine("Telebe tapilmadi!");
                        goto ClassOperationsLabel;
                    }
                    classService.AddStudentToClass(student);
                    goto ClassOperationsLabel;
                case (int)ClassOperations.SHOW_STUDENTS:
                    classService.ShowStudents();
                    goto ClassOperationsLabel;
                case (int)ClassOperations.SHOW_CLASSES:
                    classService.ShowClasses();
                    goto ClassOperationsLabel;
                case (int)ClassOperations.BACK:
                    break;
                case (int)ClassOperations.DELETE:
                    goto ClassOperationsLabel;
                default:
                    Console.WriteLine("Dogru girin");
                    goto ClassOperationsLabel;
            }
            break;
        case (int)ConsoleOperations.EXIT:
            ConsoleColor.DarkRed.WriteLine("Xos getdiniz");
            isContinue = false;
            break;
        default:
            ConsoleColor.Red.WriteLine("XETA! Dogru secim edin");
            break;
    }
}





