using System.Collections.Generic;

namespace Observers
{
    public abstract class AbstractStringSubject : ISubject<AbstractStringSubject>
    {
        private readonly ICollection<IObserver<AbstractStringSubject>> _observers;

        private string _item;

        public string Item 
        {
            get => _item; 
            protected set
            {
                _item = value;

                foreach (IObserver<AbstractStringSubject> obs in _observers)
                    obs.Update(this);
            }
        }

        public AbstractStringSubject() => 
            _observers = new List<IObserver<AbstractStringSubject>>();

        public void RegisterObserver(IObserver<AbstractStringSubject> obs)
        {
            _observers.Add(obs);
        }

        public void RemoveObserver(IObserver<AbstractStringSubject> obs)
        {
            _observers.Remove(obs);
        }
    }
}