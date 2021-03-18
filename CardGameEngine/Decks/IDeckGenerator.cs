using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameEngine.Decks
{
    public interface IDeckGenerator
    {
        DeckType TypeOfDeck { get; }
        Deck GenerateDeck();
    }
}
