using System;

namespace Podium
{
    public class Building : IHasValue, IComparable<IHasValue>
    {
        public string Type {get;}
        public float Area {get;}
        public float Value {get;}

        public Building(string type, float value, float area)
        {
            Type = type;
            Area = area;
            Value = value;
        }

        public bool Equals (IHasValue other)
        {
            if (other == null) return false;
            return other.Value == Value;
        }

        public int CompareTo(IHasValue other)
        {
            // Nulls always come first in sorting
            if (other == null) return 1;
            if (Value < other.Value) return -1;
            if (Value > other.Value) return 1;
            return 0;
        }

        public override string ToString() => 
            $"Type: {Type, -10} | Value: {Value, 8:f2} | Area: {Area, 8:f2}";

        public override int GetHashCode() =>
            Type.GetHashCode() ^ Value.GetHashCode();

        public override bool Equals(object obj)
        {
            Building other = obj as Building;

            if (obj is null) return false;
            return Type == other.Type && Value == other.Value;
        }

        // Se building fosse uma struct, não seria preciso sobrepor GetHashCode() e Equals().
    }
}