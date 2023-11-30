using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day01Tests
    {
        private readonly string[] _sample = {""};

        private readonly string[] _input = File.ReadAllLines("Input/Day01.txt");

        private Day01 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day01();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(0, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(0, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(0, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(0, _day.Part2(_input));
        }
    }
}