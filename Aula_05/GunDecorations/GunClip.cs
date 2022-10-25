using System;

namespace GunDecorations
{
    public class GunClip : GunDecorator
    {
        public override int AmmoCapacity => base.AmmoCapacity + _clipSize;

        private int _clipSize;

        public GunClip(Gun p_gun, int p_clipSize) : base(p_gun)
        {
            _clipSize = Math.Abs(p_clipSize);
        }
    }
}