using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using CSpharpLr3ConsoleGame.Cards;
using CSpharpLr3ConsoleGame.Cards.Attacks;
using CSpharpLr3ConsoleGame.Cards.Defenses;

namespace CSpharpLr3ConsoleGame.Entities
{
    internal class Player : Entity
    {
        private int energy;
        private int damageMultiplier;
        private int weaknessMultiplier;
        private int fragilityMultiplier;
        private int defenseMultiplier;
        private int choosenCard;
        private List<Card> deck;
        private List<Card> playingDeck;
        private List<Card> hand;
        private List<Card> discardDeck;

        public int DamageMultiplier { get => damageMultiplier; set => damageMultiplier = value; }
        public int WeaknessMultiplier { get => weaknessMultiplier; set => weaknessMultiplier = value; }
        public int Energy { get => energy; set => energy = value; }
        public int FragilityMultiplier { get => fragilityMultiplier; set => fragilityMultiplier = value; }
        public int DefenseMultiplier { get => defenseMultiplier; set => defenseMultiplier = value; }
        public List<Card> Deck { get => deck; set => deck = value; }
        public List<Card> Hand { get => hand; set => hand = value; }
        public List<Card> DiscardDeck { get => discardDeck; set => discardDeck = value; }
        internal List<Card> PlayingDeck { get => playingDeck; set => playingDeck = value; }
        public int ChoosenCard { get => choosenCard; set { if (value < 0) { choosenCard = hand.Count - 1; } else if (value > hand.Count - 1) { choosenCard = 0; } else { choosenCard = value; } } }

        public void ClearDescription()
        {
            for (int i = 0; i < Console.WindowHeight - Console.WindowHeight / 4 - 12; i++)
            {
                Console.SetCursorPosition(2, 13 + i);
                Console.WriteLine(Program.GetStringWithLen(' ', Console.WindowWidth / 3 - 2));
            }
        }

        public void ShowPlayerStats()
        {
            Console.SetCursorPosition(Console.WindowWidth / 3 + 5, (Console.WindowHeight - Console.WindowHeight / 4) + 4);
            Console.WriteLine($"HP: {this.HP}/{this.MaxHp}\t\tDef: {this.Defense}\t\tEnergy: {this.Energy}/3");
        }

        public void ChoosingMarkerChange()
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == ChoosenCard)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 3 - 4, 2 + (i * 3));
                    Console.Write("<=");
                }
                else
                {
                    Console.SetCursorPosition(Console.WindowWidth / 3 - 4, 2 + (i * 3));
                    Console.Write("  ");
                }
            }

            
        }

        public void GenerateHand()
        {
            var rnd = new Random();
            if (playingDeck.Count < 3)
            {
                Hand = playingDeck;
                playingDeck.Clear();
                playingDeck = discardDeck;
                discardDeck.Clear();
                for (int i = 0; i < 3 - Hand.Count; i++)
                {
                    var index = rnd.Next(PlayingDeck.Count);
                    Hand.Add(PlayingDeck[index]);
                    playingDeck.Remove(playingDeck[index]);
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    var index = rnd.Next(PlayingDeck.Count);
                    Hand.Add(PlayingDeck[index]);
                    playingDeck.Remove(playingDeck[index]);
                }
            }
            
        }

        public void ClearHand()
        {
            
            for (int i = 0; i < 11; i++)
            {
                Console.SetCursorPosition(2, 1 + i);
                Console.WriteLine(Program.GetStringWithLen(' ', Console.WindowWidth / 3 - 6));
            }
            for (int i = 0; i < 12; i++)
            {
                Console.SetCursorPosition(2, 12 + i);
                Console.WriteLine(Program.GetStringWithLen(' ', Console.WindowWidth / 3 - 6));
            }
        }

        public void ShowHand()
        {
            ClearHand();

            for (int i = 0; i < Hand.Count; i++)
            {
                Console.SetCursorPosition(2, 1 + (i * 3));
                Console.WriteLine(Program.GetStringWithLen('-', Console.WindowWidth/3 - 6));

                Console.SetCursorPosition(2, 2 + (i * 3));
                Console.WriteLine('|' + Hand[i].Name + Program.GetStringWithLen(' ', Console.WindowWidth / 3 - Hand[i].Name.Length - 8 - 2) + $"{this.Hand[i].EnergyCost} " + '|');

                Console.SetCursorPosition(2, 3 + (i * 3));
                Console.WriteLine(Program.GetStringWithLen('-', Console.WindowWidth / 3 - 6));
            }
            Console.SetCursorPosition(2, 11);
            Console.WriteLine(Program.GetStringWithLen('-', Console.WindowWidth / 3 - 2));

            Console.SetCursorPosition(2, 12);
            Console.WriteLine("Описание карты");

            ChoosingMarkerChange();
            ShowDescription();
        }

        public void ShowDescription()
        {
            int rowCounter = 0;
            string currentRow = "";
            var descriptionWords = Hand[ChoosenCard].Description.Split(' ');
            Console.SetCursorPosition(2, 13 + rowCounter);
            for (int i = 0; i < descriptionWords.Length; i++)
            {
                
                if ((currentRow.Length + descriptionWords[i].Length) >= Console.WindowWidth / 3 - 4)
                {
                    rowCounter++;
                    Console.SetCursorPosition(2, 13 + rowCounter);
                    currentRow = descriptionWords[i] + ' ';
                    Console.Write(descriptionWords[i] + ' ');
                }
                else
                {
                    currentRow += descriptionWords[i] + ' ';
                    Console.Write(descriptionWords[i] + ' ');
                }
            }
        }

        public void CardChoosing(Entity enemy)
        {
            ConsoleKeyInfo key;
            ShowPlayerStats();
            do
            {
                key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        ChoosenCard = ChoosenCard - 1;
                        ClearDescription();
                        ShowDescription();
                        ChoosingMarkerChange();
                        break;
                    case ConsoleKey.DownArrow:
                        ChoosenCard = ChoosenCard + 1;
                        ClearDescription();
                        ShowDescription();
                        ChoosingMarkerChange();
                        break;
                    case ConsoleKey.Enter:
                        if (this.Hand[ChoosenCard].EnergyCost <= this.energy)
                        {
                            PlayerTurn(enemy);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    case ConsoleKey.Spacebar:
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        public void PlayerTurn(Entity enemy)
        {
            switch (this.Hand[this.ChoosenCard].Type)
            {
                case "Bandage":
                    BandageCard bandage = this.Hand[this.ChoosenCard] as BandageCard;
                    if (bandage != null)
                    {
                        bandage.Heal(this);
                    }
                    else
                    {
                        throw new Exception("Похоже бинты сломали. Чини.");
                    }
                    break;
                case "Spikes":
                    Spikes spikesCard = this.Hand[this.ChoosenCard] as Spikes;
                    if (spikesCard != null)
                    {
                        spikesCard.SetSpikes(this);
                    }
                    else
                    {
                        throw new Exception("Похоже шипы сломались. Чини.");
                    }
                    break;
                case "Defense":
                    var defense = this.Hand[this.ChoosenCard].GetDefense(this.DefenseMultiplier, this.FragilityMultiplier);
                    this.SetDefense(defense);
                    break;
                case "Attack":
                    var damage = this.Hand[this.ChoosenCard].DealDamage(this.DamageMultiplier, this.WeaknessMultiplier);
                    enemy.GetDamage(damage, this);
                    break;
                default:
                    throw new Exception("Card type error");
            }
            this.energy -= this.Hand[this.ChoosenCard].EnergyCost;
            this.Hand.Remove(this.Hand[this.ChoosenCard]);
            this.ChoosenCard = 0;
            if (Hand.Count == 0)
            {
                Console.WriteLine("Turn Ends here");
                return;
            }
            else
            {
                ShowHand();
                CardChoosing(enemy);
            }
        }

        public Player()
        {
            Deck = new List<Card>();
            Hand = new List<Card>();
            PlayingDeck = new List<Card>();
            DiscardDeck = new List<Card>();
            Energy = 3;
            MaxHp = 60;
            Defense = 0;
            HP = 60;
            Name = "Стрелок";
            ChoosenCard = 0;
            damageMultiplier = 1;
            WeaknessMultiplier = 1;
            FragilityMultiplier = 1;
            DefenseMultiplier = 1;
            Deck.Add(new Shoot());
            Deck.Add(new Shoot());
            Deck.Add(new CoverWithCloak());
            Deck.Add(new CoverWithCloak());
            Deck.Add(new BandageCard());
            Deck.Add(new HeavyFire());
            playingDeck = deck;
        }
    }
}
