namespace CardGameEngine.Decks
{
    public class ExtendedDeckGenerator : IDeckGenerator
    {
        public DeckType TypeOfDeck => DeckType.Extended;

        public Deck GenerateDeck()
        {
            throw new System.NotImplementedException();
        }
    }
}
