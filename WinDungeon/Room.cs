using System.Drawing;
using System.Linq;

using Microsoft.VisualBasic.PowerPacks;

using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class Room
    {
        const int cXOffset = 100;
        const int cYOffset = 100;
        const int cRoomSize = 20;
        const int cHallwaySize = 8;
        const int cLairSize = 8;
        const int cMonsterSize = 8;
        const int cPlayerSize = 8;

        RectangleShape _shapeRoom;
        RectangleShape _shapeNorth;
        RectangleShape _shapeSouth;
        RectangleShape _shapeEast;
        RectangleShape _shapeWest;
        OvalShape _shapeLair;
        OvalShape _shapeMonster;
        OvalShape _shapePlayer;

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

        bool _up;
        internal bool Up { get => _up; set { _up = value; _shapeRoom.FillColor = Color.LightCoral; } }

        bool _down;
        internal bool Down { get => _down; set { _down = value; _shapeRoom.FillColor = Color.CadetBlue; } }

        bool _monster;
        internal bool Monster
        {
            get => _monster;
            set
            {
                _monster = value;
                if (this.Mapped)
                {
                    _shapeMonster.Visible = value;
                    _shapeMonster.Refresh();
                    _shapeRoom.Refresh();
                }
            }
        }

        bool _player;
        internal bool Player
        {
            get => _player;
            set
            {
                _player = value;
                if (value)
                {
                    if (this.Mapped == false)
                    {
                        this.Mapped = true;
                        ShowRoom();
                    }

                    this.Visits += 1;
                }

                _shapePlayer.Visible = value;
            }
        }

        internal Room(Point position, int xDimension, int yDimension)
        {
            this.Position = position;
            while (!this.North & !this.South & !this.East & !this.West)
            {
                this.North = this.Position.Y != 0 && _random.Rnd.Next(1, 101) <= 25;
                this.South = this.Position.Y != yDimension && _random.Rnd.Next(1, 101) <= 25;
                this.East = this.Position.X != xDimension && _random.Rnd.Next(1, 101) <= 25;
                this.West = this.Position.X != 0 && _random.Rnd.Next(1, 101) <= 25;
            }
        }

        void ShowRoom()
        {
            _shapeRoom.Visible = this.Mapped;
            _shapeNorth.Visible = this.North;
            _shapeSouth.Visible = this.South;
            _shapeEast.Visible = this.East;
            _shapeWest.Visible = this.West;
            _shapeLair.Visible = this.Lair;
            _shapeMonster.Visible = this.Monster;
        }

        internal bool CanMove(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return this.North;
                case Direction.South:
                    return this.South;
                case Direction.East:
                    return this.East;
                case Direction.West:
                    return this.West;
                case Direction.Up:
                    return this.Up;
                case Direction.Down:
                    return this.Down;
                default:
                    return false;
            }
        }

        internal int Paths
        {
            get
            {
                return new bool[] { this.North, this.South, this.East, this.West, this.Up, this.Down }.Count(x => x);
            }
        }

        internal Shape[] Build()
        {
            Shape[] shapes = new Shape[8];
            _shapeRoom = new RectangleShape(cXOffset + (2 * cRoomSize * this.Position.X),
                                            cYOffset + (2 * cRoomSize * this.Position.Y),
                                            cRoomSize,
                                            cRoomSize)
            {
                FillStyle = FillStyle.Solid,
                FillColor = Color.DarkKhaki,
                Visible = this.Mapped
            };

            _shapeNorth = new RectangleShape(cXOffset + (2 * cRoomSize * this.Position.X) + ((cRoomSize - cHallwaySize) / 2),
                                             cYOffset + (2 * cRoomSize * this.Position.Y) - (cRoomSize / 2),
                                             cHallwaySize,
                                             cRoomSize / 2);
            _shapeSouth = new RectangleShape(cXOffset + (2 * cRoomSize * this.Position.X) + ((cRoomSize - cHallwaySize) / 2),
                                             cYOffset + (2 * cRoomSize * this.Position.Y) + cRoomSize,
                                             cHallwaySize,
                                             cRoomSize / 2);
            _shapeEast = new RectangleShape(cXOffset + (2 * cRoomSize * this.Position.X) + cRoomSize,
                                             cYOffset + (2 * cRoomSize * this.Position.Y) + ((cRoomSize - cHallwaySize) / 2),
                                             cRoomSize / 2,
                                             cHallwaySize);
            _shapeWest = new RectangleShape(cXOffset + (2 * cRoomSize * this.Position.X) - (cRoomSize / 2),
                                             cYOffset + (2 * cRoomSize * this.Position.Y) + ((cRoomSize - cHallwaySize) / 2),
                                             cRoomSize / 2,
                                             cHallwaySize);

            _shapeNorth.Visible = this.North & this.Mapped;
            _shapeSouth.Visible = this.South & this.Mapped;
            _shapeEast.Visible = this.East & this.Mapped;
            _shapeWest.Visible = this.West & this.Mapped;

            _shapeLair = new OvalShape(cXOffset + (2 * cRoomSize * this.Position.X),
                                       cYOffset + (2 * cRoomSize * this.Position.Y),
                                       cLairSize,
                                       cLairSize)
            {
                FillStyle = FillStyle.Solid,
                FillColor = Color.Black,
                Visible = this.Lair & this.Mapped
            };

            _shapeMonster = new OvalShape(cXOffset + (2 * cRoomSize * this.Position.X) + (cRoomSize - cMonsterSize),
                           cYOffset + (2 * cRoomSize * this.Position.Y) + (cRoomSize - cMonsterSize),
                           cMonsterSize,
                           cMonsterSize)
            {
                FillStyle = FillStyle.Solid,
                FillColor = Color.Blue,
                Visible = this.Monster & this.Mapped
            };

            _shapePlayer = new OvalShape(cXOffset + (2 * cRoomSize * this.Position.X) + ((cRoomSize - cPlayerSize) / 2),
               cYOffset + (2 * cRoomSize * this.Position.Y) + ((cRoomSize - cPlayerSize) / 2),
               cPlayerSize,
               cPlayerSize)
            {
                FillStyle = FillStyle.Solid,
                FillColor = Color.Red,
                Visible = this.Player
            };

            shapes[0] = _shapeRoom;
            shapes[1] = _shapeNorth;
            shapes[2] = _shapeSouth;
            shapes[3] = _shapeEast;
            shapes[4] = _shapeWest;
            shapes[5] = _shapeLair;
            shapes[6] = _shapeMonster;
            shapes[7] = _shapePlayer;

            return shapes;
        }
    }
}
