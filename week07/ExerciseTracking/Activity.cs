public abstract class Activity
{
    // Private member variables
    private DateTime _date;
    private int _minutes;

    // Properties with getters and setters
    public DateTime Date
    {
        get { return _date; }
        set { _date = value; }
    }

    public int Minutes
    {
        get { return _minutes; }
        set { _minutes = value; }
    }

    // Constructor
    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Virtual method for summary, can be overridden if needed
    public virtual string GetSummary()
    {
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_minutes} min)- " +
               $"Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}