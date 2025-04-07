using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exit = false;
        while (!exit)
        {
            DisplayMenu();
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    DisplayInfo();
                    break;
                case "8":
                    exit = true;
                    Console.WriteLine("Thank you for using Eternal Quest. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayMenu()
    {
        Console.WriteLine("\n===== ETERNAL QUEST =====");
        Console.WriteLine($"Current Score: {_score} points");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goal Names");
        Console.WriteLine("3. List Goal Details");
        Console.WriteLine("4. Record Event");
        Console.WriteLine("5. Save Goals");
        Console.WriteLine("6. Load Goals");
        Console.WriteLine("7. Display Quest Info");
        Console.WriteLine("8. Exit");
        Console.Write("Select an option: ");
    }

    public void DisplayInfo()
    {
        Console.WriteLine("\n===== YOUR QUEST INFO =====");
        Console.WriteLine($"Current Score: {_score} points");
        
        // Added gamification element: levels
        int level = (_score / 1000) + 1;
        string rank = GetRank(level);
        
        Console.WriteLine($"Current Level: {level}");
        Console.WriteLine($"Rank: {rank}");
        
        int nextLevelPoints = level * 1000;
        int pointsToNextLevel = nextLevelPoints - _score;
        
        Console.WriteLine($"Points needed for next level: {pointsToNextLevel}");
        
        if (_goals.Count > 0)
        {
            int completedGoals = _goals.Count(g => g.IsCompleted());
            double completionPercentage = (double)completedGoals / _goals.Count * 100;
            
            Console.WriteLine($"Goals Completed: {completedGoals}/{_goals.Count} ({completionPercentage:F1}%)");
        }
        else
        {
            Console.WriteLine("No goals created yet.");
        }
    }

    private string GetRank(int level)
    {
        switch (level)
        {
            case 1: return "Novice Quester";
            case 2: return "Apprentice Journeyer";
            case 3: return "Seasoned Adventurer";
            case 4: return "Expert Explorer";
            case 5: return "Master Achiever";
            case 6: return "Legendary Champion";
            case 7: return "Divine Seeker";
            case 8: return "Celestial Voyager";
            case 9: return "Eternal Guardian";
            case 10: return "Transcendent Being";
            default: return level > 10 ? "Ascended One" : "Beginner";
        }
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\n===== YOUR GOALS =====");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Use the public getter instead of accessing the protected field directly
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("\n===== YOUR GOALS (DETAILED) =====");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n===== CREATE A NEW GOAL =====");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Back to Main Menu");
        Console.Write("Select a goal type: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "4")
            return;
            
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();
        
        Console.Write("Enter points for each completion: ");
        int points = int.Parse(Console.ReadLine());
        
        Goal newGoal;
        
        switch (choice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                
                Console.Write("Enter bonus points upon completion: ");
                int bonus = int.Parse(Console.ReadLine());
                
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice. Goal creation canceled.");
                return;
        }
        
        _goals.Add(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        ListGoalNames();
        Console.Write("Enter the number of the goal you accomplished: ");
        
        if (int.TryParse(Console.ReadLine(), out int goalIndex) && goalIndex >= 1 && goalIndex <= _goals.Count)
        {
            Goal goal = _goals[goalIndex - 1];
            
            // Store the previous completion state
            bool wasCompletedBefore = goal.IsCompleted();
            
            // Record the event
            goal.RecordEvent();
            
            // For SimpleGoal, only add points if it wasn't completed before
            if (goal is SimpleGoal && !wasCompletedBefore && goal.IsCompleted())
            {
                _score += ((SimpleGoal)goal).GetPoints();
            }
            // For EternalGoal, always add points
            else if (goal is EternalGoal)
            {
                _score += ((EternalGoal)goal).GetPoints();
            }
            // For ChecklistGoal, add points and possibly bonus
            else if (goal is ChecklistGoal)
            {
                ChecklistGoal checklistGoal = (ChecklistGoal)goal;
                _score += checklistGoal.GetPoints();
                
                // Add bonus if it just got completed
                if (!wasCompletedBefore && goal.IsCompleted())
                {
                    _score += checklistGoal.GetBonus();
                    ShowAchievementMessage(checklistGoal.GetName());
                }
            }
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    // Added gamification element: achievement celebration
    private void ShowAchievementMessage(string goalName)
    {
        Console.WriteLine("\n*********************************");
        Console.WriteLine("*       ACHIEVEMENT UNLOCKED    *");
        Console.WriteLine("*********************************");
        Console.WriteLine($"You've mastered: {goalName}!");
        Console.WriteLine("Keep up the amazing work on your Eternal Quest!");
        Console.WriteLine("*********************************\n");
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        using (StreamWriter writer = new StreamWriter(filename))
        {
            // First line: score
            writer.WriteLine(_score);
            
            // Remaining lines: goals
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found!");
            return;
        }
        
        _goals.Clear();
        
        string[] lines = File.ReadAllLines(filename);
        
        // First line: score
        _score = int.Parse(lines[0]);
        
        // Remaining lines: goals
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] parts = line.Split(':');
            
            string goalType = parts[0];
            string[] goalData = parts[1].Split(',');
            
            Goal goal;
            
            switch (goalType)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(
                        goalData[0],                   // name
                        goalData[1],                   // description
                        int.Parse(goalData[2]),        // points
                        bool.Parse(goalData[3])        // isComplete
                    );
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(
                        goalData[0],                   // name
                        goalData[1],                   // description
                        int.Parse(goalData[2])         // points
                    );
                    break;
                case "ChecklistGoal":
                    goal = new ChecklistGoal(
                        goalData[0],                   // name
                        goalData[1],                   // description
                        int.Parse(goalData[2]),        // points
                        int.Parse(goalData[3]),        // target
                        int.Parse(goalData[4]),        // bonus
                        int.Parse(goalData[5])         // amountCompleted
                    );
                    break;
                default:
                    continue;
            }
            
            _goals.Add(goal);
        }
        
        Console.WriteLine("Goals loaded successfully!");
    }
}