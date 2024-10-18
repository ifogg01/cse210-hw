using System;
using System.Collections.Generic;

public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        Name = "Listing Activity";
        Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];
        
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(3); 

        Console.WriteLine("Start listing as many items as you can:");

        List<string> items = new List<string>();
        int totalTime = Duration;
        
        while (totalTime > 0)
        {
            
            if (totalTime < 5) break; 
            
            Console.Write($"{items.Count + 1}. ");
            string item = Console.ReadLine();
            items.Add(item);

            totalTime -= 5; 
        }

        
        Console.WriteLine($"\nYou listed {items.Count} items.");
    }
}
