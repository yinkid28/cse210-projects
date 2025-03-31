public class WritingAssignment : Assignment
{
    private string _title;

    // The WritingAssignment constructor takes three parameters.  
    // It passes two to the base Assignment constructor and initializes its own field.
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        // Initialize variables specific to the WritingAssignment class.
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Using the getter since _studentName is private in the base class
        string studentName = GetStudentName();

        return $"{_title} by {studentName}";
    }
}