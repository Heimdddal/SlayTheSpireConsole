using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void ConvertDescriptions(int topIndex, int leftIndex, string s)
        {
            var sArr = s.Split('\n');
            for (int i = topIndex; i < sArr.Length; i++)
            {
                Console.SetCursorPosition(leftIndex, i);
                Console.WriteLine(sArr[i]);
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
            damageMultiplier = 1;
            WeaknessMultiplier = 1;
            FragilityMultiplier = 1;
            DefenseMultiplier = 1;
            Deck.Add(new Shoot());
            Deck.Add(new Shoot());
            Deck.Add(new CoverWithCloak());
            Deck.Add(new CoverWithCloak());
            Deck.Add(new BandageCard());
            Deck.Add(new CoverWithCloak());
            playingDeck = deck;
        }
    }
}
