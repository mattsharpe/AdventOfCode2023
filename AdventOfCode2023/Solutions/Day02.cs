using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solutions
{
    internal partial class Day02
    {
        public int Part1(string[] input)
        {
            var games = ParseInput(input);

            return games.Where(x =>
                x.Clues.TrueForAll(clue => clue.Red <= 12) && 
                x.Clues.TrueForAll(clue => clue.Green <= 13) &&
                x.Clues.TrueForAll(clue => clue.Blue <= 14))
            .Sum(x => x.Id);
        }

        public int Part2(string[] input)
        {
            var games = ParseInput(input);
            return games.Sum(x =>
                x.Clues.Max(clue => clue.Red) * 
                x.Clues.Max(clue => clue.Blue) * 
                x.Clues.Max(clue => clue.Green));
        }

        public IEnumerable<(int Id, List<Clue> Clues)> ParseInput(string[] input)
        {
            foreach (var game in input)
            {
                var id = Convert.ToInt32(Regex.Match(game, @"Game (\d+):").Groups[1].Value);
                var clues = new List<Clue>();
                var cluesInput = game.Split(";");

                foreach (var clue in cluesInput)
                {
                    clues.Add(new Clue(
                        RedRegex().IsMatch(clue) ? Convert.ToInt32(RedRegex().Match(clue).Groups[1].Value) : 0,
                        GreenRegex().IsMatch(clue) ? Convert.ToInt32(GreenRegex().Match(clue).Groups[1].Value) : 0,
                        BlueRegex().IsMatch(clue) ? Convert.ToInt32(BlueRegex().Match(clue).Groups[1].Value) : 0));
                }

                yield return (id, clues);
            }
        }

        [GeneratedRegex(@"(\d+) blue")]
        private static partial Regex BlueRegex();

        [GeneratedRegex(@"(\d+) green")]
        private static partial Regex GreenRegex();

        [GeneratedRegex(@"(\d+) red")]
        private static partial Regex RedRegex();
    }

    internal record Clue(int Red, int Green, int Blue);
}