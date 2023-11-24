using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.SetCursorPosition(Console.WindowWidth/3 + 5, (Console.WindowHeight - Console.WindowHeight/4) + 4);
            Console.WriteLine($"HP: {gunner.HP}/{gunner.MaxHp}\t\tDef: {gunner.Defense}\t\tEnergy: {gunner.Energy}/3");
        }
    }
}
