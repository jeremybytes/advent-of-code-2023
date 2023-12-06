namespace Day05;

public static class DataParser
{
    public static long GetNextValue(this long input, List<(long, long, long)> map)
    {
        long result = input;

        foreach(var (dest, source, count) in map)
        {
            if (input >= source && input < source + count)
            {
                result = dest + (input - source);
                break;
            }
        }

        return result;
    }
}
