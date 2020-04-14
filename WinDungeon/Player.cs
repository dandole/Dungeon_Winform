using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class Player
    {
        SingletonRandom _random = SingletonRandom.GetInstance();

        internal string PlayerType { get; set; }
        internal int HitPoints { get; set; }
        internal int HP { get; set; }
        internal DungeonLocation Location { get; set; } = new DungeonLocation();
        internal int Level { get; set; }

        internal Player(DungeonLocation location)
        {
            this.Location = location;
        }

        internal void Move(Dungeon dungeon)
        {
            eDirection direction=0;
            int roomVisits = int.MaxValue;
            for (int i = 1; i < 6; i++)
            {
                if (i!=5 && dungeon.Room(this.Location).CanMove((eDirection)i) && dungeon.RoomAt(this.Location, (eDirection)i).Connector < roomVisits)
                {
                    roomVisits = dungeon.RoomAt(this.Location, (eDirection)i).Connector;
                    direction = (eDirection) i;
                }
            }

            dungeon.Room(this.Location).Player = false;
            this.Location.Move(direction);
            dungeon.Room(this.Location).Player = true;
        }
    }
}
