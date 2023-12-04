using CSpharpLr3ConsoleGame.Entities;
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
            Name = "Лезвия на одежде";
            EnergyCost = 3;
            SpikesDamage = 3;
            Type = "Spikes";
            Description = "В некоторые элементы вашей одежды вшиты лезвия, которые ранят противника при его атаке. Увеличивает показатель шипов на 3 до конца боя";
        }

        public void SetSpikes(Entity entity)
        {
            entity.Spikes = SpikesDamage;
        }
    }
}
