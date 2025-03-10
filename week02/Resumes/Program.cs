using System;

class Program
{
    static void Main(string[] args)
    {
        // Create first job instance
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2022;
        job1._endYear = 2024;

        // Create second job instance
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Create a resume instance
        Resume myResume = new Resume();
        myResume._name = "Adeyinka Adedayo";

        // Add jobs to resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the resume
        myResume.Display();
    }
}
