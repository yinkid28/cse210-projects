using System;

class Comment
{
    public string Commenter { get; set; }
    public string Text { get; set; }

    // Constructor
    public Comment(string commenter, string text)
    {
        Commenter = commenter;
        Text = text;
    }
}
