using System;
using System.Collections.Generic;
using System.Linq;  // For sorting videos by comments

class Program
{
    static void Main()
    {
        // Creating sample videos
        List<Video> videos = new List<Video>
        {
            new Video("C# Basics", "Tech Guru", 300),
            new Video("OOP in C#", "Code Academy", 450),
            new Video("Advanced C# Tips", "Dev Expert", 600)
        };

        // Adding comments
        videos[0].Comments.Add(new Comment("Alice", "Great explanation!"));
        videos[0].Comments.Add(new Comment("Bob", "Thanks for this."));
        videos[0].Comments.Add(new Comment("Charlie", "Helpful video!"));

        videos[1].Comments.Add(new Comment("Dave", "I love OOP!"));
        videos[1].Comments.Add(new Comment("Eve", "Very clear, thanks!"));
        videos[1].Comments.Add(new Comment("Frank", "Awesome!"));

        videos[2].Comments.Add(new Comment("Grace", "This was exactly what I needed."));
        videos[2].Comments.Add(new Comment("Hank", "Thanks a lot!"));

        // Like videos
        videos[0].LikeVideo();
        videos[0].LikeVideo();
        videos[1].LikeVideo();
        videos[1].LikeVideo();
        videos[1].LikeVideo();

        // Sorting videos by most comments (Creative addition)
        videos = videos.OrderByDescending(v => v.GetCommentCount()).ToList();

        // Display video information
        foreach (var video in videos)
        {
            video.DisplayInfo();
        }
    }
}
