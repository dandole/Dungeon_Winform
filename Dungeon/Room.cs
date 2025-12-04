namespace Dungeon;

using static Constants;

internal class Room
{
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
}
