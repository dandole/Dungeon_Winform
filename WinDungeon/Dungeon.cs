using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class Dungeon
    {
        SingletonRandom _random = SingletonRandom.GetInstance();

        List<Monster> _monsters = new List<Monster>();

        internal Player Player { get; }

        internal Dictionary<int, Level> Levels { get; set; } = new Dictionary<int, Level>();

        internal Room Room(DungeonLocation location) { return this.Levels[location.Level].Rooms[location.Point]; }

        internal Room Room(int level, Point point) { return this.Levels[level].Rooms[point]; }

        internal Room Room(int level, int x, int y) { return this.Levels[level].Rooms[new Point(x,y)]; }

        internal Room RoomAt(DungeonLocation currentLocation, eDirection direction)
        {
            switch (direction)
            {
                case eDirection.North:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X, currentLocation.Y - 1)];
                case eDirection.South:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X, currentLocation.Y + 1)];
                case eDirection.East:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X + 1, currentLocation.Y)];
                case eDirection.West:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X - 1, currentLocation.Y)];
                case eDirection.Up:
                    return this.Levels[currentLocation.Level - 1].Rooms[new Point(currentLocation.X, currentLocation.Y)];
                case eDirection.Down:
                    return this.Levels[currentLocation.Level + 1].Rooms[new Point(currentLocation.X, currentLocation.Y)];
                default:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X, currentLocation.Y)];
            }
        }

        internal void Generate(Control parent, int levels, int x, int y)
        {
            foreach(var level in this.Levels.Values)
            {
                level.Clear();
            }

            this.Levels.Clear();

            for (int i = 0; i < levels-1; i++)
            {
                this.Levels.Add(i, new Level(i, x, y));
                this.Levels[i].Render(parent);
            }

            FinishLevels();
        }

        private void FinishLevels()
        {
            throw new NotImplementedException();
        }
    }
}