using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input;
        
        do
        {
            Console.Write("Please enter any number (Enter 0 to quit): ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            Console.WriteLine("Sum = " + sum);

            double average = numbers.Average();
            Console.WriteLine("Average = " + average);

            int max = numbers.Max();
            Console.WriteLine("Max = " + max);
        }
        else
        {
            Console.WriteLine("Error. No numbers were entered.");
        }
    }
}
