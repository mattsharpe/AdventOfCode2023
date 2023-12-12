using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day08Tests
    {
        private readonly string[] _sample =
        {
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)"
        };

        private readonly string[] _sample2 =
        {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)"
        };

        private readonly string[] _sample3 =
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)"
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day08.txt");

        private Day08 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day08();
        }

        [TestMethod]
        public void Part1Sample()
        {
            Assert.AreEqual(2, _day.Part1(_sample));
        }

        [TestMethod]
        public void Part1Sample2()
        {
            Assert.AreEqual(6, _day.Part1(_sample2));
        }

        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(20777, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample()
        {
            Assert.AreEqual(6, _day.Part2(_sample3));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(13289612809129, _day.Part2(_input));
        }
    }
}