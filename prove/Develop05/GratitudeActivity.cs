using System;
using System.Collections.Generic;

public class GratitudeActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>()
    {
        "Think of three people in your life who have made a positive impact.",
        "What is something in your life that you probably take for granted, but are actually thankful for?",
        "Reflect on a challenge you’ve overcome and the support you received during that time.",
        "What simple pleasures in life bring you joy? How do they make you feel?",
        "Who has shown you kindness recently? How did it make you feel?"
    };

    public GratitudeActivity()
    {
        Name = "Gratitude Activity";
        Description = "This activity will help you focus on the things and people in your life that you are grateful for. \n "
                    + "Taking time to acknowledge gratitude can increase your overall sense of happiness and well-being. ";
    }

    protected override void RunActivity()
    {
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine($"\n{prompt}");
        ShowSpinner(5); 

        int totalTime = Duration;
        while (totalTime > 0)
        {
            if (totalTime < 5)
            {
                break; 
            }

            Console.WriteLine("Take a moment to reflect on or write down what you are grateful for.");
            ShowSpinner(5);  

            totalTime -= 5;
        }
    }
}
