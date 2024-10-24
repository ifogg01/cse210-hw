using System;

namespace GoalTracker
{
    public abstract class Goal
    {
        public string Name { get; private set; }
        public bool IsComplete { get; protected set; }
        public int Points { get; private set; }

        protected Goal(string name, int points)
        {
            Name = name;
            Points = points;
            IsComplete = false;
        }

        public abstract int RecordEvent(); 
        public abstract string GetProgress(); 
        public abstract void Reset(); 

        public virtual string GetStatus() => IsComplete ? "[X]" : "[ ]";
    }
}
