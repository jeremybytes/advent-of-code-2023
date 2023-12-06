namespace Day06;

public static class DataParser
{
    public static long NumberOfWins(this (long, long) race)
    {
        (long length, long best) = race;
        return length.GetPossibles().GetWinners(best);
    }

    public static long GetWinners(this List<long> possibles, long best)
    {
        int winners = 0;
        foreach(var distance in possibles)
        {
            if (distance > best) winners++;
        }
        return winners;
    }

    public static List<long> GetPossibles(this long length)
    {
        List<long> possibles = [];
        for (long i = 0; i <= length; i++)
        {
            var distance = i * (length - i);
            possibles.Add(distance);
        }
        return possibles;
    }
}
