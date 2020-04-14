using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinDungeon
{
    sealed class SingletonRandom
    {
        static readonly SingletonRandom _instance = new SingletonRandom();
        Random _random = new Random();
        internal static SingletonRandom GetInstance() => _instance;
        internal Random Rnd { get => _random; }
    }
}
