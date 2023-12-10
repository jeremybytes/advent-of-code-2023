using Day10;

namespace Day10.Tests;

public class Tests
{
    string testData =
        """
        ..F7.
        .FJ|.
        SJ.L7
        |F--J
        LJ...
        """;

    [Test]
    public void PathLength()
    {
        List<List<char>> grid = [];
        foreach (var line in testData.Split(Environment.NewLine))
        {
            grid.Add(line.Select(c => c).ToList());
        }
        long expected = 16;
        long actual = grid.GetPathLength();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void FirstCell()
    {
        List<List<char>> grid = [];
        foreach (var line in testData.Split(Environment.NewLine))
        {
            grid.Add(line.Select(c => c).ToList());
        }
        var first = (2, 0).GetFirstCell(grid);

        Assert.That(first, Is.AnyOf((2, 1), (3, 0)));
    }

    [Test]
    public void StartingPoint()
    {
        List<List<char>> grid = [];
        foreach(var line in testData.Split(Environment.NewLine))
        {
            grid.Add(line.Select(c => c).ToList());
        }
        (int, int) expected = (2, 0);

        var actual = grid.GetStartingPoint();

        Assert.That(actual, Is.EqualTo(expected));
    }
}