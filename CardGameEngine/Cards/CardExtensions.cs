using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGameEngine.Cards
{
    public static class CardExtensions
    {
        public static bool IsRun(this List<Card> cards)
        {
            var playingCards = cards.Cast<IPlayingCard>().ToList();
            var orderedCards = playingCards.OrderBy(x => x.Rank).ToList();

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

        public static bool IsRunOfSize(this List<Card> cards, int size)
        {
            return cards.Count == size && IsRun(cards);
        }

        public static bool IsSet(this List<Card> cards)
        {
            var playingCards = cards.Cast<IPlayingCard>().ToList();
            return playingCards.All(x => x.Rank == playingCards.First().Rank) && playingCards.GroupBy(x=>x.Suit).Count() == playingCards.Count;
        }

        public static bool IsSetOfSize(this List<Card> cards, int size)
        {
            return cards.Count == size && IsSet(cards);
        }
    }
}
