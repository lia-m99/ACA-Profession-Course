namespace EmployeeLibrary
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [SalaryValidation(1000, 100000)]
        public double Salary { get; set; }

        public Employee(int employeeId, string name, double salary)
        {
            Id = employeeId;
            Name = name;
            Salary = salary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Employee ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Salary: ${Salary}");
        }
    }
}