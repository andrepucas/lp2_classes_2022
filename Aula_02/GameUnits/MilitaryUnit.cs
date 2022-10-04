namespace GameUnits
{
    public class MilitaryUnit : Unit
    {
        public int AttackPower {get;}
        public int XP {get; set;}
        public override int Health => base.Health + XP;
        public override float Value => AttackPower + XP;

        public MilitaryUnit(int mov, int health, int attackPower) : base(mov, health)
        {
            AttackPower = attackPower;
            XP = 0;
        }

        public void Attack(Unit u)
        {
            // Attack some Unit.
        }

        public override string ToString() =>
            base.ToString() + $", Power: {AttackPower}";
    }
}