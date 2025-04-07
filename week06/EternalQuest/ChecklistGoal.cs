using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    // Constructor for loading from file
    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted++;
        
        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Congratulations! You earned {_points} points plus a bonus of {_bonus} points!");
            Console.WriteLine($"You've completed this goal! Total points: {_points + _bonus}");
        }
        else
        {
            Console.WriteLine($"Congratulations! You earned {_points} points!");
            Console.WriteLine($"You've completed this goal {_amountCompleted}/{_target} times");
        }
    }

    public override bool IsCompleted()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        string completionMark = IsCompleted() ? "[X]" : "[ ]";
        return $"{completionMark} {_shortName}: {_description} (Completed {_amountCompleted}/{_target} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
    
    // Public getters needed by GoalManager
    public int GetPoints()
    {
        return _points;
    }
    
    public int GetBonus()
    {
        return _bonus;
    }
}