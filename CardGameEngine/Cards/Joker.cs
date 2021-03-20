namespace CardGameEngine.Cards
{
    public class Joker : Card, IPlayingCard
    {
        public PlayingCard RepresentedCard { get; private set; }

        public Suit Suit => RepresentedCard.Suit;

        public Rank Rank => RepresentedCard.Rank;

        public void SetValue(Suit suit, Rank rank)
        {
            RepresentedCard = new PlayingCard(suit, rank);
        }
    }
}
