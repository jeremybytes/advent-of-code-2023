namespace Day08;

public static class DataParser
{
    public static string GetNextStep(this string key, char direction, Dictionary<string, (string, string)> map)
    {
        var item = map[key];
        return direction switch
        {
            'L' => item.Item1,
            'R' => item.Item2,
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}
