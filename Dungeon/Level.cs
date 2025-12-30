namespace Dungeon;

using static Constants;


internal class Level
{
    internal Random Rng { get; private set; }

    internal int Floor { get; set; }
    internal Dictionary<Point, Room> Rooms { get; set; } = [];

    internal Level(int floor, int xSize, int ySize)
    {
        Floor = floor;
        Rng = new Random(floor);
        do
        {
            Rooms.Clear();
            for (int iY = 0; iY < ySize; iY++)
            {
                for (int iX = 0; iX < xSize; iX++)
                {
                    Room room = new(new Point(iX, iY), xSize - 1, ySize - 1, Rng);
                    Rooms.Add(room.Position, room);
                }
            }

            ConnectRooms();
        }
        while (!IsConnected());
    }

    internal void Clear()
    {
        Rooms.Clear();
    }

    void ConnectRooms()
    {
        foreach (var room in Rooms.Values)
        {
            if (room.North) Rooms[new Point(room.Position.X, room.Position.Y - 1)].South = true;
            if (room.South) Rooms[new Point(room.Position.X, room.Position.Y + 1)].North = true;
            if (room.East) Rooms[new Point(room.Position.X + 1, room.Position.Y)].West = true;
            if (room.West) Rooms[new Point(room.Position.X - 1, room.Position.Y)].East = true;
        }
    }

    bool IsConnected()
    {
        foreach (var r in Rooms.Values)
            r.Connected = false;

        var start = Rooms.Values.First();
        var stack = new Stack<Room>();
        stack.Push(start);
        start.Connected = true;

        while (stack.Count > 0)
        {
            var room = stack.Pop();

            foreach (var next in GetNeighbors(room))
            {
                if (!next.Connected)
                {
                    next.Connected = true;
                    stack.Push(next);
                }
            }
        }

        return Rooms.Values.All(r => r.Connected);
    }

    IEnumerable<Room> GetNeighbors(Room room)
    {
        var p = room.Position;

        if (room.North && Rooms.TryGetValue(new Point(p.X, p.Y - 1), out var n)) yield return n;
        if (room.South && Rooms.TryGetValue(new Point(p.X, p.Y + 1), out var s)) yield return s;
        if (room.East && Rooms.TryGetValue(new Point(p.X + 1, p.Y), out var e)) yield return e;
        if (room.West && Rooms.TryGetValue(new Point(p.X - 1, p.Y), out var w)) yield return w;
    }
}
