namespace DataLoader;

public static class Loader
{
    public static List<long> GetRangedSeeds(this List<string> input)
    {
        List<long> result = [];
        var ranges = input.GetSeeds();
        for (int i = 0; i < ranges.Count; i+=2)
        {
            for(int x = 0; x < ranges[i+1]; x++)
            {
                result.Add(ranges[i] + x);
            }
        }
        return result;
    }

    public static List<long> GetSeeds(this List<string> input)
    {
        var raw = input[0].Split(" ");
        List <long> seeds = raw.Skip(1).Select(s => long.Parse(s)).ToList();
        return seeds;
    }

    public static List<List<(long, long, long)>> GetMaps(this List<string> input)
    {
        List<List<(long, long, long)>> result = [];
        List<(long, long, long)> temp = [];
        foreach (var line in input.Skip(3))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line.Contains(":"))
            {
                result.Add(temp);
                temp = [];
                continue;
            }

            var split = line.Split(" ");
            (long, long, long) parsed = (long.Parse(split[0]), long.Parse(split[1]), long.Parse(split[2]));
            temp.Add(parsed);
        }
        if (temp.Count() > 0)
            result.Add(temp);
        return result;
    }

    public static List<string> LoadRaw(this string fileName)
    {
        List<string> output = [];
        if (!File.Exists(fileName)) return output;

        using var reader = new StreamReader(fileName);
        while (!reader.EndOfStream)
            output.Add(reader.ReadLine()!);
        return output;
    }
}
