using System;
using System.IO;
using System.Collections.Generic;
using Employees.Entities;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\files\items.csv";

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    List<Employee> employees = new List<Employee>();
                    while (!sr.EndOfStream)
                    {
                        employees.Add(new Employee(sr.ReadLine()));
                    }
                    employees.Sort();
                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine(employee);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}