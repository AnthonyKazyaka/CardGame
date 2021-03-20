namespace CardGameEngine.Cards
{
    public class Joker : Card, IPlayingCard
    {
        public PlayingCard RepresentedCard { get; private set; }

        public void SetValue(Suit suit, Rank rank)
        {
            RepresentedCard = new PlayingCard(suit, rank);
        }
    }
}
