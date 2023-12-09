namespace DataLoader;

public static class Loader
{
    public static string? LoadDirections(this string fileName)
    {
        string output = "";
        if (!File.Exists(fileName)) return output;

        using var reader = new StreamReader(fileName);
        return reader.ReadLine();
    }

    public static List<string> LoadRawMap(this string fileName)
    {
        List<string> output = [];
        if (!File.Exists(fileName)) return output;

        using var reader = new StreamReader(fileName);
        reader.ReadLine();
        reader.ReadLine();
        while (!reader.EndOfStream)
        {
            output.Add(reader.ReadLine()!);
        }
        return output;
    }

    public static Dictionary<string, (string, string)> ParseMap(this List<string> maps)
    {
        Dictionary<string, (string, string)> result = new();
        //VTM = (VPB, NKT)
        foreach (var item in maps)
        {
            string key = item.Substring(0, 3);
            string left = item.Substring(7, 3);
            string right = item.Substring(12, 3);
            result.Add(key, (left, right));
        }
        return result;
    }
}
