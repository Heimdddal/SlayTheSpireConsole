using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Entities.enemies
{
    internal class Slime : Entity
    {
        private int Atk { get; set; }

        private ConsoleColor Color = ConsoleColor.DarkGreen;

        public Slime():base()
        {
            var rnd = new Random();
            X = Console.WindowWidth / 3 + 35;
            Y = 5;
            Atk = rnd.Next(3,9); 
            Name = "Слизень";
            MaxHp = rnd.Next(20,30);
            HP = MaxHp;
            Defense = 0;
            View = "     ####  \n" +
                   "   ###  ###  \n" +
                   " ############\n" +
                   "##############";
        }

        public override void ShowStats()
        {
            base.ShowStats();
            
        }

        public override void ShowEnemy()
        {
            Console.ForegroundColor = Color;

            base.ShowEnemy();

            Console.ResetColor();
        }

        public override void EnemyTurn()
        {
            if (20 >= BehaviorIndex)
            {

            }
            else if (21 <= BehaviorIndex && BehaviorIndex <= 60)
            {
                
            }
            else if (61 <= BehaviorIndex && BehaviorIndex <= 80)
            { 
                
            }
            else
            {
                
            }
            base.EnemyTurn();
        }

    }
}
