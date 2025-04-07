using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You earned {_points} points!");
    }

    public override bool IsCompleted()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"[ ] {_shortName}: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
    
    // Public getter for points needed by GoalManager
    public int GetPoints()
    {
        return _points;
    }
}