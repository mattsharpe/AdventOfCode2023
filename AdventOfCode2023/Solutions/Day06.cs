using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solutions
{
    internal partial class Day06
    {
        public int Part1(string[] input)
        {
            var races = ParseInput(input);
            return races.Aggregate(1, (current, race) => current * Enumerable.Range(0, (int)race.Duration)
                            .Count(x => (race.Duration - x) * x > race.HighScore));
        }

        public long Part2(string[] input)
        {
            var condensedInput = input.Select(x => x.Replace(" ", "")).ToArray();

            var (b, highScore) = ParseInput(condensedInput)[0];

            const int a = -1;
            var c = -highScore;
            
            var squareRoot = Math.Sqrt(Math.Pow(b, 2) - 4 * a * c);

            var x1 = (-b + squareRoot) / (2 * a);
            var x2 = (-b - squareRoot) / (2 * a);

            var maxX = (long)Math.Ceiling(x2) - 1;
            var minX = (long)Math.Floor(x1) + 1;

            return maxX - minX + 1;
        }

        public List<(long Duration, long HighScore)> ParseInput(string[] input)
        {
            var lists = input.Select(line => Numbers().Matches(line).Select(m => long.Parse(m.Value))).ToList();

            return lists.First().Zip(lists.Last(), (a, b) => (a, b)).ToList();
        }

        [GeneratedRegex(@"\d+")]
        private static partial Regex Numbers();
    }
}