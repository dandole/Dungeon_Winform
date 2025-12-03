namespace Dungeon;

using static Constants;

internal class Room
{
    const int cXOffset = 100;
    const int cYOffset = 100;
    const int cRoomSize = 20;
    const int cHallwaySize = 8;
    const int cLairSize = 8;
    const int cMonsterSize = 8;
    const int cPlayerSize = 8;

    private readonly SingletonRandom _random = SingletonRandom.GetInstance();

    internal Point Position { get; set; }
    internal bool North { get; set; }
    internal bool South { get; set; }
    internal bool East { get; set; }
    internal bool West { get; set; }
    internal bool Connected { get; set; } = false;

    internal int Visits { get; set; } = 0;
    internal bool Mapped { get; set; }
    internal bool Lair { get; set; }

    internal bool Up { get; set; }

    internal bool Down { get; set; }

    internal bool Monster { get; set; }

    bool _player;
    internal bool Player
    {
        get => _player;
        set
        {
            _player = value;
            if (value)
            {
                if (Mapped == false)
                {
                    Mapped = true;
                }

                Visits += 1;
            }
        }
    }

    internal Room(Point position, int xDimension, int yDimension)
    {
        Position = position;
        while (!North & !South & !East & !West)
        {
            North = Position.Y != 0 && _random.Rnd.Next(1, 101) <= 25;
            South = Position.Y != yDimension && _random.Rnd.Next(1, 101) <= 25;
            East = Position.X != xDimension && _random.Rnd.Next(1, 101) <= 25;
            West = Position.X != 0 && _random.Rnd.Next(1, 101) <= 25;
        }
    }

    internal bool CanMove(Direction direction)
    {
        return direction switch
        {
            Direction.North => North,
            Direction.South => South,
            Direction.East => East,
            Direction.West => West,
            Direction.Up => Up,
            Direction.Down => Down,
            _ => false,
        };
    }

    internal int Paths
    {
        get
        {
            return new bool[] { North, South, East, West, Up, Down }.Count(x => x);
        }
    }

    internal void Draw(Graphics g)
    {
        if (!Mapped)
            return;
        // Calculate position
        int x = cXOffset + (2 * cRoomSize * Position.X);
        int y = cYOffset + (2 * cRoomSize * Position.Y);

        // Draw room rectangle
        g.FillRectangle(Brushes.DarkKhaki, x, y, cRoomSize, cRoomSize);
        g.DrawRectangle(Pens.Black, x, y, cRoomSize, cRoomSize);

        // Draw hallways if present
        if (North)
            g.FillRectangle(Brushes.Gray, x + (cRoomSize - cHallwaySize) / 2, y - cRoomSize / 2, cHallwaySize, cRoomSize / 2);
        if (South)
            g.FillRectangle(Brushes.Gray, x + (cRoomSize - cHallwaySize) / 2, y + cRoomSize, cHallwaySize, cRoomSize / 2);
        if (East)
            g.FillRectangle(Brushes.Gray, x + cRoomSize, y + (cRoomSize - cHallwaySize) / 2, cRoomSize / 2, cHallwaySize);
        if (West)
            g.FillRectangle(Brushes.Gray, x - cRoomSize / 2, y + (cRoomSize - cHallwaySize) / 2, cRoomSize / 2, cHallwaySize);

        // Draw lair, monster, player as ovals
        if (Lair)
            g.FillEllipse(Brushes.Purple, x + 2, y + 2, cLairSize, cLairSize);
        if (Monster)
            g.FillEllipse(Brushes.Red, x + (cRoomSize - cMonsterSize), y + (cRoomSize - cMonsterSize), cMonsterSize, cMonsterSize);
        if (Player)
            g.FillEllipse(Brushes.Blue, x + (cRoomSize - cPlayerSize) / 2, y + (cRoomSize - cPlayerSize) / 2, cPlayerSize, cPlayerSize);
    }
}
