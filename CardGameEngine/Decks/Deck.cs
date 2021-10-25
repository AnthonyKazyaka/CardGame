using CardGameEngine.Cards;
using System;
using System.Collections.Generic;

namespace CardGameEngine.Decks
{
    public class Deck
    {
        public List<IPlayingCard> Cards { get; private set; }

        private static Random _random { get; } = new Random();

        public Deck(List<IPlayingCard> cards)
        {
            Cards = cards;
        }

        public void Shuffle()
        {
            List<IPlayingCard> unshuffledCards = new List<IPlayingCard>(Cards);
            List<IPlayingCard> shuffledCards = new List<IPlayingCard>();

            for (int i = 0; i < Cards.Count; i++)
            {
                var index = _random.Next(unshuffledCards.Count);
                shuffledCards.Add(unshuffledCards[index]);
                unshuffledCards.RemoveAt(index);
            }

            Cards = shuffledCards;
        }

    }
}
