using System;
using System.Collections.Generic;
using System.Threading;

class ListingActivity : MindfulnessActivity
{
    private static string[] prompts = {
        "List people you appreciate.",
        "List your personal strengths.",
        "List moments that made you happy today."
    };

    protected override string GetDescription()
    {
        return "This activity helps you reflect on the good things in your life.";
    }

    public override void Run()
    {
        StartActivity();
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Length)]);
        Console.WriteLine("Start listing...");

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        EndActivity();
    }
}
