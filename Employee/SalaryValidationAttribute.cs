namespace EmployeeLibrary
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SalaryValidationAttribute : Attribute
    {
        public double MinSalary { get; }
        public double MaxSalary { get; }

        public SalaryValidationAttribute(double minSalary, double maxSalary)
        {
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }
    }
}
