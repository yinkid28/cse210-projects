public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    // The MathAssignment constructor takes four parameters.  
    // It passes two parameters to the base Assignment constructor and initializes its own fields.  

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        // Here we set the MathAssignment specific variables
        _textbookSection = textbookSection;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}