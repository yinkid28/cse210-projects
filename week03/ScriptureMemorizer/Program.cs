// Creativity: The program randomly selects a scripture from multiple options and displays an encouraging message when completed.


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // List of scriptures for random selection (Creativity: Multiple scriptures instead of one)
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want.")
        };

        // Pick a random scripture
        Random rand = new Random();
        Scripture selectedScripture = scriptures[rand.Next(scriptures.Count)];

        // Main loop
        while (!selectedScripture.IsFullyHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            selectedScripture.HideRandomWords(3); // Hide 3 words at a time
        }

        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());
        Console.WriteLine("\nGreat job! Keep memorizing and stay blessed!"); // (Creativity: Motivational message)
    }
}
