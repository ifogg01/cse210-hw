using System;

namespace GoalTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager goalManager = new GoalManager();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n1. Create Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Show Goals");
                Console.WriteLine("4. Show Score - Running total");
                Console.WriteLine("5. Save");
                Console.WriteLine("6. Load");
                Console.WriteLine("7. Exit");
                Console.Write("What would you like to do? \nSelect an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        CreateGoal(goalManager);
                        break;
                    case "2":
                        goalManager.DisplayGoals();
                        Console.Write("Select a goal to record event: ");
                        int goalIndex = int.Parse(Console.ReadLine()) - 1;
                        goalManager.RecordGoalEvent(goalIndex);
                        break;
                    case "3":
                        goalManager.DisplayGoals();
                        break;
                    case "4":
                        goalManager.DisplayScore();
                        break;
                    case "5":
                        Console.Write("Enter file name to save: ");
                        string saveFile = Console.ReadLine();
                        goalManager.Save(saveFile);
                        break;
                    case "6":
                        Console.Write("Enter file name to load: ");
                        string loadFile = Console.ReadLine();
                        goalManager.Load(loadFile);
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static void CreateGoal(GoalManager goalManager)
        {
            Console.WriteLine("");
            Console.WriteLine("What type of Goal are you working on?\n Please Select One: ");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.WriteLine("");
            string type = Console.ReadLine();

            Console.Write("What is your goal? ");
            string name = Console.ReadLine();

            Console.Write("Enter points will you receive for completing this? ");
            Console.WriteLine("");
            int points = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "1":
                    goalManager.AddGoal(new SimpleGoal(name, points));
                    break;
                case "2":
                    goalManager.AddGoal(new EternalGoal(name, points));
                    break;
                case "3":
                    Console.Write("How many times would you like to complete this goal? ");
                    Console.WriteLine("");

                    int targetCount = int.Parse(Console.ReadLine());
                    Console.Write("How many bonus points should you receive if you complete this goal entirely? ");
                    Console.WriteLine("");

                    int bonusPoints = int.Parse(Console.ReadLine());
                    goalManager.AddGoal(new ChecklistGoal(name, points, targetCount, bonusPoints));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }
    }
}
