using System;

namespace Indexers
{
    public struct MyVector
    {
        private const string INDEX_0 = "xa0";
        private const string INDEX_1 = "yb1";

        public float X { get; set; }
        public float Y { get; set; }
        public MyVector(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float this[int index]
        {
            get
            {
                if (index == 0) return X;
                else if (index == 1) return Y;
                else throw new IndexOutOfRangeException();
            }

            set
            {
                if (index == 0) X = value;
                else if (index == 1) Y = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public float this[string index]
        {
            get
            {
                index = index.ToLower();
                if (INDEX_0.Contains(index)) return X;
                else if (INDEX_1.Contains(index)) return Y;
                else throw new IndexOutOfRangeException();
            }

            set
            {
                index = index.ToLower();
                if (INDEX_0.Contains(index)) X = value;
                else if (INDEX_1.Contains(index)) Y = value;
                else throw new IndexOutOfRangeException();
            }
        }
    }

    
}