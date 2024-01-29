using EmployeeLibrary;

namespace EmployeeManagementSystem
{
    public class Validator
    {
        public static void DisplayTypeInformation(Type type)
        {
            Console.WriteLine($"Type Information for {type.Name}:");

            Console.WriteLine("Properties:");
            foreach (var property in type.GetProperties())
            {
                Console.WriteLine($"- {property.PropertyType} {property.Name}");
            }

            Console.WriteLine("\nFields:");
            foreach (var field in type.GetFields())
            {
                Console.WriteLine($"- {field.FieldType} {field.Name}");
            }

            Console.WriteLine("\nMethods:");
            foreach (var method in type.GetMethods())
            {
                Console.WriteLine($"- {method.ReturnType} {method.Name}");
            }
        }

        public static void ValidateSalaryAttributeUsage(Type type)
        {
            Console.WriteLine("\nChecking for SalaryValidationAttribute:");

            var salaryProperty = type.GetProperty("Salary");

            if (salaryProperty != null)
            {
                var attributes = salaryProperty.GetCustomAttributes(typeof(SalaryValidationAttribute), true);

                if (attributes.Length > 0)
                {
                    var attribute = attributes[0] as SalaryValidationAttribute;
                    Console.WriteLine($"SalaryValidationAttribute found on {salaryProperty.Name} property.");

                    var constructor = type.GetConstructor(new[] { typeof(int), typeof(string), typeof(double) });

                    if (constructor != null)
                    {
                        object[] constructorArgs = { 1, "John Doe", 50000.0 };
                        var employeeInstance = constructor.Invoke(constructorArgs) as Employee;

                        ValidateSalary(salaryProperty.GetValue(employeeInstance)!, attribute!);
                    }
                    else
                    {
                        Console.WriteLine("Parameterized constructor not found.");
                    }
                }
                else
                {
                    Console.WriteLine($"SalaryValidationAttribute is missing on {salaryProperty.Name} property.");
                }
            }
            else
            {
                Console.WriteLine("Salary property not found.");
            }
        }

        public static void ValidateSalary(object value, SalaryValidationAttribute attribute)
        {
            if (value is double salary)
            {
                if (salary < attribute.MinSalary || salary > attribute.MaxSalary)
                {
                    Console.WriteLine($"Salary validation failed. Salary must be between {attribute.MinSalary} and {attribute.MaxSalary}.");
                }
                else
                {
                    Console.WriteLine("Salary is within the specified range.");
                }
            }
        }
    }
}
