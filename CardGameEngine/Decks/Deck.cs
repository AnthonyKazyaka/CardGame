using CardGameEngine.Cards;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public virtual void Shuffle()
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

<<<<<<< Updated upstream
        public virtual IPlayingCard DrawCard()
        {
            IPlayingCard card = Cards.FirstOrDefault();
            if (card == null)
            {
                throw new IndexOutOfRangeException();
            }

            Cards.RemoveAt(0);
            return card;
=======

        public IPlayingCard DrawCard()
        {
            var topCard = Cards.First();
            Cards.RemoveAt(0);
            return topCard;
>>>>>>> Stashed changes
        }
    }
}
