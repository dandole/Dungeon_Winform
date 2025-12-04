namespace Dungeon;

using static Constants;


internal class Level
{
    internal int Floor { get; set; }
    internal Dictionary<Point, Room> Rooms { get; set; } = [];

    internal Level(int floor, int xSize, int ySize)
    {
        Floor = floor;
        do
        {
            Rooms.Clear();
            for (int iY = 0; iY < ySize; iY++)
            {
                for (int iX = 0; iX < xSize; iX++)
                {
                    Room room = new(new Point(iX, iY), xSize - 1, ySize - 1);
                    Rooms.Add(room.Position, room);
                }
            }

            ConnectRooms();
        }
        while (!CheckConnectors());
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

    bool CheckConnectors()
    {
        int count = 1;
        bool check = true;
        bool firstRoom = true;

        foreach (var room in Rooms.Values)
        {
            if (!room.Connected && firstRoom)
            {
                firstRoom = false;
                TestIt(room, 0);
                count++;
            }
            else if (!room.Connected && !firstRoom)
            {
                check = false;
                break;
            }
        }

        return check;
    }

    private void TestIt(Room room, Direction directionTestingFrom)
    {
        if (!room.Connected)
        {
            room.Connected = true;
            if (room.North && directionTestingFrom != Direction.South)
            {
                TestIt(Rooms[new Point(room.Position.X, room.Position.Y - 1)], Direction.North);
            }

            if (room.South && directionTestingFrom != Direction.North)
            {
                TestIt(Rooms[new Point(room.Position.X, room.Position.Y + 1)], Direction.South);
            }

            if (room.East && directionTestingFrom != Direction.West)
            {
                TestIt(Rooms[new Point(room.Position.X + 1, room.Position.Y)], Direction.East);
            }

            if (room.West && directionTestingFrom != Direction.East)
            {
                TestIt(Rooms[new Point(room.Position.X - 1, room.Position.Y)], Direction.West);
            }
        }
    }
}
