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

        public override List<int> DealDamage(int DamageMultiplier, int WeaknessMultiplier)
        {
            List<int> attacks = new List<int>();
            for (int i = 0; i < atkCount; i++)
            {
                attacks.Add(((atk * DamageMultiplier) * WeaknessMultiplier));
            }
            return attacks;
        }

        public AtkCard()
        {
            this.Type = "Attack";
        }
    }
}
