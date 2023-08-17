using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Company.Entities;

namespace Company
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\files\employees.csv";

            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    employees.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter salary: ");
            double inputSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Email of people whose salary is more than 2000.00:");
            var emails = employees.Where(e => e.Salary > 2000.00).OrderBy(e => e.Email).Select(e => e.Email);
            foreach (string email in emails)
            {
                Console.WriteLine(email);
            }

            double sum = employees.Where(e => e.Name[0] == 'M').Select(e => e.Salary).DefaultIfEmpty(0.0).Sum();
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}