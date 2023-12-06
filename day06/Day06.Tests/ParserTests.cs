using Day06;

namespace Day06.Tests
{
    public class Tests
    {
        [Test]
        public void GetPossibles()
        {
            long length = 7;
            List<long> expected = [0, 6, 10, 12, 12, 10, 6, 0];

            List<long> actual = length.GetPossibles();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetWinners()
        {
            long length = 7;
            long best = 9;
            long expected = 4;
            long actual = (length, best).NumberOfWins();

            Assert.That(actual, Is.EqualTo(expected));
        }

//Time:      71530
//Distance:  940200
        [Test]
        public void RealRace()
        {
            long length = 71530;
            long best = 940200;
            long expected = 71503;
            long actual = (length, best).NumberOfWins();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}