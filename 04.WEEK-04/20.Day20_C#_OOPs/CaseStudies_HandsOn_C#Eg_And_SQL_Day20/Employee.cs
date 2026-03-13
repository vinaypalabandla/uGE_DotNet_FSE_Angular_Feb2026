/*Problem Statement: Employee Profile in a Company HR System  
Context You are building part of a company’s Human Resources (HR) management application. The system needs to represent employees securely. Certain data (especially salary) is sensitive and should never be changed arbitrarily or set to invalid values. Direct access to core fields from outside the class must be prevented to maintain data integrity, enforce company policies, and reduce bugs.
Requirements
Create a C# class named Employee that satisfies the following rules:
1.	Data Hiding (Strong Encapsulation)
o	All important data fields (full name, salary, age, employee ID, etc.) must be private.
o	No external code is allowed to directly read or write these fields (e.g. employee.salary = 500; or employee.salary += 1000000; must be impossible).
2.	Controlled Access via Properties
o	FullName (string)
	Public get/set
	Cannot be set to null, empty, or whitespace → throw ArgumentException with clear message
	Automatically trim whitespace when setting
o	Age (int)
	Public get/set
	Must be between 18 and 80 (inclusive) → throw ArgumentException if invalid
o	Salary (decimal)
	Public get
	Private set (only the class itself can change salary)
	Minimum allowed salary is 1000 (company policy) → throw ArgumentException if trying to set below this
o	EmployeeId (string or int – your choice)
	Read-only property (no public setter)
	Assigned once at construction and never changes
3.	Safe Object Creation (Constructors)
o	Provide constructor(s) that force valid initial state.
o	At minimum, require: full name, starting salary, age
o	Optional: employee ID (auto-generate a simple one if not provided, e.g. "E" + random/guid-like number)
o	Validate all inputs inside the constructor:
	Name → not empty
	Age → 18–80
	Salary → ≥ 1000
o	Use property setters inside constructor (so validation logic is reused)
4.	Business Behavior (Public Methods – the only way to change salary) Implement controlled operations:
o	GiveRaise(decimal percentage)
	Percentage must be > 0 and ≤ 30 (company policy limit on single raise)
	Throw ArgumentException if invalid
	Increase salary by the given percentage (e.g. 10% → multiply by 1.10)
	(Optional) Print confirmation message to console
o	DeductPenalty(decimal amount) (example of controlled decrease)
	Amount > 0
	After deduction, salary must remain ≥ 1000
	Return bool (true = success, false = failed due to policy violation)
5.	Additional Integrity Rules
o	Salary must never drop below 1000 at any time (constructor + methods must enforce this).
o	Age cannot be decreased below 18 once set (optional strict rule – you can decide).
o	Use modern C# features: expression-bodied properties, readonly fields where appropriate, good naming.
Non-functional Expectations
•	Clearly demonstrate why direct manipulation is prevented (encapsulation benefit).
•	Show input validation preventing invalid employee objects from ever existing.
•	Code should be clean, readable, follow C# naming conventions, and use appropriate access modifiers.
Example of Expected (Forbidden) vs Allowed Usage
C#
// FORBIDDEN – should NOT be possible:
var emp = new Employee("Anna", 3200m, 28);
emp.Salary = 800;               // ← impossible (private set + validation)
emp.salary = -10000;            // ← impossible (private field)
emp.Age = 12;                   // ← should throw exception
emp.FullName = "";              // ← should throw exception

// ALLOWED & CONTROLLED:
var emp = new Employee("Marko Horvat", 4500m, 35);
Console.WriteLine(emp.Salary);        // 4500
emp.GiveRaise(15);                    // OK → 5175
emp.GiveRaise(40);                    // throws exception (too high)
emp.FullName = "Marko Horvat Jr.";    // OK
Console.WriteLine(emp.FullName);      // "Marko Horvat Jr."
Console.WriteLine(emp.Age);           // 35
Task Implement the Employee class following the rules above. Pay special attention to:
•	How private fields + public/private properties + methods achieve true encapsulation
•	Preventing invalid states (salary < 1000, unrealistic age, empty name)
•	Forcing valid initialization through constructors
•	Encapsulating business rules (raise limits, minimum salary)
This scenario mirrors real-world HR/payroll systems where protecting salary data and enforcing company policies is critical.

*/

using System;

namespace HRSystem
{
    internal class Employee  // create class
    {
        // 1st private variabls
        private string _fullName;
        private int _age;
        private decimal _salary;
        private string _employeeId;

        //2nd Properties declare
        public string FullName
        {
            get
            {
                return _fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Full name cannot be empty.");
                _fullName = value;
            }
        }

        public int Age
        {
            get { return _age; } // read and write
            set
            {
                if (value <=18 || value >= 80) //inclusive
                    throw new ArgumentException("Age must be between 18 and 80");

                _age = value;
            }
        }

        public decimal Salary
        {
            get { return _salary; } // read only 
            private set
            {
                if (value < 1000)
                    throw new ArgumentException("Salary must be at least 1000");

                _salary = value;
            }
        }

        public string EmployeeId  // read only
        {
            get
            {
                return _employeeId;
            }
        }


        //3 constructing 
        public Employee(string _fullName, decimal _salary, int _age)
        {
            // _employeeId = employeeId;

            FullName = _fullName;
            Age = _age;
            Salary = _salary;
        }
        //methods 4th
        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
                throw new ArgumentException("Raise percentage must be between 0 and 30");

            decimal newSalary = Salary + (Salary * percentage / 100);
            Salary = newSalary;

            Console.WriteLine("Salary increased successfully");
        }

        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
                return false;

            decimal newSalary = Salary - amount;

            if (newSalary < 1000)
                return false;

            Salary = newSalary;
            return true;
        }
    }
}