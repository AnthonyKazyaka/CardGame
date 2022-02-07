namespace CardGameEngine.Cards
{
    public interface IPlayingCard
    {
        Suit Suit { get; }
        Rank Rank { get; }
        void SetValue(Suit suit, Rank rank);

        virtual bool Equals(object obj)
        {
            return obj is IPlayingCard card && card.Suit == Suit && card.Rank == Rank;
        }

        virtual bool Equals(IPlayingCard playingCard)
        {
            return playingCard.Suit == Suit && playingCard.Rank == Rank;
        }
    }
}
