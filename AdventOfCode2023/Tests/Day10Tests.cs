using AdventOfCode2023.Solutions;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class Day10Tests
    {
        private readonly string[] _sample1 =
        {
            "-L|F7",
            "7S-7|",
            "L|7||",
            "-L-J|",
            "L|-JF"
        };        
        
        private readonly string[] _sample2 =
        {
            "7-F7-",
            ".FJ|7",
            "SJLL7",
            "|F--J",
            "LJ.LJ"
        };

        private readonly string[] _sample3 =
        {
            "...........",
            ".S-------7.",
            ".|F-----7|.",
            ".||.....||.",
            ".||.....||.",
            ".|L-7.F-J|.",
            ".|..|.|..|.",
            ".L--J.L--J.",
            "...........",
        };

        private readonly string[] _sample4 =
        {
            ".F----7F7F7F7F-7....",
            ".|F--7||||||||FJ....",
            ".||.FJ||||||||L7....",
            "FJL7L7LJLJ||LJ.L-7..",
            "L--J.L7...LJS7F-7L7.",
            "....F-J..F7FJ|L7L7L7",
            "....L7.F7||L7|.L7L7|",
            ".....|FJLJ|FJ|F7|.LJ",
            "....FJL-7.||.||||...",
            "....L---J.LJ.LJLJ..."
        };

        private readonly string[] _input = File.ReadAllLines("Input/Day10.txt");

        private Day10 _day = new();

        [TestInitialize]
        public void Initialize()
        {
            _day = new Day10();
        }

        [TestMethod]
        public void Part1Sample1()
        {
            Assert.AreEqual(4, _day.Part1(_sample1));
        }

        [TestMethod]
        public void Part1Sample2()
        {
            Assert.AreEqual(8, _day.Part1(_sample2));
        }
        [TestMethod]
        public void Part1()
        {
            Assert.AreEqual(6714, _day.Part1(_input));
        }

        [TestMethod]
        public void Part2Sample1()
        {
            Assert.AreEqual(4, _day.Part2(_sample3));
        }

        [TestMethod]
        public void Part2Sample2()
        {
            Assert.AreEqual(8, _day.Part2(_sample4));
        }

        [TestMethod]
        public void Part2()
        {
            Assert.AreEqual(429, _day.Part2(_input));
        }
    }
}