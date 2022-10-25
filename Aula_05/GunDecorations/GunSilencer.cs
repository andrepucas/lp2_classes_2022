namespace GunDecorations
{
    public class GunSilencer : GunDecorator
    {
        public override float NoiseLevel => base.NoiseLevel * 0.8f;

        public GunSilencer(Gun p_gun) : base (p_gun) {}
    }
}