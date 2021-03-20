namespace CardGameEngine.Cards
{
    public class Joker : Card, IPointValueCard
    {
        public PlayingCard RepresentedCard { get; private set; }

        public int GetPointValue(IPointEvaluator pointEvaluator)
        {
            return RepresentedCard.GetPointValue(pointEvaluator);
        }

        public void SetValue(Suit suit, Rank rank)
        {
            RepresentedCard = new PlayingCard(suit, rank);
        }
    }
}
