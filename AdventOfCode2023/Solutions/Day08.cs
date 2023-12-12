using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solutions
{
    internal partial class Day08
    {
        public long Part1(string[] input)
        {
            var (instructions, map) = Parse(input);

            return StepsToTarget("AAA", "ZZZ", instructions, map);
        }

        public long Part2(string[] input)
        {
            var (instructions, map) = Parse(input);

            var ghosts = map.Keys.Where(x => x.EndsWith('A')).ToList();
            var steps = ghosts.Select(ghost => StepsToTarget(ghost, "Z", instructions, map));
            
            return steps.Aggregate(1L, LowestCommonMultiple);
        }

        long StepsToTarget(string current, string target, string instructions, Dictionary<string, (string Left, string Right)> map)
        {
            var i = 0;
            while (!current.EndsWith(target))
            {
                foreach (var instruction in instructions)
                {
                    current = instruction == 'L' ? map[current].Left : map[current].Right;
                    i++;
                }
            }
            return i;
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public static long LowestCommonMultiple(long a, long b) => a / GreatestCommonDivisor(a, b) * b;


        public (string instructions, Dictionary<string, (string Left, string Right)> result) Parse(string[] input)
        {
            //take the first line and split it into individual instructions
            var instructions = input[0];
            
            var result = input.Skip(2)
                .Select(instruction => WordRegex().Matches(instruction))
                .ToDictionary(matches => matches[0].Value, matches => (matches[1].Value, matches[2].Value));

            return (instructions, result);
        }

        [GeneratedRegex(@"\w+")]
        private static partial Regex WordRegex();
    }
}