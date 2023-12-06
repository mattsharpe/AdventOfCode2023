using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day06Tests
    {
        private readonly string[] _sample = 
        {
            "Time:      7  15   30",
            "Distance:  9  40  200"
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day06.txt");

        private Day06 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day06();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(288, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(138915, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(71503, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(27340847, _day.Part2(_input));
        }
    }
}