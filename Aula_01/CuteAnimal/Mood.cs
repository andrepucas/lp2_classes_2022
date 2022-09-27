using System;

namespace CuteAnimal
{
    [Flags]
    public enum Mood
    {
        Happy       = 1 << 0,
        Grumpy      = 1 << 1,
        IgnoringYou = 1 << 2,
        HyperActive = 1 << 3
    }
}
