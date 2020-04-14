using Microsoft.VisualBasic.PowerPacks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            foreach(var room in Rooms.Values)
            {
                this.ShapeContainer.Shapes.AddRange(room.Build());
            }

            List<OvalShape> shapesToPullForward = new List<OvalShape>();

            foreach(var shape in this.ShapeContainer.Shapes)
            {
                if (shape is OvalShape)
                {
                    shapesToPullForward.Add(shape as OvalShape);
                }
            }

            foreach(var os in shapesToPullForward)
            {
                os.BringToFront();
            }
            shapesToPullForward.Clear();
            this.ShapeContainer.Visible = false;
            this.ShapeContainer.Parent = parent;
        }

        void ConnectRooms()
        {
            foreach(var room in this.Rooms.Values)
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
            bool firstRoom = false;

            foreach(var room in this.Rooms.Values)
            {
                if (room.Connector == 0 && firstRoom == false)
                {
                    firstRoom = true;
                    ExploreIt(room, count, 0);
                    count++;
                }
                else if (room.Connector==0 && firstRoom == true)
                {
                    check = false;
                    break;
                }
            }

            return check;
        }

        private void ExploreIt(Room room, int pointer, eDirection direction)
        {
            if (room.Connector == 0)
            {
                room.Connector = pointer;
                if (room.North && direction!=eDirection.South)
                {
                    ExploreIt(this.Rooms[new Point(room.Position.X, room.Position.Y - 1)], pointer, eDirection.North);
                }

                if (room.South && direction != eDirection.North)
                {
                    ExploreIt(this.Rooms[new Point(room.Position.X, room.Position.Y + 1)], pointer, eDirection.South);
                }

                if (room.East && direction != eDirection.West)
                {
                    ExploreIt(this.Rooms[new Point(room.Position.X + 1, room.Position.Y)], pointer, eDirection.East);
                }

                if (room.West && direction != eDirection.East)
                {
                    ExploreIt(this.Rooms[new Point(room.Position.X - 1, room.Position.Y)], pointer, eDirection.West);
                }
            }
        }
    }
}
