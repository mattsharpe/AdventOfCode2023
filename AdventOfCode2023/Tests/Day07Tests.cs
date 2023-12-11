using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day07Tests
    {
        private readonly string[] _sample =
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483"
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day07.txt");

        private Day07 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day07();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(6440, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(248422077, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(5905, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(249817836, _day.Part2(_input));
        }
    }
}