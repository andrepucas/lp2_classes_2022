namespace BearAdapter
{
    public class BearAdapter : IDog
    {
        private IBear _bear;

        public void Bark()
        {
            _bear.Roar();
        }

        public void Fetch(object objectToFetch)
        {
            _bear.LookAt(objectToFetch);
            _bear.GoTowards(objectToFetch);
            _bear.TryEat(objectToFetch);
        }

        public BearAdapter(IBear p_bear)
        {
            _bear = p_bear;
        }
    }
}