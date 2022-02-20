using System.Collections.Generic;
using System.Linq;

namespace CardGameEngine.Cards
{
    public static class CardExtensions
    {
        public static bool IsRun(this List<IPlayingCard> cards)
        {
            var orderedCards = cards.OrderBy(x => x.Rank).ToList();

            if (cards.GroupBy(x => x.Suit).Count() != 1 || cards.GroupBy(x => x.Rank).Count() != cards.Count)
            {
                return false;
            }

            if (orderedCards.FirstOrDefault().Rank == Rank.Ace && !orderedCards.Any(x => x.Rank == Rank.Two))
            {
                orderedCards.Add(orderedCards.First());
                orderedCards.RemoveAt(0);
            }

            bool isMatch = true;
            for (int i = 1; i < orderedCards.Count; i++)
            {
                isMatch = isMatch && ((int)(orderedCards[i - 1].Rank + 1) % 13) == ((int)orderedCards[i].Rank) % 13;
            }

            return isMatch;
        }

        public static bool IsRunOfSize(this List<IPlayingCard> cards, int size) => cards.Count == size && IsRun(cards);

        public static bool IsSet(this List<IPlayingCard> cards)
        {
            return cards.All(x => x.Rank == cards.First().Rank) && cards.GroupBy(x=>x.Suit).Count() == cards.Count;
        }

        public static bool IsSetOfSize(this List<IPlayingCard> cards, int size) => cards.Count == size && IsSet(cards);

        public static bool IsJokerPresent(this List<IPlayingCard> cards) => GetJokerCount(cards) > 0;

        public static int GetJokerCount(this List<IPlayingCard> cards) => cards.OfType<Joker>().Count();

        public static IPlayingCard SelectCard(this List<IPlayingCard> cards, IPlayingCard card)
        {
            if(card is Joker)
            {
                return cards.First(x => x is Joker);
            }

            return cards.First(x =>x.Rank == card.Rank && x.Suit == card.Suit);
        }

        public static string ToString(this List<IPlayingCard> cards) => string.Join(", ", cards.Select(x => x.ToString()));
        public static List<IPlayingCard> FromString(this List<string> cardValues) => cardValues.Select(IPlayingCard.FromString).ToList();
    }
}
