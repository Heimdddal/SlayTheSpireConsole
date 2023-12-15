using CSpharpLr3ConsoleGame.Cards;
using CSpharpLr3ConsoleGame.Cards.Attacks;
using CSpharpLr3ConsoleGame.Cards.Defenses;
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
        public static string GetStringWithLen(char a, int count)
        {
            string res = "";
            for (int i = 0; i < count; i++)
            {
                res += a;
            }
            return res;
        }


        static void Main(string[] args)
        {
            var rewards = new List<Card> { new EmergencyPistol(), new SniperShot(), new ChainmailUnderCloak() };

            void GetReward(Player player, List<Card> rewards)
            {
                Playground.ClearEnemyScreen();
                ConsoleKeyInfo key;
                Console.SetCursorPosition(Console.WindowWidth / 2, 10);
                Console.WriteLine("Вы победили!!!");
                Console.SetCursorPosition(Console.WindowWidth / 2, 11);
                var rnd = new Random();
                var rewardedCard = rewards[rnd.Next(rewards.Count)];
                player.Deck.Add(rewardedCard);
                Console.WriteLine($"В награду получена \"{rewardedCard.Name}\""); 
                
                do {
                    key = Console.ReadKey(true);
                } while (key.Key != ConsoleKey.Spacebar);

                Playground.ClearEnemyScreen();
            }

            void DrawGreetings()
            {
                ConsoleKeyInfo key;

                do
                {   
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("\tСтрелки вверх и вниз - выбор карты\n\tTab - просмотр активных эффектов на персонаже\n\tSpacebar - закончить ход\n\t(Нажмите spacebar чтобы начать)");
                    key = Console.ReadKey(true);
                } while (key.Key != ConsoleKey.Spacebar);

                Console.Clear();
            }

            void BattleMode(Player player, Entity enemy, Playground playground)
            {
                ConsoleKeyInfo key;

                playground.ShowPlayground();

                playground.gunner.GenerateHand();
                playground.gunner.ShowHand();

                do
                {
                    playground.gunner.CardChoosing(enemy);
                    playground.enemy.EnemyTurn(player);
                    playground.AfterBothTurns();

                }
                while (playground.enemy.HP > 0 && playground.gunner.HP > 0);
                if (player.HP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Вы проиграли");
                }
                GetReward(player, rewards);
            }

            void DrawBorders()
            {
                for (int i = 0; i < Console.WindowWidth; i++)
                {
                    Console.Write('-');
                }
                string leftrightborderspace = new StringBuilder().Insert(0, " ", Console.WindowWidth - 3).ToString();
                leftrightborderspace = leftrightborderspace.Insert(Console.WindowWidth / 3, "|");
                for (int i = 0; i < Console.WindowHeight - 2; i++)
                {
                    if (i == Console.WindowHeight - Console.WindowHeight / 4)
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
            }

            var player = new Player();

            var slime = new Slime();

            var CursedSkull = new Cursed_skull();

            var playground = new Playground(player, slime);

            DrawGreetings();

            BattleMode(player, slime, playground);
            playground.enemy = CursedSkull;
            BattleMode(player, CursedSkull, playground);
        }
    }
}