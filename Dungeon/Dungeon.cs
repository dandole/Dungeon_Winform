namespace Dungeon;

using static Constants;

internal class Dungeon
{
    private readonly SingletonRandom _random = SingletonRandom.GetInstance();

    private readonly List<Monster> _monsters = [];

    internal Player Player { get; set; }

    internal Dictionary<int, Level> Levels { get; set; } = [];

    internal Room Room(DungeonLocation location) { return Levels[location.Level].Rooms[location.Point]; }

    internal Room Room(int level, Point point) { return Levels[level].Rooms[point]; }

    internal Room Room(int level, int x, int y) { return Levels[level].Rooms[new Point(x,y)]; }

    internal Room RoomAt(DungeonLocation currentLocation, Direction direction)
    {
        return direction switch
        {
            Direction.North => Levels[currentLocation.Level].Rooms[new Point(currentLocation.X, currentLocation.Y - 1)],
            Direction.South => Levels[currentLocation.Level].Rooms[new Point(currentLocation.X, currentLocation.Y + 1)],
            Direction.East => Levels[currentLocation.Level].Rooms[new Point(currentLocation.X + 1, currentLocation.Y)],
            Direction.West => Levels[currentLocation.Level].Rooms[new Point(currentLocation.X - 1, currentLocation.Y)],
            Direction.Up => Levels[currentLocation.Level - 1].Rooms[new Point(currentLocation.X, currentLocation.Y)],
            Direction.Down => Levels[currentLocation.Level + 1].Rooms[new Point(currentLocation.X, currentLocation.Y)],
            _ => Levels[currentLocation.Level].Rooms[currentLocation.Point],
        };
    }

    internal void Generate(int levels, int x, int y)
    {
        foreach(var level in Levels.Values)
        {
            level.Clear();
        }

        Levels.Clear();

        for (int i = 0; i < levels; i++)
        {
            Levels.Add(i, new Level(i, x, y));
        }

        FinishLevels();
    }

    internal void MoveMonsters()
    {
        foreach(var monster in _monsters)
        {
            if (monster.Location.Level == Player.Location.Level)
                monster.Move(this);
        }
    }

    internal void MovePlayer()
    {
        Player.Move(this);
        CheckForEncounter();
    }

    private void CheckForEncounter()
    {
        if (Room(Player.Location).Monster)
        {
            foreach(var monster in _monsters.Where(x => x.Location == Player.Location))
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
                Player = new Player(new DungeonLocation() { Level = level.Floor, X = playerPtr.X, Y = playerPtr.Y });
                level.Rooms[playerPtr].Player = true;
            }

            if (level.Floor < this.Levels.Count - 1)
            {
                Point roomPtr = level.Rooms.Keys.ElementAt<Point>(_random.Rnd.Next(0, level.Rooms.Count));
                level.Rooms[roomPtr].Down = true;
                Room(level.Floor + 1, roomPtr).Up = true;
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