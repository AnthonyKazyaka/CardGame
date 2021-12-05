using CardGameEngine.Cards;
using System.Collections.Generic;

namespace CardGameEngine.Players
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<IPlayingCard> Hand { get; set; } = new List<IPlayingCard>();

        public Player(string name)
        {
            Name = name;
        }

        public void AddCard(IPlayingCard card)
        {
            Hand.Add(card);
        }

        public void RemoveCard(Suit suit, Rank rank)
        {
            var card = Hand.Find(x => x.Suit == suit && x.Rank == rank);
            Hand.Remove(card);
        }

        public void ClearHand()
        {
            Hand.Clear();
        }
        
        public override string ToString()
        {
            return $"{Name} - {Score}";
        }

        public void AddScore(int score)
        {
            Score += score;
        }

        public void ResetScore()
        {
            Score = 0;
        }

        public void ResetHand()
        {
            ClearHand();
        }

        public void Reset()
        {
            ResetScore();
            ResetHand();
        }
    }
}
