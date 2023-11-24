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
        private string unfolded;
        private string folded;
        private int energyCost;
        private string type;

        public string Name { get { return name; } set { name = value; } }
        public string Unfolded { get { return unfolded; } set { unfolded = value; } }
        public int EnergyCost { get { return energyCost; } set { energyCost = value; } }
        public string Folded { get { return folded; } set { folded = value; } }
        public string Type { get { return type; } set { type = value; } }
    }
}
