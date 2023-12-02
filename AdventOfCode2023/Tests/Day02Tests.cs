using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day02Tests
    {
        private readonly string[] _sample =
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day02.txt");

        private Day02 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day02();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(8, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(2268, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(2286, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(63542, _day.Part2(_input));
        }
    }
}