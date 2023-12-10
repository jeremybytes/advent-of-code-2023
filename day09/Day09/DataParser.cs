namespace Day09;

public static class DataParser
{
    public static long GetPreviousInSequence(this List<long> input)
    {
        List<long> nextSequence = input;
        List<long> firstItems = [input.First()];

        while (!nextSequence.All(n => n == 0))
        {
            nextSequence = nextSequence.GetNextSequence();
            firstItems.Add(nextSequence.First());
        }

        long firstInSequence = 0;
        for (int i = firstItems.Count - 1; i > 0; i--)
        {
            firstInSequence = firstItems[i -1] - firstItems[i];
            firstItems[i - 1] = firstInSequence;
        }
        return firstInSequence;
    }

    public static long GetNextInSequence(this List<long> input)
    {
        List<long> nextSequence = input;
        List<long> lastItems = [input.Last()];

        while (!nextSequence.All(n => n == 0))
        {
            nextSequence = nextSequence.GetNextSequence();
            lastItems.Add(nextSequence.Last());
        }

        long nextInSequence = 0;
        for (int i = lastItems.Count - 1; i > 0; i--)
        {
            nextInSequence = lastItems[i] + lastItems[i - 1];
            lastItems[i - 1] = nextInSequence;
        }
        return nextInSequence;
    }

    public static List<long> GetNextSequence(this List<long> input)
    {
        List<long> result = [];
        for (int i = 1; i < input.Count; i++)
        {
            result.Add(input[i] - input[i - 1]);
        }
        return result;
    }
}
