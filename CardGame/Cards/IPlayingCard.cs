namespace CardGame.Cards
{
    public interface IPlayingCard
    {
        Suit Suit { get; }
        Rank Rank { get; }
        void SetValue(Suit suit, Rank rank);
        
        static IPlayingCard FromString(string value)
        {
            IPlayingCard playingCard;
            switch(value)
            {
                case "J" : 
                case "J*" : playingCard = new Joker();
                    break;
                // Any other string with a length of 2 or 3 should be attempted to be parsed 
                case string s when s.Length == 2  || s.Length == 3 : 
                    var suitAndRank = GetSuitAndRank(s);
                    playingCard = new PlayingCard(suitAndRank.Item1, suitAndRank.Item2);
                    break;
                default: throw new ArgumentException("Invalid card value");
            }

            return playingCard;
        }

        static (Suit suit, Rank rank) GetSuitAndRank(string value)
        {
            var suitValue = value[0];
            var rankValue = value[1..];

            var suit = (Suit)Enum.Parse(typeof(Suit), suitValue.ToString());
            var rank = (Rank)Enum.Parse(typeof(Rank), rankValue.ToString());

            return (suit, rank);
        }
    }
}
