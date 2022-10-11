using System;

namespace HashBuildings
{
    public interface IHasValue : IEquatable<IHasValue>
    {
        float Value {get;}
    }
}