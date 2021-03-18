using System.Collections.Generic;
using System.Linq;

namespace CardGameEngine.Decks
{
    public class DeckFactory : IDeckFactory
    {
        private List<IDeckGenerator> _deckGenerators;

        public DeckFactory(List<IDeckGenerator> deckGenerators)
        {
            _deckGenerators = deckGenerators;
        }

        public Deck GenerateDeck(DeckType deckType)
        {
            var specifiedDeckTypeGenerator = _deckGenerators.FirstOrDefault(x => x.TypeOfDeck == deckType);
            if(specifiedDeckTypeGenerator != null)
            {
                return specifiedDeckTypeGenerator.GenerateDeck();
            }

            return null;
        }
    }
}
