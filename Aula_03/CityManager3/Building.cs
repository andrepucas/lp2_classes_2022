using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityManager3
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
            if (other == null)
                return false;

            else return other.Value == Value;
        }

        public int CompareTo(IHasValue other)
        {
            if (other == null) return 1;
            return (int)(other.Value - Value);
        }

        public override string ToString() => 
            $"Type: {Type, -15} | Value: {Value, 8:f2} | Area: {Area, 8:f2}";
        
    }
}