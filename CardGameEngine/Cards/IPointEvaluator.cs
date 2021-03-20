using System.Collections.Generic;

namespace CardGameEngine.Cards
{
    public interface IPointEvaluator
    {
        bool IsValidCardForEvaluator(Card card);
        int EvaluatePoints(Card card);
        int EvaluatePoints(List<Card> cards);
    }
}
