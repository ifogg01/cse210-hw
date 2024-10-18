using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
    {
        Name = "Breathing Activity";
        Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void RunActivity()
    {
        int totalTime = Duration; 
        int interval = 5; 
        
        while (totalTime > 0)
        {
            if (totalTime < interval)
            {
                interval = totalTime; 
            }

            
            Console.WriteLine("Breathe in...");
            Countdown(interval);
            
            
            Console.WriteLine("Breathe out...");
            Countdown(interval);

            totalTime -= interval * 2; 
        }
    }

    
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            System.Threading.Thread.Sleep(1000); 
        }
        Console.WriteLine(); 
    }
}
