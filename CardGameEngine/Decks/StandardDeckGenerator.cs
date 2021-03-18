using System;

namespace CardGameEngine.Decks
{
    public class StandardDeckGenerator : IDeckGenerator
    {
        public DeckType TypeOfDeck => DeckType.Standard;

        public Deck GenerateDeck()
        {
            throw new NotImplementedException();
        }
    }
}
