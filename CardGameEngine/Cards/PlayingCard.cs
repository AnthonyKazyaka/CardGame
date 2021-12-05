namespace CardGameEngine.Cards
{
    public class PlayingCard : IPlayingCard
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }

        public PlayingCard(Suit suit, Rank rank)
        {
            SetValue(suit, rank);
        }

        public void SetValue(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            string rankString = string.Empty;
            string suitString = Suit.ToString()[..1];

            if (Rank >= Rank.Two && Rank <= Rank.Ten)
            {
                rankString = ((int)Rank).ToString();
            }
            else if (Rank >= Rank.Jack)
            {
                rankString = Rank.ToString()[..1];
            }
            else if (Rank == Rank.Ace)
            {
                rankString = "A";
            }

            return rankString + suitString;
        }
    }
}
