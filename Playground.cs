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
            Console.SetCursorPosition(Console.WindowWidth/3 + 5, (Console.WindowHeight - Console.WindowHeight/4) + 4);
            Console.WriteLine($"HP: {gunner.HP}/{gunner.MaxHp}\t\tDef: {gunner.Defense}\t\tEnergy: {gunner.Energy}/3");
        }

        public void PlayerTurn()
        {
            switch (gunner.Hand[gunner.ChoosenCard].Type)
            {
                case "Bandage":
                    BandageCard bandage =  gunner.Hand[gunner.ChoosenCard] as BandageCard;
                    if(bandage != null)
                    {
                        bandage.Heal(gunner);
                    }
                    else
                    {
                        throw new Exception("Похоже бинты сломали. Чини.");
                    }
                    break;
                case "Spikes":
                    Spikes spikesCard = gunner.Hand[gunner.ChoosenCard] as Spikes;
                    if (spikesCard != null)
                    {
                        spikesCard.SetSpikes(gunner);
                    }
                    else
                    {
                        throw new Exception("Похоже шипы сломались. Чини.");
                    }
                    break;
                case "Defense":
                    var defense = gunner.Hand[gunner.ChoosenCard].GetDefense(gunner.DefenseMultiplier, gunner.FragilityMultiplier);
                    gunner.SetDefense(defense);
                    break;
                case "Attack":
                    var damage = gunner.Hand[gunner.ChoosenCard].DealDamage(gunner.DamageMultiplier, gunner.WeaknessMultiplier);
                    enemy.GetDamage(damage, gunner);
                    break;
                default:
                    break;
            }
        }
    }
}
