using System;

class Program
{
static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string input = Console.ReadLine();
        
        double gradePercentage;
        string letter = ""; 

        if (double.TryParse(input, out gradePercentage))
        {
            if (gradePercentage >= 90)
            {
                letter = "A";
            }
            else if (gradePercentage >= 80)
            {
                letter = "B";
            }
            else if (gradePercentage >= 70)
            {
                letter = "C";
            }
            else if (gradePercentage >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            Console.WriteLine($"Your letter grade is: {letter}");

            if (gradePercentage >= 70)
            {
                Console.WriteLine("Good Job! You passed.");
            }
            else
            {
                Console.WriteLine("Sorry, but you did not pass. Don't give up, try again.");
            }
        }
        else
        {
            Console.WriteLine("Error. Please enter a valid numeric grade percentage from 0-100.");
        }
    }
}

