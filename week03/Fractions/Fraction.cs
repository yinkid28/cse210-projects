using System;

public class Fraction
{
    // Private attributes
    private int numerator;
    private int denominator;

    // Constructor: Initializes to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor: Initializes to x/1
    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    // Constructor: Initializes to x/y
    public Fraction(int top, int bottom)
    {
        if (bottom == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        numerator = top;
        denominator = bottom;
    }

    // Getters and Setters
    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int value)
    {
        numerator = value;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int value)
    {
        if (value == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        denominator = value;
    }

    // Method to return fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return decimal representation (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}
