using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Entities.enemies
{
    internal class Slime : Entity
    {
        private string NextMove { get; set; }

        private ConsoleColor Color = ConsoleColor.DarkGreen;

        public Slime():base()
        {
            var rnd = new Random();
            X = Console.WindowWidth / 3 + 35;
            Y = 5;
            Name = "Слизень";
            MaxHp = rnd.Next(20,30);
            HP = MaxHp;
            Defense = 0;
            base.NextEnemyTurnDetermination();
            View = "     ####  \n" +
                   "   ###  ###  \n" +
                   " ############\n" +
                   "##############";
        }

        public void ShowStatsAndNextMove()
        {
            var dismension = base.ShowStats();

            Console.SetCursorPosition(X + 20, Y + dismension);
            Console.Write("Next move: ");
            Console.SetCursorPosition(X + 20, Y + dismension + 1);
            Console.WriteLine(NextMove);
        }

        public override void ShowEnemy()
        {
            Console.ForegroundColor = Color;

            base.ShowEnemy();

            Console.ResetColor();
        }

        public override void NextEnemyTurnDetermination()
        {
            if (20 >= BehaviorIndex)
            {
                NextMove = "Slime gonna apply fragility on your armor";
            }
            else if (21 <= BehaviorIndex && BehaviorIndex <= 60)
            {
                NextMove = "Slime gonna attack you for 6 damage";
            }
            else if (61 <= BehaviorIndex && BehaviorIndex <= 80)
            {
                NextMove = "Slime gonna attack you for 9 damage";
            }
            else
            {
                NextMove = "Slime gonna apply weakness on you";
            }
            base.NextEnemyTurnDetermination();
            ShowStatsAndNextMove();
        }

        public override void EnemyTurn(Player player)
        {
            if (NextMove == "Slime gonna apply fragility on your armor")
            {
                ApplyFragility(player, 0.5, 2);
            }
            else if (NextMove == "Slime gonna attack you for 6 damage")
            {
                List<int> attacks = new List<int> { 6 };
                player.GetDamage(attacks, this);
            }
            else if (NextMove == "Slime gonna attack you for 9 damage")
            {
                List<int> attacks = new List<int> { 9 };
                player.GetDamage(attacks, this);
            }
            else
            {
                ApplyWeakness(player, 0.5, 2);
            }
        }   
    }
}
