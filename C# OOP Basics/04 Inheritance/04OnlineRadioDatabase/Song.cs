using _04OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04OnlineRadioDatabase
{
    public class Song
    {

        List<Song> songs = new List<Song>();
        public bool isValidSong = true;
        const int songLengthLimit = (14 * 60) + 59;

        private string name;
        private string artist;
        private int minutes;
        private int seconds;

        public Song(string artist, string name, int minutes, int seconds)
        {
            this.Artist = artist;
            this.Name = name;

            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public int Seconds
        {
            get { return seconds; }
            private set
            {
                if (value < 0 || value > 59)
                {
                    isValidSong = false;

                    Exception secEx = new InvalidSongSecondsException();
                    Console.WriteLine(secEx.Message);
                }
                seconds = value;
            }
        }

        public int Minutes
        {
            get { return minutes; }
            private set
            {
                if (value < 0 || value > 14)
                {
                    isValidSong = false;
                    Exception minEx = new InvalidSongMinutesException();
                    Console.WriteLine(minEx.Message);
                }
                minutes = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    isValidSong = false;
                    Exception songEx = new InvalidSongNameException();
                    Console.WriteLine(songEx.Message);
                }
                name = value;
            }
        }

        public string Artist
        {
            get { return artist; }
            private set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    isValidSong = false;
                    Exception artEx = new InvalidArtistNameException();
                    Console.WriteLine(artEx.Message);
                }
                artist = value;
            }
        }
    }
}
