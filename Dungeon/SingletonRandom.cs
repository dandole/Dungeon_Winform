namespace Dungeon;

sealed class SingletonRandom
{
    static readonly SingletonRandom _instance = new();
    private readonly Random _random = new();
    internal static SingletonRandom GetInstance() => _instance;
    internal Random Rnd { get => _random; }
}
