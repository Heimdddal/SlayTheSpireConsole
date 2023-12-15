using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSpharpLr3ConsoleGame.Cards;
using CSpharpLr3ConsoleGame.Entities;

namespace CSpharpLr3ConsoleGame
{
    internal class Playground
    {
        public Entity enemy;

        public Player gunner;

        public Playground(Player player, Entity monster)
        {
            gunner = player;
            enemy = monster;
        }

        public void ShowPlayground()
        {
            gunner.ShowPlayerStats();
            enemy.ShowEnemy();
            enemy.ShowStats();
            enemy.NextEnemyTurnDetermination();
        }

        public void AfterBothTurns()
        {
            gunner.ShowPlayerStats();
            enemy.ShowStats();
            enemy.NextEnemyTurnDetermination();
            gunner.DurationsDecrease();
            enemy.DurationsDecrease();
            gunner.Defense = 0;
            enemy.Defense = 0;
            gunner.Energy = 3;
            gunner.GenerateHand();
            gunner.ShowHand();
        }

        public static void ClearEnemyScreen()
        {
            for (int i = 1; i < (Console.WindowHeight - Console.WindowHeight / 4) - 1; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth/3 + 2, i);
                Console.WriteLine(Program.GetStringWithLen(' ', (Console.WindowWidth/3 * 2) - 3));
            }
        }
    }
}
