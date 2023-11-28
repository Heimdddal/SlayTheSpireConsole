using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards.Attacks
{
    internal class Shoot : AtkCard
    {
        public Shoot() : base()
        {
            Name = "Выстрел";
            EnergyCost = 1;
            Atk = 5;
            AtkCount = 1;
            Description = $"Вы делаете выстрел, который наносит 5 урона врагу";
        }
    }
}
