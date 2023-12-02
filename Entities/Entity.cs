using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Entities
{
    internal abstract class Entity
    {
        private string name;
        private string view;
        private int hp;
        private int defense;
        private int maxHp;
        private int Spikes;
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public string View { get { return view; } set { view = value; } }
        public int HP { get { return hp; } set { if (value > maxHp) { hp = maxHp; } else { hp = value; }; } }
        public int Defense { get { return defense; } set { if (value < 0) { defense = 0; } else { defense = value; } } }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int Spikes1 { get => Spikes; set => Spikes = value; }

        public Entity()
        {
        }

        public Entity(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void ShowEnemy()
        {
            var viewArr = View.Split('\n');
            for (int i = 0; i < viewArr.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.WriteLine(viewArr[i]);
            }

            Console.SetCursorPosition(X - 2 + viewArr[0].Length/2, Y - 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public virtual void ShowStats()
        {

        }

        public void GetDamage(int damage, Entity damageDealer)
        {
            if (defense > 0)
            {
                var remainedDamage = damage -  defense;
                defense -= damage;
                if (remainedDamage <= 0)
                {

                }
                else
                {
                    this.HP -= remainedDamage;
                }
            }
            else
            {
                this.HP -= damage;
            }

            if (this.Spikes > 0)
            {
                
            }
        }

        public void ReflectDamage(int damage)
        {

        }
    }
}
