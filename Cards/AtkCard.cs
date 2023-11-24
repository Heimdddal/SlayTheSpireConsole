using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards
{
    internal abstract class AtkCard : Card
    {
        private int atk;
        private int atkCount;

        public int Atk { get { return atk; } set { atk = value; } }
        public int AtkCount { get { return atkCount; } set { atkCount = value; } }

        public int DealDamage(int DamageMultiplier, int WeaknessMultiplier)
        {
            return ((atk * DamageMultiplier) * WeaknessMultiplier) * atkCount;
        }

        public AtkCard()
        {
            this.Type = "Attack";
        }
    }
}
