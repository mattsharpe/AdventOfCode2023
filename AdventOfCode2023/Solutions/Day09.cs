namespace AdventOfCode2023.Solutions
{
    internal class Day09
    {
        public long Part1(string[] input)
        {
            var list = ParseInput(input);

            return list.Sum(NextInSequence);
        }

        public long Part2(string[] input)
        {
            var list = ParseInput(input);

            return list.Sum(line =>
            {
                line.Reverse();
                return NextInSequence(line);
            });
        }

        private long NextInSequence(List<long> sequence)
        {
            return sequence.Count == 0 ? 0 : NextInSequence(GetDelta(sequence)) + sequence.Last();
        }
        
        private List<long> GetDelta(List<long> sequence)
        {
            return sequence.Zip(sequence.Skip(1), (a, b) => b - a).ToList();
        }

        private IEnumerable<List<long>> ParseInput(string[] input)
        {
            return input.Select(line => line.Split(" ").Select(long.Parse).ToList()).ToList();
        }


    }
}