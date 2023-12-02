using DataLoader;

namespace Day02;

public static class MinimumGame
{
    public static ColorSet MinimumColors(this GameSets input)
    {
        int minRed = input.Sets.Max(s => s.Red);
        int minGreen = input.Sets.Max(s => s.Green);
        int minBlue = input.Sets.Max(s => s.Blue);

        return new(minRed, minGreen, minBlue);
    }

    public static int GetColorSetPower(this ColorSet input)
    {
        return input.Red * input.Green * input.Blue;
    }
}
