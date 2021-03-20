namespace CardGameEngine.Cards
{
    public class PlayingCard : Card, IPlayingCard
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public PlayingCard(Suit suit, Rank rank)
        {
            SetValue(suit, rank);
        }

        public int GetPointValue(IPointEvaluator pointEvaluator)
        {
            return pointEvaluator.EvaluatePoints(this);
        }

        public void SetValue(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
