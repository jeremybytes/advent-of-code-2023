namespace DataLoader;

public static class Loader
{
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
