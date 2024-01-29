using EmployeeLibrary;

namespace EmployeeManagementSystem
{
    class Program
    {
        // Assuming you first compiled the Employee project and got the dll into Employee\bin\Debug\net6.0\Employee.dll
        static void Main()
        {
            Validator.DisplayTypeInformation(typeof(Employee));

            Validator.ValidateSalaryAttributeUsage(typeof(Employee));
        }
    }
}