namespace CardGameEngine.Cards
{
    public class PlayingCard : IPlayingCard
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public PlayingCard(Suit suit, Rank rank)
        {
            SetValue(suit, rank);
        }

        public void SetValue(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
