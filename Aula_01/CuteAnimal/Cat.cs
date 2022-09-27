using System;

namespace CuteAnimal
{
    public class Cat
    {
        public static int maxAge = 40;

        public string   Name {get;}
        public int      Age {get;}
        public Feed     FeedStatus {get;}
        public Mood     MoodStatus {get;}

        private Random _random;

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
            Age = _random.Next(maxAge);
            FeedStatus = (Feed)_random.Next(Enum.GetNames(typeof(Feed)).Length);
            MoodStatus = (Mood)_random.Next(Enum.GetNames(typeof(Mood)).Length);
        }

        public override string ToString()
        {
            return "Name:" + Name + ", Age: " + Age + ", Currently: " 
                + FeedStatus + " and " + MoodStatus;
        }
    }
}