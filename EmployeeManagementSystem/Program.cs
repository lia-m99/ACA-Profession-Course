using EmployeeLibrary;

namespace EmployeeManagementSystem
{
    class Program
    {
        static void Main()
        {
            Validator.DisplayTypeInformation(typeof(Employee));

            Validator.ValidateSalaryAttributeUsage(typeof(Employee));
        }
    }
}