using System;
using System.Collections;
using System.Collections.Generic;

namespace Podium
{
    public class Podium<T> : IEnumerable<T> where T : IComparable<T>
    {
        private readonly List<T> PODIUM;
        
        public int PodiumSpots {get;}

        public Podium(int p_podiumSpots)
        {
            PodiumSpots = p_podiumSpots;

            PODIUM = new List<T>(PodiumSpots + 1);
        }

        public bool Add(T obj)
        {
            bool __inPodium;

            PODIUM.Add(obj);
            PODIUM.Sort();

            if (PODIUM.Count > PodiumSpots)
            {
                __inPodium = !Equals(obj, PODIUM[PodiumSpots]);

                PODIUM.RemoveAt(PodiumSpots);
            }

            else __inPodium = true;

            return __inPodium;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T obj in PODIUM)
                yield return obj;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}