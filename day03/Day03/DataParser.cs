namespace Day03;

public static class DataParser
{
    public static List<((int, int), int)> PotentialGears = new();

    public record PartNumber(int Number, int Length, int Row, int Index, bool Include) { }

    public static List<PartNumber> GetAllNumbers(this List<string> input)
    {
        List<PartNumber> output = new();
        for (int i = 0; i < input.Count; i++)
        {
            output.AddRange(input[i].GetNumbersFromLine(i));
        }
        return output;
    }

    public static List<PartNumber> GetNumbersFromLine(this string input, int row)
    {
        // ..35..633.
        List<PartNumber> output = new();
        string numberString = "";
        int index = -1;
        //foreach(var c in input)
        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    numberString += input[i];
                    if (index == -1) index = i;
                    break;
                default: // . or symbol
                    if (string.IsNullOrEmpty(numberString)) continue;
                    int number = int.Parse(numberString);
                    output.Add(new(number, numberString.Count(), row, index, false));
                    numberString = "";
                    index = -1;
                    break;
            }
        }
        if (!string.IsNullOrEmpty(numberString))
        {
            int number = int.Parse(numberString);
            output.Add(new(number, numberString.Count(), row, index, false));
        }
        return output;
    }

    public static List<int> GetPartNumbers(this List<PartNumber> numbers, List<string> allData)
    {
        List<int> output = new();
        foreach(var number in numbers)
        {
            if (IsPartNumber(number, allData))
                output.Add(number.Number);
        }
        return output;
    }

    public static bool IsPartNumber(PartNumber partNumber, List<string> allData)
    {
        (int, int) startIndex = 
            (int.Max(partNumber.Row - 1, 0), 
             int.Max(partNumber.Index-1, 0));
        (int, int) endIndex = 
            (int.Min(partNumber.Row + 1, allData.Count-1), 
             int.Min(partNumber.Index + partNumber.Length + 1, allData[0].Length-1));

        return ContainsSymbol(startIndex, endIndex, allData);
    }

    private static bool ContainsSymbol((int, int) start, (int, int) end, List<string> allData)
    {
        string ignoreChars = "0123456789.";
        for (int row = start.Item1; row <= end.Item1; row++)
        {
            for (int column = start.Item2; column < end.Item2; column++)
            {
                if (!ignoreChars.Contains(allData[row][column]))
                    return true;
            }
        }
        return false;
    }

    public static List<((int, int), int)> GetPotentialGears(this List<PartNumber> numbers, List<string> allData)
    {
        foreach (var number in numbers)
        {
            IsGearAdjacent(number, allData);
        }
        return PotentialGears;
    }

    public static List<((int, int), int)> GetActualGears(this List<((int, int), int)> potentials)
    {
        List<((int, int), int)> actuals = new();
        foreach(var potential in potentials)
        {
            if (potentials.Count(p => p.Item1 == potential.Item1) > 1)
            {
                actuals.Add(potential);
            }
        }
        return actuals;
    }

    public static List<int> GetGearProducts(this List<((int, int), int)> actualGears)
    {
        List<int> output = new();
        while(actualGears.Count > 0)
        {
            var current = actualGears[0].Item1;
            int nextProduct = 
                actualGears
                .Where(g => g.Item1 == current)
                .Select(g => g.Item2)
                .Aggregate((number, next) => number * next);
            output.Add(nextProduct);
            actualGears.RemoveAll(g => g.Item1 == current);
        }
        return output;
    }

    public static void IsGearAdjacent(PartNumber partNumber, List<string> allData)
    {
        (int, int) startIndex =
            (int.Max(partNumber.Row - 1, 0),
             int.Max(partNumber.Index - 1, 0));
        (int, int) endIndex =
            (int.Min(partNumber.Row + 1, allData.Count - 1),
             int.Min(partNumber.Index + partNumber.Length + 1, allData[0].Length - 1));

        var gearLocation = ContainsGear(startIndex, endIndex, allData);
        if (gearLocation is not null)
            PotentialGears.Add(((gearLocation.Value), partNumber.Number));
    }

    private static (int, int)? ContainsGear((int, int) start, (int, int) end, List<string> allData)
    {
        for (int row = start.Item1; row <= end.Item1; row++)
        {
            for (int column = start.Item2; column < end.Item2; column++)
            {
                if (allData[row][column] == '*')
                    return (row, column);
            }
        }
        return null;
    }
}
