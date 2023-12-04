using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solutions
{
    internal partial class Day04
    {
        public int Part1(string[] input)
        {
            var parsed = ParseInput(input);

            return parsed.Sum(x => x > 0 ? (int)Math.Pow(2, x - 1)  : 0);
        }

        public int Part2(string[] input)
        {
            var cards = ParseInput(input).ToList();
            
            var counts = Enumerable.Repeat(1, cards.Count).ToList();

            var current = 0;
            foreach (var cardScore in cards)
            {
                var count = counts[current];
                for (var i = 0; i < cardScore; i++)
                {
                    if (current + i + 1 < counts.Count)
                    {
                        counts[current + i + 1] += count;
                    }
                }
                current++;
            }

            return counts.Sum();

        }

        public IEnumerable<int> ParseInput(string[] input)
        {
            return from line in input select line.Split(':')[1].Split("|") into cardDetails 
                let numbers = Number().Matches(cardDetails[0]).Select(x => Convert.ToInt32(x.Value)).ToList() 
                let winners = Number().Matches(cardDetails[1]).Select(x => Convert.ToInt32(x.Value)).ToList() 
                select winners.Intersect(numbers).Count();
        }

        [GeneratedRegex(@"\d+")]
        private static partial Regex Number();
    }
}