using System;

namespace CuteAnimal
{
    public class Cat
    {
        private string  _name;
        private int     _age;
        private Feed    _feedStatus;
        private Mood    _moodStatus;
        private Random  _random;

        private Cat()
        {
            _random = new Random();
        }

        public Cat(string name, int age, Feed feedStatus, Mood moodStatus) : this()
        {
            _name = name;
            _age = age;
            _feedStatus = feedStatus;
            _moodStatus = moodStatus;
        }

        public Cat(string name) : this()
        {
            _name = name;
            _age = _random.Next(25);
            _feedStatus = (Feed)_random.Next(Enum.GetNames(typeof(Feed)).Length);
            _moodStatus = (Mood)_random.Next(Enum.GetNames(typeof(Mood)).Length);
        }

        public string GetName() => _name;

        public (string, int, Feed, Mood) GetAll() 
            => (_name, _age, _feedStatus, _moodStatus);
    }
}