using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class Dungeon
    {
        private readonly SingletonRandom _random = SingletonRandom.GetInstance();

        private readonly List<Monster> _monsters = new List<Monster>();

        internal Player Player { get; set; }

        internal Dictionary<int, Level> Levels { get; set; } = new Dictionary<int, Level>();

        internal Room Room(DungeonLocation location) { return this.Levels[location.Level].Rooms[location.Point]; }

        internal Room Room(int level, Point point) { return this.Levels[level].Rooms[point]; }

        internal Room Room(int level, int x, int y) { return this.Levels[level].Rooms[new Point(x,y)]; }

        internal Room RoomAt(DungeonLocation currentLocation, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X, currentLocation.Y - 1)];
                case Direction.South:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X, currentLocation.Y + 1)];
                case Direction.East:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X + 1, currentLocation.Y)];
                case Direction.West:
                    return this.Levels[currentLocation.Level].Rooms[new Point(currentLocation.X - 1, currentLocation.Y)];
                case Direction.Up:
                    return this.Levels[currentLocation.Level - 1].Rooms[new Point(currentLocation.X, currentLocation.Y)];
                case Direction.Down:
                    return this.Levels[currentLocation.Level + 1].Rooms[new Point(currentLocation.X, currentLocation.Y)];
                default:
                    return this.Levels[currentLocation.Level].Rooms[currentLocation.Point];
            }
        }

        internal void Generate(Control parent, int levels, int x, int y)
        {
            foreach(var level in this.Levels.Values)
            {
                level.Clear();
            }

            this.Levels.Clear();

            for (int i = 0; i < levels; i++)
            {
                this.Levels.Add(i, new Level(i, x, y));
                this.Levels[i].Render(parent);
            }

            FinishLevels();
        }

        internal void MoveMonsters()
        {
            foreach(var monster in _monsters)
            {
                if (monster.Location.Level == this.Player.Location.Level)
                    monster.Move(this);
            }
        }

        internal void MovePlayer()
        {
            this.Player.Move(this);
            CheckForEncounter();
        }

        private void CheckForEncounter()
        {
            if (this.Room(this.Player.Location).Monster)
            {
                foreach(var monster in _monsters.Where(x => x.Location == this.Player.Location))
                {

                }
            }
        }

        private void FinishLevels()
        {
            Point playerPtr;

            foreach(var level in this.Levels.Values)
            {
                if (level.Floor == 0)
                {
                    playerPtr = level.Rooms.Keys.ElementAt<Point>(_random.Rnd.Next(0, level.Rooms.Count));
                    this.Player = new Player(new DungeonLocation() { Level = level.Floor, X = playerPtr.X, Y = playerPtr.Y });
                    level.Rooms[playerPtr].Player = true;
                }

                if (level.Floor < this.Levels.Count - 1)
                {
                    Point roomPtr = level.Rooms.Keys.ElementAt<Point>(_random.Rnd.Next(0, level.Rooms.Count));
                    level.Rooms[roomPtr].Down = true;
                    this.Room(level.Floor + 1, roomPtr).Up = true;
                }

                if (level.Floor > 0)
                {
                    while(true)
                    {
                        Room room = level.Rooms[level.Rooms.Keys.ElementAt<Point>(_random.Rnd.Next(0, level.Rooms.Count))];
                        if (room.Up==false && room.Down==false && room.Paths == 1)
                        {
                            room.Lair = true;
                            break;
                        }
                    }
                }

                int monsterCount = _random.Rnd.Next(0, level.Rooms.Count / 7);
                for (int i = 1; i < monsterCount; i++)
                {
                    while (true)
                    {
                        Room room = level.Rooms[level.Rooms.Keys.ElementAt<Point>(_random.Rnd.Next(0, level.Rooms.Count))];
                        if (room.Monster == false)
                        {
                            room.Monster = true;
                            if (level.Floor < 3)
                            {
                                _monsters.Add(new Monster("Goblin", "1-7 HP", 1, "1-6", 6, new DungeonLocation() { Level = level.Floor, X = room.Position.X, Y = room.Position.Y }));
                            }
                            else
                            {
                                _monsters.Add(new Monster("Orc", "1", 1, "1-8", 6, new DungeonLocation() { Level = level.Floor, X = room.Position.X, Y = room.Position.Y }));
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}