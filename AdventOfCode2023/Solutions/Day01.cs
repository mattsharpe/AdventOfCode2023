
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solutions
{
    internal class Day01
    {
        public int Part1(string[] input)
        {
            var numbers = ParseInput(input);
            return numbers.Sum();
        }

        public int Part2(string[] input)
        {
            const string regex = @"\d|one|two|three|four|five|six|seven|eight|nine";
            var numbers = ParseInput(input, regex);
            return numbers.Sum();
        }

        private IEnumerable<int> ParseInput(string[] input, string regex = @"\d")
        {
            
            foreach (var line in input)
            {
                var first = ParseValue(Regex.Match(line, regex).Value);
                var last = ParseValue(Regex.Match(line, regex, RegexOptions.RightToLeft).Value);

                var result = Convert.ToInt32($"{first}{last}");
                
                yield return result;
            }
        }

        private static int ParseValue(string value)
        {
            var result = value switch
            {
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => 0
            };
            return result > 0 ? result : Convert.ToInt32(value);
        }
    }
}