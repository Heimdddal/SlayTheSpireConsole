using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards.Attacks
{
    internal class SniperShot : AtkCard
    {
        public SniperShot() : base()
        {
            Name = "Прицельный выстрел";
            EnergyCost = 2;
            Atk = 9;
            AtkCount = 1;
            Description = $"Вы делаете прицельный выстрел и наносите 9 урона врагу";
        }
    }
}
