using System;

namespace CuteAnimal
{
    public class Cat
    {
        // private string  _name;
        // private int     _age;
        // private Feed    _feedStatus;
        // private Mood    _moodStatus;

        public string   Name {get;}
        public int      Age {get;}
        public Feed     FeedStatus {get;}
        public Mood     MoodStatus {get;}

        private Random  _random;

        private Cat()
        {
            _random = new Random();
        }

        public Cat(string name, int age, Feed feedStatus, Mood moodStatus) : this()
        {
            Name = name;
            Age = age;
            FeedStatus = feedStatus;
            MoodStatus = moodStatus;
        }

        public Cat(string name) : this()
        {
            Name = name;
            Age = _random.Next(25);
            FeedStatus = (Feed)_random.Next(Enum.GetNames(typeof(Feed)).Length);
            MoodStatus = (Mood)_random.Next(Enum.GetNames(typeof(Mood)).Length);
        }

        public override string ToString()
        {
            return "Name:" + Name + ", Age: " + Age + ", Currently: " 
                + FeedStatus + " and " + MoodStatus;
        }

        // public string GetName() => _name;

        // public (string, int, Feed, Mood) GetAll() 
        //     => (_name, _age, _feedStatus, _moodStatus);
    }
}