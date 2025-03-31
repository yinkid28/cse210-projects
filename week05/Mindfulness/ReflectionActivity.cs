using System;
using System.Threading;

class ReflectionActivity : MindfulnessActivity
{
    private static string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };

    private static string[] questions = {
        "Why was this experience meaningful to you?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?"
    };

    protected override string GetDescription()
    {
        return "This activity will help you reflect on times when you showed strength and resilience.";
    }

    public override void Run()
    {
        StartActivity();
        Random rnd = new Random();
        Console.WriteLine(prompts[rnd.Next(prompts.Length)]);

        for (int i = 0; i < duration; i += 5)
        {
            Console.WriteLine(questions[rnd.Next(questions.Length)]);
            ShowSpinner(5);
        }
        EndActivity();
    }
}
