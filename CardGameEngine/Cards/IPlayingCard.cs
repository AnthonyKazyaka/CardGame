using System;
using System.Text.RegularExpressions;

namespace CardGameEngine.Cards
{
    public interface IPlayingCard
    {
        Suit Suit { get; }
        Rank Rank { get; }
        void SetValue(Suit suit, Rank rank);

        virtual bool Equals(object obj)
        {
            return obj is IPlayingCard card && card.Suit == Suit && card.Rank == Rank;
        }

        virtual bool Equals(IPlayingCard playingCard)
        {
            return playingCard.Suit == Suit && playingCard.Rank == Rank;
        }

        static IPlayingCard FromString(string cardValue)
        {
            if (string.IsNullOrWhiteSpace(cardValue) || cardValue.Length < 2 || cardValue.Length > 3)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (cardValue.Equals("J*"))
            {
                return new Joker();
            }

            Suit suit = GetSuitFromString(cardValue);
            Rank rank = GetRankFromString(cardValue);

            return new PlayingCard(suit, rank);
        }

        static Rank GetRankFromString(string input)
        {
            var match = Regex.Match(input, "\\d+");
            if (match.Success)
            {
                return (Rank)int.Parse(match.Value);
            }

            var highCardValue = Regex.Match(input, "[JQKA]");

            return highCardValue.Value switch
            {
                "A" => Rank.Ace,
                "K" => Rank.King,
                "Q" => Rank.Queen,
                "J" => Rank.Jack,
                _ => throw new NotImplementedException()
            };
        }

        static Suit GetSuitFromString(string input)
        {
            var match = Regex.Match(input, "[HDSC]");
            if (match.Success)
            {
                return match.Value switch
                {
                    "H" => Suit.Hearts,
                    "D" => Suit.Diamonds,
                    "C" => Suit.Clubs,
                    "S" => Suit.Spades,
                    _ => throw new NotImplementedException()
                };
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
