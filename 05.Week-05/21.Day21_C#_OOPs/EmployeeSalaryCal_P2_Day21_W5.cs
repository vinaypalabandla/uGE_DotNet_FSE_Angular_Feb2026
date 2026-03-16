

class EmployeeSalCal
{
    public string Name { get; set; }
    public double BaseSalary { get; set; }

    public virtual double CalculateSalary()
    {
        return BaseSalary;
    }
}

    class Manager : EmployeeSalCal
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20);
        }
    }

    class Developer : EmployeeSalCal
    {
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeSalCal emp = new Manager();
            emp.Name = "Manager";
            emp.BaseSalary = 50000;

            EmployeeSalCal dev = new Developer();
            dev.Name = "Developer";
            dev.BaseSalary = 50000;

            Console.WriteLine("Manager Salary = " + emp.CalculateSalary());
            Console.WriteLine("Developer Salary = " + dev.CalculateSalary());
        }
    }


