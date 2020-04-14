using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class Monster
    {
        SingletonRandom _random = SingletonRandom.GetInstance();

        internal string MonsterType { get; set; }
        internal int HitPoints { get; set; }
        internal int HP { get; set; }

        string _hitDice = "";
        internal string HitDice 
        { 
            get => _hitDice;
            set 
            { 
                _hitDice = value;
                ParseHitDice();
            }
        }

        internal DungeonLocation Location { get; set; } = new DungeonLocation();
        internal int Attacks { get; set; }
        internal string Damage { get; set; }
        internal int ArmorClass { get; set; }


        internal Monster(string monsterType, string hitDice, int attacks, string damage, int armorClass, DungeonLocation location)
        {
            this.MonsterType = monsterType;
            this.HitDice = hitDice;
            this.Attacks = attacks;
            this.Damage = damage;
            this.ArmorClass = armorClass;
            this.Location = location;
        }

        internal void Move(Dungeon dungeon)
        {
            eDirection direction;
            while (true)
            {
                direction = (eDirection)_random.Rnd.Next(1, 7);
                if (dungeon.Room(this.Location).CanMove(direction))
                    break;
            }

            dungeon.Room(this.Location).Monster = false;
            this.Location.Move(direction);
            dungeon.Room(this.Location).Monster = true;
        }

        void ParseHitDice()
        {
            if (_hitDice.Contains("HP"))
            {
                string HD = _hitDice.Replace("HP", "").Trim();
                this.HitPoints = _random.Rnd.Next(Convert.ToInt32(HD.Split('-')[0]), Convert.ToInt32(HD.Split('-')[1]) + 1);
            }
            else
            {
                if (_hitDice.Contains("+"))
                {
                    this.HitPoints = _random.Rnd.Next(Convert.ToInt32(_hitDice.Split('+')[0]) + Convert.ToInt32(_hitDice.Split('+')[1]), (Convert.ToInt32(_hitDice.Split('+')[0]) * 8) + Convert.ToInt32(_hitDice.Split('+')[1] + 1));
                }
                else
                {
                    this.HitPoints = _random.Rnd.Next(Convert.ToInt32(_hitDice), (Convert.ToInt32(_hitDice) * 8) + 1);
                }
            }

            this.HP = this.HitPoints;
        }
    }
}
