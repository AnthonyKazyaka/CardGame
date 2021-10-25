using CardGameEngine.Cards;
using System.Collections.Generic;

namespace CardGameEngine.Game.PointEvaluators
{
    public interface IPointEvaluator
    {
        int EvaluatePoints(List<IPlayingCard> cards);
    }
}
