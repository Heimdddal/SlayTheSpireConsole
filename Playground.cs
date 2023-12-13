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
    }
}
