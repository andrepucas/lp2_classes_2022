using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameInterfaces
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
            if (other == null)
                return false;

            else return other.Value == Value;
        }

        public override string ToString() => 
            $"{Type, -20} | {Value, 8:f2} | {Area, 8:f2}";
        
    }
}