namespace HashBuildings
{
    public class Building : IHasValue
    {
        public string Type {get;}
        public float Area {get;}
        public float Value {get;}

        public Building(string type, float area, float value)
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

        public override string ToString() => 
            $"Type: {Type, -10} | Area: {Area, 8:f2} | Value: {Value, 8:f2}";

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