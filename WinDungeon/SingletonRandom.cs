using System;

namespace WinDungeon
{
    sealed class SingletonRandom
    {
        static readonly SingletonRandom _instance = new SingletonRandom();
        private readonly Random _random = new Random();
        internal static SingletonRandom GetInstance() => _instance;
        internal Random Rnd { get => _random; }
    }
}
