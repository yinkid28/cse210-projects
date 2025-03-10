// PromptGenerator.cs
// Improved prompt selection to avoid repetition
using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private string _lastPrompt; // Track last prompt

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        string prompt;
        do
        {
            prompt = _prompts[random.Next(_prompts.Count)];
        } while (prompt == _lastPrompt); // Ensure it's not the same as last time

        _lastPrompt = prompt;
        return prompt;
    }
}
