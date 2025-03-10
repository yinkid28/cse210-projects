using System;
using System.Collections.Generic;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>(); // Initialize an empty list of jobs

    // Method to display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display(); // Call the Display method from the Job class
        }
    }
}
