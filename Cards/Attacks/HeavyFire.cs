using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards.Attacks
{
    internal class HeavyFire : AtkCard
    {
        public HeavyFire() : base()
        {
            Name = "Шквальный огонь";
            EnergyCost = 2;
            Atk = 3;
            AtkCount = 3;
        }
    }
}
