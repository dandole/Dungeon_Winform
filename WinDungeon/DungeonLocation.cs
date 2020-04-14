using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinDungeon.Constants;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing;

namespace WinDungeon
{
    internal class DungeonLocation
    {
        internal int Level { get; set; }
        internal int X { get; set; }
        internal int Y { get; set; }

        internal Point Point { get => new Point(this.X,this.Y); }
        
        internal void Move(eDirection direction)
        {
            switch (direction)
            {
                case eDirection.North: 
                    this.Y--;
                    break;
                case eDirection.South:
                    this.Y++;
                    break;
                case eDirection.East:
                    this.X++;
                    break;
                case eDirection.West:
                    this.X--;
                    break;
                case eDirection.Up:
                    this.Level--;
                    break;
                case eDirection.Down:
                    this.Level++;
                    break;
            }
        }

        public static bool operator ==(DungeonLocation loc1, DungeonLocation loc2) => loc1.Level == loc2.Level && loc1.X == loc2.X && loc1.Y == loc2.Y;
        public static bool operator !=(DungeonLocation loc1, DungeonLocation loc2) => !(loc1.Level == loc2.Level && loc1.X == loc2.X && loc1.Y == loc2.Y);
    }
}
