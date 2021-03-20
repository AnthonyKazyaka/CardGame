namespace CardGameEngine.Decks
{
    public interface IDeckGenerator
    {
        DeckType TypeOfDeck { get; }
        Deck GenerateDeck();
    }
}
