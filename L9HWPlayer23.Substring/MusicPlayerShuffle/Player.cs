using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Player
    {
        const int MIN_VOLUME = 0;
        const int MAX_VOLUME = 100;

        private bool _isLocked;

        private bool _isPlaying;


        private int _volume;
        public int Volume
        {
            get
            {
                return _volume;
            }

            private set
            {
                if (value < MIN_VOLUME)
                {
                    _volume = MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        //public List<Song> Songs { get; private set; }

        public List<Song> Songs { get; private set; } = new List<Song>();
        public void VolumeUp()
        {
            if (_isLocked == false)
            {
                Volume++;
            }
        }

        public void VolumeDown()
        {
            if (_isLocked == false)
            {
                Volume--;
            }
        }

        public void VolumeChange(int step)
        {
            if (_isLocked == false)
            {
                Volume += step;
            }
        }

        //public void Play(bool loop = false)
        //{
        //    var playCount = loop ? Songs.Count : 1;
        //    if (_isLocked)
        //    {
        //        return;
        //    }
        //    _isPlaying = true;
        //    for (int i = 0; i < playCount; i++)
        //    {
        //        Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
        //        System.Threading.Thread.Sleep(1000);
        //    }
        //}

        public void Play(bool loop = false)
        {
            var playCount = loop ? Songs.Count : 1;

            for (int i = 0; i < playCount; i++)
            {
                if (Songs[i].Like.GetValueOrDefault(false))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Player is playing liked songs: {Songs[i].Name}, duration: {Songs[i].Duration}");
                    Console.ResetColor();
                }
              //  else if (Songs[i].Like.HasValue ? !Songs[i].Like.Value : false)
                else if (Songs[i].Like.HasValue && !Songs[i].Like.Value)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Player is playing liked songs: {Songs[i].Name}, duration: {Songs[i].Duration}");
                    Console.ResetColor();

                }
                else
                {
                    Console.WriteLine($"Player is playing liked songs: {Songs[i].Name}, duration: {Songs[i].Duration}");
                }
                //Console.WriteLine($"Player is playing: {Songs[i].Name}, duration: {Songs[i].Duration}");
                //System.Threading.Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            if (_isLocked)
            {
                return;
            }
            _isPlaying = false;
            Console.WriteLine("Player has stopped");
        }

        public void Locked()
        {
            _isLocked = true;
            Console.WriteLine("Player is locked");
        }
        public void Unlock()
        {
            _isLocked = false;
            Console.WriteLine("Player is unlocked");
        }

        public void Add(List<Song>sonList)
        {
            Songs = sonList;
        }

        public void Sort()
        {
            
            Songs.Sort();
            
        }

        public void Shuffle()
        {
            List<Song> shuffleSongs = new List<Song>();
            for (int j = 0; j < 3; j++)
            {
                for (int i = j; i < Songs.Count; i += 3)
                {
                    Song song = Songs[i];
                    shuffleSongs.Add(song);
                }
            }

            Songs = shuffleSongs;
        }

        public void ShuffleAlternative()
        {
            Random rnd = new Random();
            for (int i = Songs.Count - 1; i>=0;  i--)
            {
                var song = Songs[rnd.Next(Songs.Count - 1)];
                Songs.Remove(song);
                Songs.Add(song);

            }
        }
    }
    
}
