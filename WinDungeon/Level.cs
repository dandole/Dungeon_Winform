using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Microsoft.VisualBasic.PowerPacks;

using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class Level
    {
        internal int Floor { get; set; }
        internal Dictionary<Point, Room> Rooms { get; set; } = new Dictionary<Point, Room>();
        internal ShapeContainer ShapeContainer { get; set; } = new ShapeContainer();

        internal Level(int floor, int xSize, int ySize)
        {
            this.Floor = floor;
            do
            {
                this.Rooms.Clear();
                for (int iY = 0; iY < ySize; iY++)
                {
                    for (int iX = 0; iX < xSize; iX++)
                    {
                        Room room = new Room(new Point(iX, iY), xSize - 1, ySize - 1);
                        this.Rooms.Add(room.Position, room);
                    }
                }

                ConnectRooms();
            }
            while (!this.CheckConnectors());
        }

        internal void Clear()
        {
            this.Rooms.Clear();
            this.ShapeContainer.Parent = null;
            this.ShapeContainer = null;
        }

        internal void Render(Control parent)
        {
            foreach (var room in Rooms.Values)
            {
                this.ShapeContainer.Shapes.AddRange(room.Build());
            }

            List<OvalShape> shapesToPullForward = new List<OvalShape>();

            foreach (var shape in this.ShapeContainer.Shapes)
            {
                if (shape is OvalShape)
                {
                    shapesToPullForward.Add(shape as OvalShape);
                }
            }

            foreach (var os in shapesToPullForward)
            {
                os.BringToFront();
            }
            shapesToPullForward.Clear();
            this.ShapeContainer.Visible = false;
            this.ShapeContainer.Parent = parent;
        }

        void ConnectRooms()
        {
            foreach (var room in this.Rooms.Values)
            {
                if (room.North) this.Rooms[new Point(room.Position.X, room.Position.Y - 1)].South = true;
                if (room.South) this.Rooms[new Point(room.Position.X, room.Position.Y + 1)].North = true;
                if (room.East) this.Rooms[new Point(room.Position.X + 1, room.Position.Y)].West = true;
                if (room.West) this.Rooms[new Point(room.Position.X - 1, room.Position.Y)].East = true;
            }
        }

        bool CheckConnectors()
        {
            int count = 1;
            bool check = true;
            bool firstRoom = true;

            foreach (var room in this.Rooms.Values)
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
                    TestIt(this.Rooms[new Point(room.Position.X, room.Position.Y - 1)], Direction.North);
                }

                if (room.South && directionTestingFrom != Direction.North)
                {
                    TestIt(this.Rooms[new Point(room.Position.X, room.Position.Y + 1)], Direction.South);
                }

                if (room.East && directionTestingFrom != Direction.West)
                {
                    TestIt(this.Rooms[new Point(room.Position.X + 1, room.Position.Y)], Direction.East);
                }

                if (room.West && directionTestingFrom != Direction.East)
                {
                    TestIt(this.Rooms[new Point(room.Position.X - 1, room.Position.Y)], Direction.West);
                }
            }
        }
    }
}
