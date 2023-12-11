namespace AdventOfCode2023.Solutions
{
    internal class Day07
    {
        public int Part1(string[] input)
        {
            var hands = ParseInput(input).ToList();
            hands.Sort();

            return hands.Select((hand, i) => hand.Bid * (i + 1)).Sum();
        }

        public int Part2(string[] input)
        {
            var hands = ParseInput(input, true).ToList();

            foreach (var hand in hands)
            {
                var potentialHands = GeneratePossibleHands(hand.Cards);
                potentialHands.Sort();
                hand.ProcessedHand = potentialHands.Last().Cards;
            }

            hands.Sort();

            return hands.Select((hand, i) => hand.Bid * (i + 1)).Sum();
        }

        public List<Hand> GeneratePossibleHands(string cards)
        {
            var possibleHands = new List<string>();

            var jokerCount = cards.Count(c => c == 'J');

            //add a couple of optimisations to speed up the process
            if (jokerCount == cards.Length)
            {
                // All Jokers: Return a hand of all Aces
                possibleHands.Add(new string('A', cards.Length));
            }
            else if (cards.Length - jokerCount == 1)
            {
                // Only one non-Joker card: Make all Jokers the same as the non-Joker card
                var nonJokerCard = cards.First(c => c != 'J');
                possibleHands.Add(new string(nonJokerCard, cards.Length));
            }
            else
            {
                // Normal case: Use recursion to generate all combinations
                GenerateHandsRecursive(cards, 0, possibleHands);
            }

            var processedHands = possibleHands.Select(x => new Hand(x, 0, true)).ToList();
            return processedHands;
        }

        private void GenerateHandsRecursive(string hand, int index, List<string> possibleHands)
        {
            if (index >= hand.Length)
            {
                // If reached the end of the hand, add the current combination to the list
                possibleHands.Add(hand);
                return;
            }

            if (hand[index] == 'J')
            {
                var validCards = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A" };
                // If the current card is a Joker, replace it with each possible card value
                foreach (var cardValue in validCards)
                {
                    var newHand = string.Concat(hand.AsSpan(0, index), cardValue, hand.AsSpan(index + 1));
                    GenerateHandsRecursive(newHand, index + 1, possibleHands);
                }
            }
            else
            {
                GenerateHandsRecursive(hand, index + 1, possibleHands);
            }
        }

        private IEnumerable<Hand> ParseInput(string[] input, bool jokers = false)
        {
            foreach (var line in input)
            {
                var split = line.Split(" ");
                yield return new Hand(split[0], int.Parse(split[1]), jokers);
            }
        }
    }

    record Hand(string Cards, int Bid, bool Jokers = false) : IComparable<Hand>
    {

        public string ProcessedHand { get; set; } = Cards;

        public HandType HandType
        {
            get
            {
                var groups = ProcessedHand.GroupBy(x => x)
                    .Select(group => group.Count())
                    .OrderByDescending(count => count).ToList();

                var result = groups.First() switch
                {
                    5 => HandType.FiveOfAKind,
                    4 => HandType.FourOfAKind,
                    3 => groups.Count == 2 ? HandType.FullHouse : HandType.ThreeOfAKind,
                    2 => groups.Count == 3 ? HandType.TwoPair : HandType.Pair,
                    _ => HandType.HighCard
                };

                return result;
            }
        }

        public int CompareTo(Hand other)
        {
            if (HandType > other.HandType)
                return 1;
            if (HandType < other.HandType)
                return -1;
            return CompareHand(other.Cards);
        }

        private int CompareHand(string other)
        {
            for (var i = 0; i < Cards.Length; i++)
            {
                var card = Cards[i];
                var otherCard = other[i];

                if (card == otherCard)
                    continue;
                
                var cardValue = GetCardValue(card.ToString());
                var otherCardValue = GetCardValue(otherCard.ToString());
                return cardValue.CompareTo(otherCardValue);
            }

            return 0;
        }

        int GetCardValue(string card)
        {
            if (card == "J" && Jokers)
            {
                return 1;
            }
            return CardValues[card];
        }

        public Dictionary<string, int> CardValues => new()
        {
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"T", 10},
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
        };
    }

    public enum HandType
    {
        HighCard = 0,
        Pair = 1,
        TwoPair = 2,
        ThreeOfAKind = 3,
        FullHouse = 4,
        FourOfAKind = 5,
        FiveOfAKind = 6
    }
}