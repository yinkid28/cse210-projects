using System;
using System.Threading;

class BreathingActivity : MindfulnessActivity
{
    protected override string GetDescription()
    {
        return "This activity will help you relax by guiding your breathing. Clear your mind and focus on your breath.";
    }

    public override void Run()
    {
        StartActivity();
        for (int i = 0; i < duration; i += 4)
        {
            Console.WriteLine("Breathe in...");
            ShowCountdown(2);
            Console.WriteLine("Breathe out...");
            ShowCountdown(2);
        }
        EndActivity();
    }

    private void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
