using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracker
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _totalScore;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _totalScore = 0;
        }

        public void AddGoal(Goal goal)
        {
            _goals.Add(goal);
        }

        public void DisplayGoals()
        {
            Console.WriteLine("Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()} {_goals[i].Name} - {_goals[i].GetProgress()}");
            }
        }

        public void RecordGoalEvent(int index)
        {
            if (index >= 0 && index < _goals.Count)
            {
                _totalScore += _goals[index].RecordEvent();
            }
            else
            {
                Console.WriteLine("Invalid goal index.");
            }
        }

        public void DisplayScore()
        {
            Console.WriteLine("");
            Console.WriteLine($"Your Total Score So Far: {_totalScore}\nGreat Job! Keep Up The Good Work!");
        }

        public void Save(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_totalScore);
                foreach (var goal in _goals)
                {
                    if (goal is ChecklistGoal checklistGoal)
                    {
                        writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{checklistGoal.GetCurrentCount()},{checklistGoal.GetTargetCount()},{checklistGoal.GetBonusPoints()}");
                    }
                    else
                    {
                        writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points}");
                    }
                }
            }
        }

        public void Load(string filename)
        {
            if (File.Exists(filename))
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    _totalScore = int.Parse(reader.ReadLine());
                    _goals.Clear();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');

                        string type = data[0];
                        string name = data[1];
                        int points = int.Parse(data[2]);

                        if (type == nameof(SimpleGoal))
                        {
                            var goal = new SimpleGoal(name, points);
                            _goals.Add(goal);
                        }
                        else if (type == nameof(EternalGoal))
                        {
                            var goal = new EternalGoal(name, points);
                            _goals.Add(goal);
                        }
                        else if (type == nameof(ChecklistGoal))
                        {
                            int currentCount = int.Parse(data[3]);
                            int targetCount = int.Parse(data[4]);
                            int bonusPoints = int.Parse(data[5]);

                            var goal = new ChecklistGoal(name, points, targetCount, currentCount, bonusPoints);
                            _goals.Add(goal);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}
