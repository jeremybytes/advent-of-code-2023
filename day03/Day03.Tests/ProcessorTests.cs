using static Day03.DataParser;

namespace Day03.Tests;

public class Tests
{
    // target sum = 4361 (not 114 or 58)
    string testdata =
       """
       467..114..
       ...*......
       ..35..633.
       ......#...
       617*......
       .....+.58.
       ..592.....
       ......755.
       ...$.*....
       .664.598..
       """;

    [Test]
    public void GetNumbersFromLine()
    {
        string input = "..35..633.";
        int row = 0;

        List<PartNumber> expected = new()
        {
            new(35, 2, 0, 2, false),
            new(633, 3, 0, 6, false),
        };

        List<PartNumber> actual = DataParser.GetNumbersFromLine(input, row);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetAllNumbers()
    {
        List<string> data = testdata.Split(Environment.NewLine).ToList();
        List<int> expected = new() { 467, 114, 35, 633, 617, 58, 592, 755, 664, 598 };
        
        var actual = data.GetAllNumbers();
        var actualNumber = actual.Select(a => a.Number).ToList();

        Assert.That(actualNumber, Is.EqualTo(expected));
    }

    [Test]
    public void IsPartNumber()
    {
        List<string> data = testdata.Split(Environment.NewLine).ToList();
        PartNumber testNumber = new(467, 3, 0, 0, false);
        bool expected = true;

        bool actual = DataParser.IsPartNumber(testNumber, data);
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetPartNumbers()
    {
        List<string> data = testdata.Split(Environment.NewLine).ToList();
        List<int> expected = new() { 467, 35, 633, 617, 592, 755, 664, 598 };

        List<int> actual = DataParser.GetAllNumbers(data).GetPartNumbers(data);

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetGearProducts()
    {
        // 16345, 451490
        List<string> data = testdata.Split(Environment.NewLine).ToList();
        List<int> expected = new() { 16345, 451490 };

        List<int> actual = data.GetAllNumbers().GetPotentialGears(data).GetActualGears().GetGearRatios().ToList();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetGearRatios()
    {
        // 467835
        List<string> data = testdata.Split(Environment.NewLine).ToList();
        int expected = 467835;

        int actual = data.GetAllNumbers().GetPotentialGears(data).GetActualGears().GetGearRatios().Sum();

        Assert.That(actual, Is.EqualTo(expected));
    }
}