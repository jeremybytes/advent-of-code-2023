using Microsoft.VisualStudio.TestPlatform.CoreUtilities.Extensions;

namespace Day01.Tests;

public class Tests
{

//62jrjfrdcldbvjzhp
//onecsqpbrxpmqtrbbtxnrhkdlthree3s1six
//two798tqsjv
//znktgzzmtwo28
//8hllzrjqhvfone
//tgnlbtc2ninejmcsixfour
//fivek1five
//rklpvqfvtwo3
//lgdgchcpcl55hfdmdj
//onesix7onefive9
//jrnthree46seven

    [TestCase("62jrjfrdcldbvjzhp", "62")]
    [TestCase("onecsqpbrxpmqtrbbtxnrhkdlthree3s1six", "13316")]
    [TestCase("two798tqsjv", "2798")]
    [TestCase("znktgzzmtwo28", "228")]
    [TestCase("8hllzrjqhvfone", "81")]
    [TestCase("tgnlbtc2ninejmcsixfour", "2964")]
    [TestCase("fivek1five", "515")]
    [TestCase("rklpvqfvtwo3", "23")]
    [TestCase("lgdgchcpcl55hfdmdj", "55")]
    [TestCase("onesix7onefive9", "167159")]
    [TestCase("jrnthree46seven", "3467")]
    public void FindNumbers_ReturnsExpectedValues(string input, string expected)
    {
        var list = DataParser.FindNumbers(input);
        if (list is null)
            Assert.Fail("Did not find any values");

        string actual = "";
        foreach (int digit in list!)
            actual += digit.ToString();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("62jrjfrdcldbvjzhp", "62")]
    [TestCase("onecsqpbrxpmqtrbbtxnrhkdlthree3s1six", "16")]
    [TestCase("two798tqsjv", "28")]
    [TestCase("znktgzzmtwo28", "28")]
    [TestCase("8hllzrjqhvfone", "81")]
    [TestCase("tgnlbtc2ninejmcsixfour", "24")]
    [TestCase("fivek1five", "55")]
    [TestCase("rklpvqfvtwo3", "23")]
    [TestCase("lgdgchcpcl55hfdmdj", "55")]
    [TestCase("onesix7onefive9", "19")]
    [TestCase("jrnthree46seven", "37")]
    public void FirstAndLast_ReturnsExpectedValues(string input, string expected)
    {
        var list = DataParser.FindNumbers(input);
        if (list is null)
            Assert.Fail("Did not find any values");

        var firstLast = DataParser.FirstAndLastDigits(list!);

        string actual = firstLast.Item1.ToString();
            actual += firstLast.Item2.ToString();

        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase("62jrjfrdcldbvjzhp", 62)]
    [TestCase("onecsqpbrxpmqtrbbtxnrhkdlthree3s1six", 16)]
    [TestCase("two798tqsjv", 28)]
    [TestCase("znktgzzmtwo28", 28)]
    [TestCase("8hllzrjqhvfone", 81)]
    [TestCase("tgnlbtc2ninejmcsixfour", 24)]
    [TestCase("fivek1five", 55)]
    [TestCase("rklpvqfvtwo3", 23)]
    [TestCase("lgdgchcpcl55hfdmdj", 55)]
    [TestCase("onesix7onefive9", 19)]
    [TestCase("jrnthree46seven", 37)]
    public void FullRun_ReturnsExpectedValues(string input, int expected)
    {
        var list = DataParser.FindNumbers(input);
        if (list is null)
            Assert.Fail("Did not find any values");

        var firstLast = DataParser.FirstAndLastDigits(list!);

        var actual = DataParser.CombineTupleToInt(firstLast);

        Assert.That(actual, Is.EqualTo(expected));
    }

}