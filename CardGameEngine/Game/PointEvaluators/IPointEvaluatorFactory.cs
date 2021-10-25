namespace CardGameEngine.Game.PointEvaluators
{
    public interface IPointEvaluatorFactory
    {
        IPointEvaluator GetPointEvaluator(string evaluatorTypeName);
    }
}
