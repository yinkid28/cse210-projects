using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Add a public getter for the name since it's needed by GoalManager
    public string GetName()
    {
        return _shortName;
    }

    // Abstract methods to be implemented by derived classes
    public abstract void RecordEvent();
    public abstract bool IsCompleted();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}