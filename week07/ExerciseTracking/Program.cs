using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all activities
        List<Activity> activities = new List<Activity>();

        // Create at least one activity of each type
        DateTime today = DateTime.Now;
        
        // Add a running activity
        Running running = new Running(today, 30, 3.0);
        activities.Add(running);
        
        // Add a cycling activity
        Cycling cycling = new Cycling(today, 45, 15.0);
        activities.Add(cycling);
        
        // Add a swimming activity
        Swimming swimming = new Swimming(today, 40, 20);
        activities.Add(swimming);

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("=========================");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}