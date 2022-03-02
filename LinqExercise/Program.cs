using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            Console.Write("Sum of numbers: ");
            Console.Write(numbers.Sum());
            Console.WriteLine();

            Console.Write("Average of numbers: ");
            Console.Write(numbers.Average());
            Console.WriteLine();

            //Order numbers in ascending order and descending order. Print each to console.
            Console.WriteLine("Numbers in ascending order: ");
            var ascendingNumbers = numbers.OrderBy(x => x);
            foreach (var i in ascendingNumbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Numbers in decending order: ");
            IEnumerable<int> descendingNumbers = numbers.OrderByDescending(x => x);
            foreach (var i in descendingNumbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //Print to the console only the numbers greater than 6
            var greaterThan6 = numbers.Where(x => x > 6);
            Console.WriteLine("Numbers greater than 6 are: ");
            foreach (var i in greaterThan6)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            var fourNumbers = ascendingNumbers.Take(4);
            Console.WriteLine("First 4 numbers in ascendingNumbers list: ");
            foreach (var i in fourNumbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 28;
            foreach (var item in descendingNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var firstnameCS = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).OrderBy(x => x.FirstName);
            Console.WriteLine("First name Ordered by C S and ascending: ");
            foreach (var person in firstnameCS)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine();

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.
            var ageThenFirstName = employees.Where(x => x.Age >= 26).OrderBy(x => x.FirstName);
            Console.WriteLine("employees ordered by age greater than or equal to 26 then by first name");
            foreach (var person in ageThenFirstName)
            {
                Console.WriteLine($"Age: {person.Age} name: {person.FullName}");
            }
            Console.WriteLine();
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var yoe = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            var sumYoe = yoe.Sum(x => x.YearsOfExperience);
            var averageYoe = yoe.Average(x => x.YearsOfExperience);
            Console.WriteLine($"Sum of years of experience: {sumYoe}");
            Console.WriteLine($"Average of years of experience: {averageYoe}");
            Console.WriteLine();
            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Tanner", "Syx", 28, 10)).ToList();

            foreach (var person in employees)
            {
                Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age} {person.YearsOfExperience}");
            }
            
            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
