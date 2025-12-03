using System;
using System.Drawing;

using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class DungeonLocation
    {
        internal int Level { get; set; }
        internal int X { get; set; }
        internal int Y { get; set; }

        internal Point Point { get => new Point(this.X, this.Y); }

        internal void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    this.Y--;
                    break;
                case Direction.South:
                    this.Y++;
                    break;
                case Direction.East:
                    this.X++;
                    break;
                case Direction.West:
                    this.X--;
                    break;
                case Direction.Up:
                    this.Level--;
                    break;
                case Direction.Down:
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
