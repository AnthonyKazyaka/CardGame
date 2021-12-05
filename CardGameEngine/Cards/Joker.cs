namespace CardGameEngine.Cards
{
    public class Joker : IPlayingCard
    {
        public PlayingCard RepresentedCard { get; private set; }

        public Suit Suit => RepresentedCard.Suit;

        public Rank Rank => RepresentedCard.Rank;

        public void SetValue(Suit suit, Rank rank)
        {
            RepresentedCard = new PlayingCard(suit, rank);
        }

        public override string ToString()
        {
            return "J*";
        }
    }
}
