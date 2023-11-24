﻿using CSpharpLr3ConsoleGame.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards
{
    internal class BandageCard : Card
    {
        private int hpRestore;

        public int HpRestore { get { return hpRestore; } set { hpRestore = value; } }

        public BandageCard()
        {
            hpRestore = 5;
            Name = "Бинт";
            EnergyCost = 1;
            Type = "Bandage";
        }
        public int Heal(Player player)
        {
            return player.HP + HpRestore;
        }
    }
}
