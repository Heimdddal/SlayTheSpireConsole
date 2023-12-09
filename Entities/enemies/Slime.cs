using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Entities.enemies
{
    internal class Slime : Entities.Entity
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
            var info = $"HP: {HP}/{MaxHp}\n\nDef: {Defense}\n\nСледующий ход:\n {Atk}";
            var infoArr = info.Split('\n');
            for (int i = 0; i < infoArr.Length; i++)
            {
                Console.SetCursorPosition(X + 20, Y + i);
                Console.WriteLine(infoArr[i]);
            }
            
        }

        public override void ShowEnemy()
        {
            Console.ForegroundColor = Color;

            base.ShowEnemy();

            Console.ResetColor();
        }

        public override void EnemyTurn()
        {
            
        }

    }
}
