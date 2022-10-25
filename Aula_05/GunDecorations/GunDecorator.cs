namespace GunDecorations
{
    public abstract class GunDecorator : Gun
    {
        private Gun _gun;

        public override int AmmoCapacity => _gun.AmmoCapacity;
        public override float NoiseLevel => _gun.NoiseLevel;
        
        public GunDecorator(Gun p_gun)
        {
            _gun = p_gun;
        }
    }
}