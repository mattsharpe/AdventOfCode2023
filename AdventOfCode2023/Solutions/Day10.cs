using System.Numerics;

namespace AdventOfCode2023.Solutions
{
    public class Day10
    {
        public int Part1(string[] input)
        {
            var map = Parse(input);
            return FindPath(map).Count / 2;
        }

        public double Part2(string[] input)
        {
            var map = Parse(input);
            var path = FindPath(map);

            var corners = new List<Vector2> { map.Single(x => x.Value == "S").Key };
            corners.AddRange(path.Where(x => new []{"F", "7", "L", "J" }.Contains(map[x]) ));
    
            var area =  CalculateArea(corners);
            return area - path.Count / 2 + 1;

        }

        public double CalculateArea(List<Vector2> points)
        {
            double area = 0;

            for (var i = 0; i < points.Count; i++)
            {
                var nextIndex = (i + 1) % points.Count;
                area += (points[i].X * points[nextIndex].Y) - (points[i].Y * points[nextIndex].X);
            }

            return Math.Abs(area) / 2;
        }

        //return the location of all tiles on the path
        public List<Vector2> FindPath(Dictionary<Vector2, string> map)
        {
            var start = map.Single(x => x.Value== "S");
            List<Vector2> toExplore = [start.Key];

            var distance = -1;
            var distances = new Dictionary<Vector2, int>();

            while (toExplore.Count != 0)
            {
                distance++;
                var neighbours = new List<Vector2>();
                
                foreach (var nextLocation in toExplore)
                {
                    var nextType = map[nextLocation];
                    distances[nextLocation] = distance;

                    foreach (var direction in Directions[nextType])
                    {
                        var potentialLocation = nextLocation + direction;
                        var potentialNext = map.GetValueOrDefault(potentialLocation);
                        
                        //check we can go in this direction and we haven't already been here
                        if (potentialNext != null &&
                            Directions[potentialNext].Contains(direction * -1) &&
                            !distances.ContainsKey(potentialLocation))
                        {
                            neighbours.Add(potentialLocation);
                            break;
                        }
                    }
                }

                toExplore = neighbours;
            }

            return distances.Keys.ToList();
        }

        private Dictionary<Vector2, string> Parse(string[] input)
        {
            Dictionary<Vector2, string> map = [];
            foreach (var y in Enumerable.Range(0, input.Length))
            {
                foreach (var x in Enumerable.Range(0, input[0].Length))
                {
                    var value = input[y][x].ToString();
                    map.Add(new Vector2(x, y), value);
                }
            }

            return map;
        }

        private static readonly Vector2 North = new(0, -1);
        private static readonly Vector2 South = new(0, 1);
        private static readonly Vector2 East = new(1, 0);
        private static readonly Vector2 West = new(-1, 0);

        private static readonly Dictionary<string, List<Vector2>> Directions = new()
        {
            { "|", [North, South] },
            { "-", [East, West] },
            { "F", [East, South] },
            { "L", [North, East] },
            { "J", [North, West] },
            { "S", [North, East, South, West] },
            { "7", [West, South] },
            { ".", [] },
        };
    }
}