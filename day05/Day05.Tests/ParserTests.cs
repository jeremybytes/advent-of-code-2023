using DataLoader;

namespace Day05.Tests;

public class Tests
{
    string testData =
        """
        seeds: 79 14 55 13

        seed-to-soil map:
        50 98 2
        52 50 48

        soil-to-fertilizer map:
        0 15 37
        37 52 2
        39 0 15

        fertilizer-to-water map:
        49 53 8
        0 11 42
        42 0 7
        57 7 4

        water-to-light map:
        88 18 7
        18 25 70

        light-to-temperature map:
        45 77 23
        81 45 19
        68 64 13

        temperature-to-humidity map:
        0 69 1
        1 0 69

        humidity-to-location map:
        60 56 37
        56 93 4
        """;

    [Test]
    public void ParsingTest()
    {
        var raw = testData.Split(Environment.NewLine).ToList();
        var seeds = raw.GetSeeds();
        var maps = raw.GetMaps();
        int expected = 82;

        long actual = seeds[0];
        foreach (var map in maps)
        {
            actual = actual.GetNextValue(map);
        }
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(14, 14, 53, 49, 42, 42, 43, 43)]
    public void MapValuesTest(long seed, long map1, long map2, long map3,
        long map4, long map5, long map6, long map7)
    {
        var raw = testData.Split(Environment.NewLine).ToList();
        var maps = raw.GetMaps();

        long actual = seed;
        actual = actual.GetNextValue(maps[0]);
        Assert.That(actual, Is.EqualTo(map1), "map1");
        actual = actual.GetNextValue(maps[1]);
        Assert.That(actual, Is.EqualTo(map2), "map2");
        actual = actual.GetNextValue(maps[2]);
        Assert.That(actual, Is.EqualTo(map3), "map3");
        actual = actual.GetNextValue(maps[3]);
        Assert.That(actual, Is.EqualTo(map4), "map4");
        actual = actual.GetNextValue(maps[4]);
        Assert.That(actual, Is.EqualTo(map5), "map5");
        actual = actual.GetNextValue(maps[5]);
        Assert.That(actual, Is.EqualTo(map6), "map6");
        actual = actual.GetNextValue(maps[6]);
        Assert.That(actual, Is.EqualTo(map7), "map7");
    }

    [TestCase(79, 82)]
    [TestCase(14, 43)]
    [TestCase(55, 86)]
    [TestCase(13, 35)]
    public void MappingTest(long seed, long expected)
    {
        var raw = testData.Split(Environment.NewLine).ToList();
        var maps = raw.GetMaps();

        long actual = seed;
        foreach (var map in maps)
        {
            actual = actual.GetNextValue(map);
        }
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void SeedRangeTest()
    {
        var raw = testData.Split(Environment.NewLine).ToList();
        List<long> expected = [79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89,
            90, 91, 92, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67];
        var seeds = raw.GetRangedSeeds();
        Assert.That(seeds, Is.EqualTo(expected));
    }

    [Test]
    public void RangeTest()
    {
        var raw = testData.Split(Environment.NewLine).ToList();
        var seeds = raw.GetSeeds();
        var maps = raw.GetMaps();
        long expected = 46;

        long currentMin = long.MaxValue;
        long curr = 0;
        var ranges = seeds;
        for (int i = 0; i < ranges.Count; i += 2)
        {
            for (int x = 0; x < ranges[i + 1]; x++)
            {
                curr = ranges[i] + x;
                foreach (var map in maps)
                {
                    curr = curr.GetNextValue(map);
                }
                if (curr < currentMin)
                {
                    currentMin = curr;
                }
            }
        }

        Assert.That(currentMin, Is.EqualTo(expected));
    }
}