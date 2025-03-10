// Entry.cs
// Added support for an optional "Mood" field and CSV format
using System;
using System.Linq;

public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }
    public string Mood { get; set; } // New field

    public Entry(string date, string prompt, string entryText, string mood = "Neutral")
    {
        Date = date;
        PromptText = prompt;
        EntryText = entryText;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine($"Mood: {Mood}");
        Console.WriteLine("-----------------------------------");
    }

    public string ToCSV()
    {
        return string.Join(",", new string[] { Date, EscapeCSV(PromptText), EscapeCSV(EntryText), Mood });
    }

    public static Entry FromCSV(string line)
    {
        string[] parts = line.Split(",").Select(UnescapeCSV).ToArray();
        if (parts.Length == 4)
        {
            return new Entry(parts[0], parts[1], parts[2], parts[3]);
        }
        return null;
    }

    private static string EscapeCSV(string field)
    {
        return field.Contains(",") ? $"\"{field}\"" : field;
    }

    private static string UnescapeCSV(string field)
    {
        return field.Trim('"');
    }
}