// Journal.cs
// Added CSV saving and loading functionality
using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;

    public Journal()
    {
        _entries = new List<Entry>();
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToCSV(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine("Date,Prompt,Entry,Mood");
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToCSV());
            }
        }
        Console.WriteLine("Journal saved as CSV successfully!");
    }

    public void LoadFromCSV(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);
        for (int i = 1; i < lines.Length; i++) // Skip header row
        {
            Entry entry = Entry.FromCSV(lines[i]);
            if (entry != null)
            {
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Journal loaded from CSV successfully!");
    }
}
