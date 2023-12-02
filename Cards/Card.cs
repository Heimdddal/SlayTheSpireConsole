using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards
{
    internal abstract class Card
    {
        private string name;
        private int energyCost;
        private string type;
        private string description;

        public string Name { get { return name; } set { name = value; } }
        public int EnergyCost { get { return energyCost; } set { energyCost = value; } }
        public string Type { get { return type; } set { type = value; } }
        public string Description { get => description; set => description = value; }

        public virtual int Heal() { return 0; }
        public virtual int DealDamage(int DamageMultiplier, int WeaknessMultiplier) { return 0; }
        public virtual int SetSpikes() { return 0; }
        public virtual int SetDefense(int DefMultiplier, int FragilityMultiplier) { return 0; }

    }
}
