namespace CardGameEngine.Cards
{
    public interface IPlayingCard
    {
        Suit Suit { get; }
        Rank Rank { get; }
        void SetValue(Suit suit, Rank rank);
    }
}
