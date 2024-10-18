using System;

public abstract class MindfulnessActivity
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public int Duration { get; private set; }

    
    public void Start()
    {
        Console.Clear();
        DisplayStartingMessage();
        RunActivity();
        DisplayFinishingMessage();
    }

    
    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {Name}");
        Console.WriteLine(Description);
        Console.Write("How many seconds would you like to do this activity? ");
        Duration = int.Parse(Console.ReadLine());  
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(3);  
    }

    
    protected void DisplayFinishingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} for {Duration} seconds.");
        ShowSpinner(3);  
    }

    
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000); 
        }
        Console.WriteLine();
    }

    
    protected abstract void RunActivity();
}
