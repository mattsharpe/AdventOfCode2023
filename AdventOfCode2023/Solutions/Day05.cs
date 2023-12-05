using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solutions
{
    internal partial class Day05
    {
        public long Part1(string input)
        {
            var (seeds, maps) = ParseInput(input);

            return seeds.Min(seed =>
            {
                var value = seed;
                foreach (var map in maps)
                {
                    var item = map.FirstOrDefault(i => value >= i.Start && value <= i.End);
                    if (item != null)
                    {
                        value += item.Adjustment;
                    }
                }
                return value;
            });
        }

        public long Part2(string input)
        {
            var (seeds, maps) = ParseInput(input);

            var ranges = Enumerable.Range(0, seeds.Count / 2)
                                   .Select(i => (From: seeds[i * 2], To: seeds[i * 2] + seeds[i * 2 + 1] - 1))
                                   .ToList();

            foreach (var map in maps)
            {
                var orderedMap = map.OrderBy(x => x.Start).ToList();
                var newRanges = new List<(long from, long to)>();

                foreach (var range in ranges)
                {
                    var (from, to) = range;
                    foreach (var mapping in orderedMap)
                    {
                        if (from < mapping.Start)
                        {
                            newRanges.Add((from, Math.Min(to, mapping.Start - 1)));
                            from = mapping.Start;
                        }

                        if (from <= mapping.End)
                        {
                            newRanges.Add((from + mapping.Adjustment, Math.Min(to, mapping.End) + mapping.Adjustment));
                            from = mapping.End + 1;
                        }

                        if (from > to) break;
                    }

                    if (from < to) newRanges.Add((from, to));
                }
                ranges = newRanges;
            }

            return ranges.Min(r => r.From);
        }

        private (List<long> seeds, List<List<Range>> maps) ParseInput(string input)
        {
            var inputArray = input.Split(Environment.NewLine);
            
            var groups = input.Split($"{Environment.NewLine}{Environment.NewLine}");
            var seeds = Number().Matches(groups[0]).Select(x => Convert.ToInt64(x.Value)).ToList();

            var maps = new List<List<Range>>();

            foreach (var section in groups.Skip(1))
            {
                var map = new List<Range>();
                var ranges = section.Split(Environment.NewLine).Skip(1);
                foreach(var range in ranges)
                {
                    var rangeValues = Number().Matches(range).Select(x => Convert.ToInt64(x.Value)).ToList();
                    map.Add(new Range(rangeValues[1], rangeValues[1] + rangeValues[2] - 1, rangeValues[0] - rangeValues[1]));
                }
                maps.Add(map);
            }

            return (seeds, maps);
        }

        [GeneratedRegex(@"\d+")]
        private static partial Regex Number();

        record Range(long Start, long End, long Adjustment);
    }    
}