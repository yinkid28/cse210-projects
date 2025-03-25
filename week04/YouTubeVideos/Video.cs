using System;
using System.Collections.Generic;

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    public int Likes { get; private set; }  // Tracks likes
    public List<Comment> Comments { get; set; } = new List<Comment>();

    // Constructor
    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
        Likes = 0;
    }

    // Returns the number of comments
    public int GetCommentCount()
    {
        return Comments.Count;
    }

    // Method to like a video
    public void LikeVideo()
    {
        Likes++;
    }

    // Formats duration as "minutes:seconds"
    public string GetFormattedDuration()
    {
        int minutes = LengthInSeconds / 60;
        int seconds = LengthInSeconds % 60;
        return $"{minutes}m {seconds}s";
    }

    // Displays video details
    public void DisplayInfo()
    {
        Console.WriteLine($"🎬 {Title} by {Author}");
        Console.WriteLine($"⏳ Duration: {GetFormattedDuration()} | 👍 Likes: {Likes}");
        Console.WriteLine($"💬 Comments: {GetCommentCount()}");

        foreach (var comment in Comments)
        {
            Console.WriteLine($"   - {comment.Commenter}: {comment.Text}");
        }
        Console.WriteLine();
    }
}
