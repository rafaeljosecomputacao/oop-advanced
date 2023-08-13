using System;
using System.Globalization;
using System.Collections.Generic;
using ConsultingCompany.Entities;
using ConsultingCompany.Services;

namespace ConsultingCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] vect = Console.ReadLine().Split(',');
                string name = vect[0];
                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);
                products.Add(new Product(name, price));
            }

            CalculationService calculationService = new CalculationService();

            Console.WriteLine("Most expensive:");
            Console.WriteLine(calculationService.Max(products));
        }
    }
}