using System;
using System.IO;
using System.Globalization;
using CyberStore.Entities;

namespace CyberStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            string sourcePath = @"c:\files\items.csv";
            
            try
            {
                using (StreamReader sr = File.OpenText(sourcePath))
                {           
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        double price = double.Parse(line[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(line[2]);
                        products.Add(new Product(name, price, quantity));
                    }
                }

                Directory.CreateDirectory(@"c:\files\out");

                string targetPath = @"c:\files\out\summary.csv";

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (Product product in products)
                    {
                        sw.WriteLine(product);
                    }
                }

                using (StreamReader sr = File.OpenText(targetPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
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