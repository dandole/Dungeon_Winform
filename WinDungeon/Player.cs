using static WinDungeon.Constants;

namespace WinDungeon
{
    internal class Player
    {
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
            Direction direction=0;
            int roomVisits = int.MaxValue;
            for (int i = 1; i <= 6; i++)
            {
                if (i!=5 && dungeon.Room(this.Location).CanMove((Direction)i) && dungeon.RoomAt(this.Location, (Direction)i).Visits < roomVisits)
                {
                    roomVisits = dungeon.RoomAt(this.Location, (Direction)i).Visits;
                    direction = (Direction) i;
                }
            }

            dungeon.Room(this.Location).Player = false;
            this.Location.Move(direction);
            dungeon.Room(this.Location).Player = true;
        }
    }
}
