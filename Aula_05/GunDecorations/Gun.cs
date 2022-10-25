using System;

namespace GunDecorations
{
    public abstract class Gun
    {
        public abstract int AmmoCapacity {get;}
        public abstract float NoiseLevel {get;}

        public void Fire() => Console.Write(
            $" => Ammo: {AmmoCapacity, 3} | Noise: {NoiseLevel, 3}");
    }
}