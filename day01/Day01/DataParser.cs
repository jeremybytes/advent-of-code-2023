
namespace Day01;

public static class DataParser
{
    public static int CombineTupleToInt(this (int, int) input)
    {
        return (input.Item1 * 10) + input.Item2;
    }

    public static (int, int) FirstAndLastDigits(this List<int> input)
    {
        return (input.First(), input.Last());
    }

    public static List<int> FindNumbers(this string input)
    {
        List<int> result = new();
        for (int i = 0; i < input.Length; i++)
        {
            int? digit = FindDigit(input, i);
            if (digit is not null)
            {
                result.Add(digit.Value);
                continue;
            }
            digit = FindTextDigit(input, i);
            if (digit is not null)
            {
                result.Add(digit.Value);
                continue;
            }
        }
        return result;
    }

    public static int? FindDigit(string input, int index)
    {
        if (int.TryParse(input.Substring(index, 1), out int result))
            return result;
        return null;
    }

    public static int? FindTextDigit(string input, int startIndex)
    {
        return input.ToLower().Substring(startIndex) switch
        {
            var s when s.StartsWith("zero") => 0,
            var s when s.StartsWith("one") => 1,
            var s when s.StartsWith("two") => 2,
            var s when s.StartsWith("three") => 3,
            var s when s.StartsWith("four") => 4,
            var s when s.StartsWith("five") => 5,
            var s when s.StartsWith("six") => 6,
            var s when s.StartsWith("seven") => 7,
            var s when s.StartsWith("eight") => 8,
            var s when s.StartsWith("nine") => 9,
            _ => null,
        };
    }

}
