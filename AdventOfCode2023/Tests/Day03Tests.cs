using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day03Tests
    {
        private readonly string[] _sample =
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day03.txt");

        private Day03 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day03();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(4361, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(522726, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(467835, _day.Part2(_sample));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(81721933, _day.Part2(_input));
        }
    }
}