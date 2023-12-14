using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace CSpharpLr3ConsoleGame.Entities
{
    internal abstract class Entity
    {
        private string name;
        private string view;
        private int hp;
        private int defense;
        private int maxHp;
        private int spikes;
        private int behaviorIndex;
        private double fragilityMultiplier;
        private int fragilityDuration;
        private double damageMultiplier;
        private int damageMultiplierDuration;
        private double weaknessMultiplier;
        private int weaknessMultiplierDuration;
        private double defenseMultiplier;
        private int defenseMultiplierDuration;
        public int X { get; set; }
        public int Y { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public string View { get { return view; } set { view = value; } }
        public int HP { get { return hp; } set { if (value > maxHp) { hp = maxHp; } else { hp = value; }; } }
        public int Defense { get { return defense; } set { if (value <= 0) { defense = 0; } else { defense = value; } } }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int Spikes { get => spikes; set => spikes = value; }
        public int BehaviorIndex { get => behaviorIndex; set => behaviorIndex = value; }
        public double FragilityMultiplier { get => fragilityMultiplier; set => fragilityMultiplier = value; }
        public int FragilityDuration { get => fragilityDuration; set { if (value <= 0) { FragilityMultiplier = 1; fragilityDuration = 0; } else { fragilityDuration = value; } } }
        public int DefenseMultiplierDuration { get => defenseMultiplierDuration; set { if (value <= 0) { DefenseMultiplier = 1; defenseMultiplierDuration = 0; } else { defenseMultiplierDuration = value; } } }
        public int DamageMultiplierDuration { get => damageMultiplierDuration; set { if (value <= 0) { DamageMultiplier = 1; damageMultiplierDuration = 0; } else { damageMultiplierDuration = value; } } }
        public int WeaknessMultiplierDuration { get => weaknessMultiplierDuration; set { if (value <= 0) { WeaknessMultiplier = 1; weaknessMultiplierDuration = 0; } else { weaknessMultiplierDuration = value; } } }
        public double DamageMultiplier { get => damageMultiplier; set => damageMultiplier = value; }
        public double WeaknessMultiplier { get => weaknessMultiplier; set => weaknessMultiplier = value; }
        public double DefenseMultiplier { get => defenseMultiplier; set => defenseMultiplier = value; }

        public Entity()
        {
        }

        public Entity(int x, int y)
        {
            X = x;
            Y = y;
        }

        public virtual void ShowEnemy()
        {
            var viewArr = View.Split('\n');
            for (int i = 0; i < viewArr.Length; i++)
            {
                Console.SetCursorPosition(X, Y + i);
                Console.WriteLine(viewArr[i]);
            }

            Console.SetCursorPosition(X - 2 + viewArr[0].Length/2, Y - 2);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public virtual int ShowStats()
        {
            ClearStats();
            var info = $"HP: {HP}/{MaxHp}\n\nDef: {Defense}\n\n";
            var infoArr = info.Split('\n');
            for (int i = 0; i < infoArr.Length; i++)
            {
                Console.SetCursorPosition(X + 20, Y + i);
                Console.WriteLine(infoArr[i]);
            }
            return infoArr.Length - 1;
        }

        public void ClearStats()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.SetCursorPosition(X + 20, Y + i);
                Console.WriteLine(Program.GetStringWithLen(' ', 10)); 
            }
        }

        public virtual void NextEnemyTurnDetermination()
        {
            var rnd = new Random();
            BehaviorIndex = rnd.Next(100);
        }

        public virtual void EnemyTurn(Player player)
        {
            
        }

        public void GetDamage(List<int> attacks, Entity damageDealer)
        {
            foreach (int damage in attacks)
            {
                if (Defense > 0)
                {
                    var remainedDamage = damage - Defense;
                    Defense -= damage;
                    if (remainedDamage > 0)
                    {
                        this.HP -= remainedDamage;
                    }
                }
                else
                {
                    this.HP -= damage;
                }

                if (this.spikes > 0)
                {
                    damageDealer.GetReflectedDamage(this.spikes);
                }
            }
            if (!(this is Player))
            {
                this.ShowStats();
            }

        }

        public void GetReflectedDamage(int damage)
        {
            if (Defense > 0)
            {
                var remainedDamage = damage - Defense;
                Defense -= damage;
                if (remainedDamage > 0)
                {
                    this.HP -= remainedDamage;
                }
            }
            else
            {
                this.HP -= damage;
            }
        }

        public void SetDefense(int def)
        {
            this.Defense += def;
        }

        public void ApplyFragility(Entity Enemy, double Multiplier, int Duration)
        {
            Enemy.FragilityMultiplier = Multiplier;
            Enemy.FragilityDuration = Duration;
        }

        public void ApplyWeakness(Entity Enemy, double Multiplier, int Duration)
        {
            Enemy.WeaknessMultiplier = Multiplier;
            Enemy.WeaknessMultiplierDuration = Duration;
        }

        public void ApplyDamageBoost(double Multiplier, int Duration)
        {
            this.damageMultiplier = Multiplier;
            this.DamageMultiplierDuration = Duration;
        }

        public void ApplyDefenseBoost(double Multiplier, int Duration)
        {
            this.DefenseMultiplier = Multiplier;
            this.DefenseMultiplierDuration = Duration;
        }

        public void DurationsDecrease()
        {
            if (this.DefenseMultiplierDuration > 0)
            {
                this.DefenseMultiplierDuration--;
            }
            else
            {
                this.DefenseMultiplier = 1;
            }

            if (this.DamageMultiplierDuration > 0)
            {
                this.DamageMultiplierDuration--;
            }
            else
            {
                this.DamageMultiplier = 1;
            }

            if (this.FragilityDuration > 0)
            {
                this.FragilityDuration--;
            }
            else
            {
                this.FragilityMultiplier = 1;
            }

            if (this.WeaknessMultiplierDuration > 0)
            {
                this.WeaknessMultiplierDuration--;
            }
            else
            {
                this.WeaknessMultiplier = 1;
            }
        }
    }
}
