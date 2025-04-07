using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    // Constructor for loading from file
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override void RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            Console.WriteLine($"Congratulations! You earned {_points} points!");
        }
        else
        {
            Console.WriteLine("This goal has already been completed.");
        }
    }

    public override bool IsCompleted()
    {
        return _isComplete;
    }

    public override string GetDetailsString()
    {
        string completionMark = _isComplete ? "[X]" : "[ ]";
        return $"{completionMark} {_shortName}: {_description}";
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
    
    // Public getter for points needed by GoalManager
    public int GetPoints()
    {
        return _points;
    }
}