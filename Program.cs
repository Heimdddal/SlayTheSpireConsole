using CSpharpLr3ConsoleGame.Entities;
using CSpharpLr3ConsoleGame.Entities.enemies;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CSpharpLr3ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void BattleMode(Player player, Entity enemy)
            {
                var playground = new Playground(player, enemy);

                playground.ShowPlayground();

                playground.enemy.ShowEnemy();
                playground.enemy.ShowStats();

                do
                {

                }
                while (playground.enemy.HP > 0 && playground.gunner.HP > 0);
            }

            string GetStringWithLen(char a, int count)
            {
                string res = "";
                for (int i = 0; i < count; i++)
                {
                    res += a;
                }
                return res;
            }
            var player = new Player();

            var slime = new Slime();

            var playground = new Playground(player, slime);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }
            string leftrightborderspace = new StringBuilder().Insert(0, " ", Console.WindowWidth-3).ToString();
            leftrightborderspace = leftrightborderspace.Insert(Console.WindowWidth / 3, "|");
            for (int i = 0; i < Console.WindowHeight - 2; i++)
            {
                if (i == Console.WindowHeight - Console.WindowHeight/4)
                {
                    Console.WriteLine("|" + GetStringWithLen('-', Console.WindowWidth - 2) + "|");
                }
                else
                {
                    Console.WriteLine("|" + leftrightborderspace + "|");
                }
            }
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write('-');
            }

            BattleMode(player, slime);
        }
    }
}