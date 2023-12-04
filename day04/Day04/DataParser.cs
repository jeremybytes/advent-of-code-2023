using static DataLoader.Loader;

namespace Day04;

public static class DataParser
{
    public static List<int> GetCardCopies(this List<Card> input)
    {
        List<int> output = Enumerable.Repeat(1, input.Count).ToList();
        for (int i = 0; i < input.Count; i++)
        {
            int winners = input[i].GetCardWinnerCount();
            for (int w = 1; w <= winners; w++)
            {
                output[i + w] += output[i];
            }
        }
        return output;
    }

    public static int GetCardWinnerCount(this Card input)
    {
        return input.Winners.Intersect(input.MyNumbers).Count();
    }

    public static List<int> GetCardValues(this List<Card> input)
    {
        return input.Select(s => s.GetCardValue()).ToList();
    }

    public static int GetCardValue(this Card input)
    {
        int winningCount = input.Winners.Intersect(input.MyNumbers).Count();
        int value = 0;
        for (int i = 1; i <= winningCount; i++)
        {
            if (value == 0) value++;
            else value *= 2;
        }
        return value;
    }
}
