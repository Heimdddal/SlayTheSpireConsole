﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Cards.Defenses
{
    internal class ChainmailUnderCloak : DefenseCard
    {
        public ChainmailUnderCloak()
        {
            Name = "Кольчуга под плащом";
            EnergyCost = 2;
            Def = 9;
            Description = "У вас под плащом кольчуга, которая защитит от большинства легкого оружия. Дает 9 защиты.";
        }
    }
}
