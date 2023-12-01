namespace DataLoader;

public static class Loader
{
    public static IEnumerable<string> Load(string fileName)
    {
        List<string> output = new();
        if (File.Exists(fileName))
        {
            using var reader = new StreamReader(fileName);
            while (!reader.EndOfStream)
                output.Add(reader.ReadLine()!);
        }
        return output;
    }
}
