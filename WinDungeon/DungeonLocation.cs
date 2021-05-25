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

        internal Point Point { get => new Point(this.X, this.Y); }

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

        public static bool operator ==(DungeonLocation loc1, DungeonLocation loc2)
        {
            if (loc1 is null)
            {
                if (loc2 is null)
                {
                    return true;
                }

                return false;
            }

            return loc1.Equals(loc2);
        }
        public static bool operator !=(DungeonLocation loc1, DungeonLocation loc2) => !(loc1 == loc2);
        public override bool Equals(object obj) => this.Equals(obj as DungeonLocation);

        public bool Equals(DungeonLocation d)
        {
            if (d is null)
            {
                return false;
            }

            if (Object.ReferenceEquals(this, d))
            {
                return true;
            }

            if (this.GetType() != d.GetType())
            {
                return false;
            }

            return (Level == d.Level) && (X == d.X) && (Y == d.Y);
        }

        public override int GetHashCode() => (this.Level, this.X, this.Y).GetHashCode();
    }
}
