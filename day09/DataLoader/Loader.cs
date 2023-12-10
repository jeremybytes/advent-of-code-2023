namespace DataLoader;

public static class Loader
{
    public static List<List<long>> GetSequences(this List<string> input)
    {
        return input.Select(GetSequence).ToList();
    }

    public static List<long> GetSequence(this string input)
    {
        var splits = input.Split(" ");
        return splits.Select(s => long.Parse(s)).ToList();
    }

    public static List<string> LoadRaw(this string fileName)
    {
        List<string> output = [];
        if (!File.Exists(fileName)) return output;

        using var reader = new StreamReader(fileName);
        while (!reader.EndOfStream)
        {
            output.Add(reader.ReadLine()!);
        }
        return output;
    }
}
