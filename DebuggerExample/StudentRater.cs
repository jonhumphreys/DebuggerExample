namespace DebuggerExample;

using System;
using System.Collections.Generic;
using System.IO;

public static class StudentRater
{
    private static Dictionary<string, List<int>> studentToRatings = new Dictionary<string, List<int>>();
    private static string dataFileName = "names.txt";
    
    public static string GetBestStudent()
    {
        if (studentToRatings.Count == 0)
            LoadData();

        string topStudent = "Unknown";
        int highestSum = int.MinValue;

        foreach (KeyValuePair<string, List<int>> studentEntry in studentToRatings)
        {
            int sum = 0;
            foreach (int rating in studentEntry.Value)
                sum += rating;

            if (sum > highestSum)
            {
                highestSum = sum;
                topStudent = studentEntry.Key;
            }
        }

        return topStudent;
    }

    #region DataLoading

    private static void LoadData()
    {
        try
        {
            foreach (string line in File.ReadLines(dataFileName))
            {
                ProcessOneStudentLine(line);
            }
            Console.WriteLine($"Loaded all students...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }
    }

    private static void ProcessOneStudentLine(string line)
    {
        string[] parts = line.Split(';');
        if (parts.Length == 2)
        {
            string name = parts[0].Trim();
            ProcessOneStudentRatings(parts, name);
        }
    }

    private static void ProcessOneStudentRatings(string[] parts, string name)
    {
        string[] numberStrings = parts[1].Split(',');
        List<int> numbers = null;

        if (AreNumbersValid(numberStrings))
            numbers = StoreStudentRatings(numberStrings);

        studentToRatings[name] = numbers;
    }

    private static List<int> StoreStudentRatings(string[] numberStrings)
    {
        List<int> numbers;
        numbers = new List<int>();
        foreach (string numberString in numberStrings)
        {
            numbers.Add(int.Parse(numberString.Trim()));
        }

        return numbers;
    }

    private static bool AreNumbersValid(string[] numberStrings)
    {
        bool areNumbersValid = true;
        foreach (string numberString in numberStrings)
        {
            if (!int.TryParse(numberString.Trim(), out int number))
            {
                areNumbersValid = false;
                break;
            }
        }

        return areNumbersValid;
    }

    #endregion
    
}
