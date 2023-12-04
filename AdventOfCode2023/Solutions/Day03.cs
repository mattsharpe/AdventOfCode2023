using System.Text.RegularExpressions;

namespace AdventOfCode2023.Solutions
{
    record Number (int Value, int Y, int Index, int Length);

    internal partial class Day03
    {
        public int Part1(string[] input)
        {
            var (symbols, numbers, _) = ParseInput(input);

            return numbers
                    .Where(n => symbols.Any(s => Borders(s, n)))
                    .Sum(x=>x.Value);
        }

        public int Part2(string[] input)
        {
            var (symbols, numbers, gears) = ParseInput(input);

            var gearRatios = new List<int>();

            foreach(var gear in gears)
            {
                var neighbours = numbers.Where(n => Borders(gear, n)).Select(n => n.Value);
                if(neighbours.Count() == 2)
                {
                    gearRatios.Add(neighbours.First() * neighbours.Last());
                }
            }
            
            return gearRatios.Sum();
        }

        bool Borders((int X, int Y) symbol, Number p2)
        {
            return Math.Abs(p2.Y - symbol.Y) <= 1 &&
               symbol.X <= p2.Index + p2.Length &&
               p2.Index <= symbol.X + 1;
        }

        private (List<(int X, int Y)> Symbols, List<Number> Numbers, List<(int X, int Y)> Gears) ParseInput(string[] input)
        {
            //get all the co-ords of the symbols in the grid
            var symbolLocations = (
                from y in Enumerable.Range(0, input.Length) 
                from x in Enumerable.Range(0, input[y].Length) 
                where Symbol().IsMatch(input[y][x].ToString()) 
                select (x, y)).ToList();

            var numbers = (
                from y in Enumerable.Range(0, input.Length)
                from match in Number().Matches(input[y])
                select new Number(int.Parse(input[y].Substring(match.Index, match.Length)), y, match.Index, match.Length)
                ).ToList();

            var gears = (
                from y in Enumerable.Range(0, input.Length)
                from x in Enumerable.Range(0, input[y].Length)
                where Gear().IsMatch(input[y][x].ToString())
                select (x, y)).ToList();

            return (symbolLocations, numbers, gears);
        }

        IEnumerable<(int X, int Y)> Neighbours((int X, int Y) location)
        {
            yield return location with { Y = location.Y - 1 };
            yield return location with { Y = location.Y + 1 };

            yield return (location.X - 1, location.Y - 1 );
            yield return (location.X + 1, location.Y - 1 );
            
            yield return (location.X - 1, location.Y + 1);
            yield return (location.X + 1, location.Y + 1);

            yield return location with { X = location.X - 1 };
            yield return location with { X = location.X + 1 };
        }

        [GeneratedRegex(@"[^.0-9]")]
        private static partial Regex Symbol();

        [GeneratedRegex(@"\d+")]
        private static partial Regex Number();

        [GeneratedRegex(@"\*")]
        private static partial Regex Gear();
    }
}