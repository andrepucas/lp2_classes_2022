using System;
using System.Linq;
using System.Collections.Generic;

namespace ExtendString
{
    class Program
    {
        private static IEnumerable<int?> lotsOfInts;

        private static List<Monster?> monstersList;
        
        static void Main(string[] args)
        {
            lotsOfInts = new List<int?>(){1, 2,null, 3, 4, 5, 6, 10, 20, 50, 200};

            monstersList = new List<Monster?>() {null, null, Monster.Troll};

            Monster monst = monstersList?[0] ?? Monster.Minion;

            Console.WriteLine(HowManyNullsIn(monstersList));
            
            // Console.WriteLine(lotsOfInts.Count(i => i % 2 != 0));

            // foreach (int? i in lotsOfInts.Where(i => 100 % i == 0))
            //     Console.Write(i + " ");

            //bool hasNulls = bagOfInts.Any(i => !i.HasValue);
        }

        private static int HowManyNullsIn(List<Monster?> list) => list.Count(m => !m.HasValue);

        public static Vector2 Deg2Vec(float angle)
        {
            float angleRad = angle * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        // Determine angle of vector in degrees
        public static float Vec2Deg(Vector2 vector)
        {
            return Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        }

        // Normalized direction between two game objects
        public static Vector2 Direction(Vector2 from, Vector2 to)
        {
            return (to - from) / (to - from).magnitude;
        }
        
        // Distance between two game objects
        public static float Distance(Vector2 obj1, Vector2 obj2)
        {
            return (obj1 - obj2).magnitude;
        }
    }

    enum Monster { Troll, Ogre, Elf, Demon, Vampire, Werewolf, Minion}
}
