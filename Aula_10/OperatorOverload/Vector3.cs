using System;

namespace OperatorOverload
{
    public struct Vector3
    {
        // Vector coordinates X, Y, Z
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        // Constructor
        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
