namespace CardGameEngine.Cards
{
    public interface IPointValueCard
    {
        int GetPointValue(IPointEvaluator pointEvaluator);
        void SetValue(Suit suit, Rank rank);
    }
}
