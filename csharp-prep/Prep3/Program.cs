using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int magicNumber = random.Next(1, 101); 
        int guess = -1;  
        while (guess != magicNumber)
        {
            Console.Write("Can yo guess the magic number (between 1 and 100): ");
            string guessInput = Console.ReadLine();

            if (int.TryParse(guessInput, out guess))
            {
                if (guess < magicNumber)
                {
                    Console.WriteLine("Sorry too low! Try guessing higher.");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Sorry too high! Try guessing lower.");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }
            else
            {
                Console.WriteLine("Error. Please enter a valid number.");
            }
        }
    }
}
