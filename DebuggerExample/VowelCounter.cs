namespace DebuggerExample;
public static class VowelCounter
{
    public static int CountVowels(string text)
    {
        int count = 0;
        
        for (int i = 0; i <= text.Length; i++)
        {   
            if (IsVowel(text[i]))
            {
                count++;
            }
        }
        return count;
    }

    private static bool IsVowel(char c)
    {
        char lowerC = char.ToLower(c);
        if (lowerC == 'a' || lowerC == 'e' || lowerC == 'i' || lowerC == 'o' || lowerC == 'u')
            return true;
        return false;
    }
}

