using CardGameEngine.Cards;
using System.Collections.Generic;

namespace CardGameEngine.Players
{
    public class Player
    {
        public int Score { get; set; }
        public List<Card> Hand { get; set; } = new List<Card>();
    }
}
