using System;
using System.Linq;

namespace CardGameEngine.Cards
{
    public class Card
    {
        public Suit Suit { get; protected set; }
        public Rank Rank { get; protected set; }

        private static Random Random { get; } = new Random();

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public static Card GenerateRandomCard()
        {
            var suits = Enum.GetNames(typeof(Suit))
                                .Select(x => (Suit)Enum.Parse(typeof(Suit), x)).ToList();

            var ranks = Enum.GetNames(typeof(Rank))
                                .Select(x => (Rank)Enum.Parse(typeof(Rank), x)).ToList();

            var randomSuit = suits[Random.Next(suits.Count)];
            var randomRank = ranks[Random.Next(ranks.Count)];

            return new Card(randomSuit, randomRank);
        }
    }
}
