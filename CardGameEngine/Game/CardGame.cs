using System;
using System.Collections.Generic;
using System.Text;

namespace CardGameEngine.Game
{
    public abstract class CardGame : ICardGame
    {
        public abstract void Play();
    }
}
