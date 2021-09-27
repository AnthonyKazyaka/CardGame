using CardGameEngine.Cards;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CardGameEngine.Cards.Tests
{
    public class CardExtensionTests
    {
        [Theory]
        [InlineData(0, false)]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(100, true)]
        public void IsJokerPresent(int numberOfJokers, bool expectedResult)
        {
            var cards = new Decks.StandardDeckGenerator().GenerateDeck().Cards;

            cards.AddRange(Enumerable.Repeat(new Joker(), numberOfJokers).ToList());

            Assert.Equal(expectedResult, cards.IsJokerPresent());
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(100, 100)]
        public void GetJokerCount(int numberOfJokers, int expectedResult)
        {
            var cards = new Decks.StandardDeckGenerator().GenerateDeck().Cards;

            cards.AddRange(Enumerable.Repeat(new Joker(), numberOfJokers).ToList());

            Assert.Equal(expectedResult, cards.GetJokerCount());
        }

        [Theory]
        [InlineData(Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.Ace)]
        public void IsSet_SameSuit(params Rank[] cardRanks)
        {
            var suit = Suit.Clubs;
            var cards = Enumerable.Range(0, cardRanks.Count()).Select(x => new PlayingCard(suit, cardRanks[x])).Cast<Card>().ToList();

            Assert.False(cards.IsSet());
        }

        [Theory]
        [InlineData(false, Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(true, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, Rank.Jack, Rank.Eight, Rank.Four)]
        public void IsSet_DifferentSuits(bool isSet, params Rank[] cardRanks)
        {
            var cards = new List<Card>();
            for(var i = 0; i < cardRanks.Length; i++)
            {
                cards.Add(new PlayingCard((Suit)i, cardRanks[i]));
            }
            
            Assert.Equal(isSet, cards.IsSet());
        }

        [Theory]
        [InlineData(false, Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(true, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, Rank.Jack, Rank.Eight, Rank.Four)]
        [InlineData(true, Rank.Ace, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, Rank.Ace, Rank.Ace, Rank.Ace, Rank.King)]
        [InlineData(true, Rank.Two, Rank.Two)]
        public void IsSetOfSize_ImplicitSize_DifferentSuits(bool isSet, params Rank[] cardRanks)
        {
            var cards = new List<Card>();
            for (var i = 0; i < cardRanks.Length; i++)
            {
                cards.Add(new PlayingCard((Suit)(i % 4), cardRanks[i]));
            }

            Assert.Equal(isSet, cards.IsSetOfSize(cards.Count));
        }

        [Theory]
        [InlineData(false, 3, Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(true, 3, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, 2, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, 4, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, 3, Rank.Jack, Rank.Eight, Rank.Four)]
        [InlineData(true, 4, Rank.Ace, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, 3, Rank.Ace, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, 4, Rank.Ace, Rank.Ace, Rank.Ace, Rank.King)]
        [InlineData(false, 3, Rank.Ace, Rank.Ace, Rank.Ace, Rank.King)]
        [InlineData(true, 2, Rank.Two, Rank.Two)]
        public void IsSetOfSize_ExplicitSize_DifferentSuits(bool isSet, int size, params Rank[] cardRanks)
        {
            var cards = new List<Card>();
            for (var i = 0; i < cardRanks.Length; i++)
            {
                cards.Add(new PlayingCard((Suit)(i % 4), cardRanks[i]));
            }

            Assert.Equal(isSet, cards.IsSetOfSize(size));
        }

        [Theory]
        [InlineData(true, Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(false, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, Rank.Eight, Rank.Four, Rank.Two)]
        [InlineData(true, Rank.Eight, Rank.Seven, Rank.Nine)]
        public void IsRun_SameSuit(bool isRun, params Rank[] cardRanks)
        {
            var suit = Suit.Clubs;
            var cards = Enumerable.Range(0, cardRanks.Count()).Select(x => new PlayingCard(suit, cardRanks[x])).Cast<Card>().ToList();

            Assert.Equal(isRun, cards.IsRun());
        }

        [Theory]
        [InlineData(Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(Rank.Eight, Rank.Four, Rank.Two)]
        [InlineData(Rank.Eight, Rank.Seven, Rank.Nine)]
        public void IsRun_DifferentSuits(params Rank[] cardRanks)
        {
            var cards = new List<Card>();
            for (var i = 0; i < cardRanks.Length; i++)
            {
                cards.Add(new PlayingCard((Suit)i, cardRanks[i]));
            }

            Assert.False(cards.IsRun());
        }

        [Theory]
        [InlineData(Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(Rank.Jack, Rank.Nine, Rank.Ten)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(Rank.Ace, Rank.Ace, Rank.Ace, Rank.King)]
        [InlineData(Rank.Two, Rank.Two)]
        public void IsRunOfSize_ImplicitSize_DifferentSuits(params Rank[] cardRanks)
        {
            var cards = new List<Card>();
            for (var i = 0; i < cardRanks.Length; i++)
            {
                cards.Add(new PlayingCard((Suit)(i % 4), cardRanks[i]));
            }

            Assert.False(cards.IsRunOfSize(cards.Count));
        }

        [Theory]
        [InlineData(true, 3, Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(false, 4, Rank.Ace, Rank.Two, Rank.Three)]
        [InlineData(false, 3, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(false, 2, Rank.Ace, Rank.Ace, Rank.Ace)]
        [InlineData(true, 2, Rank.Two, Rank.Three)]
        [InlineData(false, 2, Rank.Two, Rank.Three, Rank.Four)]
        [InlineData(true, 3, Rank.Queen, Rank.Jack, Rank.King)]
        [InlineData(true, 5, Rank.Queen, Rank.Jack, Rank.King, Rank.Ace, Rank.Ten)]
        [InlineData(false, 4, Rank.Queen, Rank.Jack, Rank.King, Rank.Ace, Rank.Ten)]
        public void IsRunOfSize_ExplicitSize_SameSuit(bool isRun, int size, params Rank[] cardRanks)
        {
            var suit = Suit.Clubs;
            var cards = Enumerable.Range(0, cardRanks.Count()).Select(x => new PlayingCard(suit, cardRanks[x])).Cast<Card>().ToList();

            Assert.Equal(isRun, cards.IsRunOfSize(size));
        }
    }
}
