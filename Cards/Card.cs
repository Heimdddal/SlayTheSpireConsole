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

        public string SplitStringIfLonger(int len)
        {
            var result = new List<string>();//TODO метод был для строкового типа result, но тогда не получится сделать нормальнй перенос. Стоит сделать result листом и возвращать сразу листом. Переделай для списика
            var words = description.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if ((result.Length + words[i].Length) > len)
                {
                    result += '\n' + words[i] + ' ';
                }
                else
                {
                    result += words[i] + ' ';
                }
            }
            return result;
        }
    }
}
