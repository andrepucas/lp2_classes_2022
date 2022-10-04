using System;

namespace GameUnits
{
    public abstract class Unit
    {
        private int _movement;

        public virtual int Health {get; set;}
        public abstract float Value {get;}

        public Unit(int movement, int health)
        {
            _movement = movement;
            Health = health;
        }

        public void Move(Vector2 v)
        {
            int movesCount = Math.Abs(v.X) + Math.Abs(v.Y);

            Console.WriteLine(
                $"\t{this.GetType().Name} has moved {movesCount} positions");
        }

        public override string ToString() => 
            $"{this.GetType().Name} | HP: {Health}, Val: {Value}";
    }
}