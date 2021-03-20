using System.Collections.Generic;

namespace CardGameEngine.Cards
{
    public interface IPointEvaluator
    {
        int EvaluatePoints(List<Card> cards);
    }
}
