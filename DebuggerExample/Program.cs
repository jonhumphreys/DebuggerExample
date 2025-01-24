namespace DebuggerExample;

class Program
{
    public static void Main(string[] args)
    {
        RunVowelCounter();
        //RunStudentRater();
    }
    
    private static void RunVowelCounter()
    {
        int vowelCount = VowelCounter.CountVowels("Sandie");
        Console.WriteLine($"Vowel count: {vowelCount}");
    }

    private static void RunStudentRater()
    {
        string bestStudent = StudentRater.GetBestStudent();
        Console.WriteLine($"The best student is {bestStudent}");
    }
    
}