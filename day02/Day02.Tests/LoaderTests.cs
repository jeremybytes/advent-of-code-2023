using DataLoader;

namespace Day02.Tests
{
    public class Tests
    {
        // Parse This
        string test1 = """Game 1: 1 green, 1 blue, 1 red; 1 green, 8 red, 7 blue; 6 blue, 10 red; 4 red, 9 blue, 2 green; 1 green, 3 blue; 4 red, 1 green, 10 blue""";

        [Test]
        public void GetGameNumber()
        {
            int actual = Loader.GetGameNumber(test1);
            Assert.That(actual, Is.EqualTo(1));
        }

        [TestCase("1 green, 1 blue, 1 red", 1, 1, 1)]
        [TestCase("1 green, 8 red, 7 blue", 8, 1, 7)]
        public void GetSet(string input, int expectedRed, int expectedGreen, int expectedBlue)
        {
            ColorSet actual = Loader.GetSet(input);
            Assert.That(actual.Red, Is.EqualTo(expectedRed));
            Assert.That(actual.Green, Is.EqualTo(expectedGreen));
            Assert.That(actual.Blue, Is.EqualTo(expectedBlue));
        }
    }
}