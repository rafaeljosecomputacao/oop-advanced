using System;

namespace PostTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2023, 08, 16, 8, 10, 45);
            Console.WriteLine(dt.ElapsedTime());
        }
    }
}