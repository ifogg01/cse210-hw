using System;

public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;
        
        while (running)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("MINDFULNESS ACTIVITY");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.WriteLine("");

            Console.Write("Which one would you like to choose: ");
            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }

            if (activity != null)
            {
                activity.Start();
            }
        }
    }
}
