using DataLoader;

namespace Day02;

public static class MinimumGame
{
    public static ColorSet MinimumColors(this GameSets input)
    {
        int minRed = 0;
        int minGreen = 0;
        int minBlue = 0;
        foreach (var set in input.Sets)
        {
            if (set.Red > minRed)
                minRed = set.Red;
            if (set.Green > minGreen)
                minGreen = set.Green;
            if (set.Blue > minBlue)
                minBlue = set.Blue;
        }
        return new(minRed, minGreen, minBlue);
    }

    public static int GetColorSetPower(this ColorSet input)
    {
        return input.Red * input.Green * input.Blue;
    }
}
