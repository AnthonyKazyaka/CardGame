using CardGameEngine.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameEngine.Decks
{
    public class Deck
    {
        public List<Card> Cards { get; private set; }

        private static Random _random { get; } = new Random();

        public Deck(List<Card> cards)
        {
            Cards = cards;
        }

        public void Shuffle()
        {
            List<Card> unshuffledCards = new List<Card>(Cards);
            List<Card> shuffledCards = new List<Card>();

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
