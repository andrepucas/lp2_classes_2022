namespace GameUnits
{
    public class SettlerUnit : Unit
    {
        public override float Value => 5;
        
        public SettlerUnit (int mov, int health) : base(mov, health) {}

        public void Settle (Vector2 v)
        {
            // Settle somewhere.
        }
    }
}