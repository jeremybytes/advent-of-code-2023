namespace DataLoader;

public static class Loader
{
    public static List<List<char>> LoadRaw(this string fileName)
    {
        List<List<char>> grid = [];
        if (!File.Exists(fileName)) return grid;

        using var reader = new StreamReader(fileName);
        while (!reader.EndOfStream)
        {
            grid.Add(reader.ReadLine().Select(c => c).ToList());
        }
        return grid;
    }
}
