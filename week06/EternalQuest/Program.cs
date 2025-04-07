using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        
        Console.WriteLine("Welcome to Eternal Quest!");
        Console.WriteLine("Track your goals and level up on your spiritual journey.");
        
        manager.Start();
    }
    
    /*
    * EXCEEDING REQUIREMENTS:
    * 1. Added a leveling system where users gain levels based on their point totals
    * 2. Added ranks that change as users level up to provide a sense of progression
    * 3. Added achievement celebrations when users complete checklist goals
    * 4. Added detailed quest info display showing completion percentages and progress to next level
    * 5. Implemented proper encapsulation with protected fields in base class and proper inheritance
    * 6. Added validation for user inputs and better error handling
    */
}