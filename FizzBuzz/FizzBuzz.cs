using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            //      3-Fizz
            //      5-Buzz
            //      15-FizzBuzz

            for (int i = 0; i < 300; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
