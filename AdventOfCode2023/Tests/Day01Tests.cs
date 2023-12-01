using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day01Tests
    {
        private readonly string[] _sample = 
        {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        };

        private readonly string[] _sample2 =
        {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen",
        };

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
            Assert.AreEqual(142, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(54632, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(281, _day.Part2(_sample2));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(54019, _day.Part2(_input));
        }
    }
}