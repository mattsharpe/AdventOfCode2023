using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day09Tests
    {
        private readonly string[] _sample =
        {
            "0 3 6 9 12 15",
            "1 3 6 10 15 21",
            "10 13 16 21 30 45"
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day09.txt");

        private Day09 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day09();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(114, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(1681758908, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(2, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(803, _day.Part2(_input));
        }
    }
}