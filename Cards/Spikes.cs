using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards
{
    internal class Spikes : Card
    {
        private int spkiesDamage;        
        public int SpikesDamage { get { return spkiesDamage; } set { spkiesDamage = value; } }

        public Spikes()
        {
            Name = "Лезвия в рукавах";
            EnergyCost = 3;
            Type = "Spikes";

        }

        public int setSpikes()
        {
            return SpikesDamage;
        }
    }
}
