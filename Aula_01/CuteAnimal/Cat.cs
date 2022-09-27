using System;

namespace CuteAnimal
{
    public class Cat
    {
        public static int   MaxAge {get;} = 40;

        public string       Name {get;}
        public int          Age {get;}
        public Feed         FeedStatus {get;}
        public Mood         MoodStatus {get;}

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
            Mood[] moods;
            
            Name = name;
            Age = _random.Next(MaxAge);
            FeedStatus = (Feed)_random.Next(Enum.GetNames(typeof(Feed)).Length);

            moods = (Mood[])Enum.GetValues(typeof(Mood));
            MoodStatus = moods[_random.Next(moods.Length)];
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Age: " + Age + ", Currently: " 
                + FeedStatus + " and " + MoodStatus;
        }
    }
}