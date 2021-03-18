namespace CardGameEngine.Decks
{
    public interface IDeckFactory
    {
        Deck GenerateDeck(DeckType deckType);
    }
}
