using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDungeon
{
    internal class Constants
    {
        internal enum eDirection
        {
            North = 1,
            South = 2,
            East = 3,
            West = 4,
            Up = 5,
            Down = 6
        }

        internal struct Money
        {
            internal int Platinum;
            internal int Gold;
            internal int Electrum;
            internal int Silver;
            internal int Copper;

            internal void Reduce()
            {
                this.Silver += (int)this.Copper / 5;
                this.Copper -= ((int)this.Copper / 5) * 5;

                this.Electrum += (int)this.Silver / 5;
                this.Silver -= ((int)this.Silver / 5) * 5;

                this.Gold += (int)this.Electrum / 2;
                this.Electrum -= ((int)this.Electrum / 2) * 2;

                this.Platinum += (int)this.Gold / 5;
                this.Gold -= ((int)this.Gold / 5) * 5;
            }
        }
    }
}
