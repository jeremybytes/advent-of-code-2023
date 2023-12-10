using DataLoader;
using Day09;

namespace Day09.Tests;

public class Tests
{
    [TestCase("0 3 6 9 12 15", 18)]
    [TestCase("1 3 6 10 15 21", 28)]
    [TestCase("10 13 16 21 30 45", 68)]
    public void GetNextItem(string input, long expected)
    {
        var sequence = input.GetSequence();
        long actual = sequence.GetNextInSequence();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("10 13 16 21 30 45", 5)]
    public void GetPreviousItem(string input, long expected)
    {
        var sequence = input.GetSequence();
        long actual = sequence.GetPreviousInSequence();

        Assert.That(actual, Is.EqualTo(expected));
    }
}