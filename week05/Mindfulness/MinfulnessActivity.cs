using System;
using System.Threading;

abstract class MindfulnessActivity
{
    protected int duration;

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {GetType().Name}...");
        Console.WriteLine(GetDescription());
        Console.Write("Enter duration (in seconds): ");
        duration = int.Parse(Console.ReadLine());

        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void EndActivity()
    {
        Console.WriteLine("Good job! Activity completed.");
        Console.WriteLine($"You completed {GetType().Name} for {duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] spinnerChars = { "|", "/", "-", "\\" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinnerChars[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Backspace to remove previous character
        }
        Console.WriteLine();
    }
 
    // This method displays inspirational mindfulness quotes to motivate the user
    // and enhance their experience after completing an activity
    protected void DisplayQuote()
    {
        string[] quotes = {
            "The present moment is the only moment where life exists.",
            "Mindfulness isn't difficult, we just need to remember to do it.",
            "Peace comes from within. Do not seek it without."
        };
        
        Random rnd = new Random();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n" + quotes[rnd.Next(quotes.Length)]);
        Console.ResetColor();
    }

    protected abstract string GetDescription();
    public abstract void Run();
}
