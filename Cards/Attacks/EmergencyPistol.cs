using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards.Attacks
{
    internal class EmergencyPistol : AtkCard
    {
        public EmergencyPistol() : base()
        {
            Name = "Скрытый пистолет";
            EnergyCost = 0;
            Atk = 3;
            AtkCount = 1;
            Description = $"Вы достаете однозарядный пистолет из-за пояса и наносите 3 урона врагу";
        }
    }
}
