using System;

namespace BearAdapter
{
    public class BrownBear : IBear
    {
        public bool Hibernating {get; set;}

        public BrownBear(bool status)
        {
            Hibernating = status;
        }
        
        public void Roar()
        {
            if (!Hibernating) Console.WriteLine ("RAWRRR");

            else Console.WriteLine("zZzZZzz ...");
        }

        public void LookAt(object p_objectToLookAt)
        {
            if (!Hibernating) Console.WriteLine("Brown Bear looks at "
                + p_objectToLookAt.ToString());

            else Console.WriteLine("Brown Bear doesn't see "
                + p_objectToLookAt.ToString() + " because it's hibernating.");
        }

        public void GoTowards(object p_objectToGoTowards)
        {
            if (!Hibernating) Console.WriteLine("Brown Bear goes towards "
                + p_objectToGoTowards.ToString());

            else Console.WriteLine("Brown Bear continues sleeping and "
                + p_objectToGoTowards.ToString() + " is vibing.");
        }

        public bool TryEat(object p_objectToEat)
        {
            if (!Hibernating) 
            {
                Console.WriteLine("Brown Bear tries to eat "
                    + p_objectToEat.ToString());
                
                return true;
            }

            else 
            {
                Console.WriteLine(p_objectToEat.ToString() + " does not get eaten.");

                return false;
            }
        }
    }
}