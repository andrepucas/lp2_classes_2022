using System;

namespace LazySingleFloat
{
    public sealed class SingletonManager
    {
        private static readonly Lazy<SingletonManager> _instance =
            new Lazy<SingletonManager>(() => new SingletonManager());

        public static SingletonManager Instance = _instance.Value;

        public float FloatValue {get; set;}

        private SingletonManager() {}
    }
}