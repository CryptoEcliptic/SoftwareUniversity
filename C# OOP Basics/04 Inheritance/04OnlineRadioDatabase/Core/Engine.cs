using _04OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04OnlineRadioDatabase.Core
{
    public class Engine
    {

        List<Song> playlist;

        public Engine()
        {
            this.playlist = new List<Song>();
        }

        public void Run()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] song = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (song.Length != 3)
                {
                    Exception fe = new InvalidSongException();
                    Console.WriteLine(fe.Message);
                    continue;
                }

                string artist = song[0];
                string songName = song[1];
                string[] timeSong = song[2].Split(":");

                int songMinutes = 0;
                int songSeconds = 0;

                bool isMinutes = int.TryParse(timeSong[0], out songMinutes);
                bool isSeconds = int.TryParse(timeSong[1], out songSeconds);
                if (!isMinutes)
                {
                    Exception fe = new InvalidSongLengthException();
                    Console.WriteLine(fe.Message);
                    continue;
                }
                if (!isSeconds)
                {
                    Exception fe = new InvalidSongLengthException();
                    Console.WriteLine(fe.Message);
                    continue;
                }

                Song currentSong = new Song(artist, songName, songMinutes, songSeconds);

                if (currentSong.isValidSong) //Add only valid songs to a collection of songs
                {
                    playlist.Add(currentSong);
                    Console.WriteLine("Song added.");
                }
            }

            var playlistLengthInSeconds = playlist.Sum(x => x.Minutes * 60) + playlist.Sum(x => x.Seconds); //Sum songs times in seconds
            TimeSpan playlistTime = TimeSpan.FromSeconds(playlistLengthInSeconds); //Convert all seconds to hh mm ss
            int hours = playlistTime.Hours;
            int minutes = playlistTime.Minutes;
            int seconds = playlistTime.Seconds;

            Console.WriteLine($"Songs added: {playlist.Count}");
            Console.WriteLine($"Playlist length: {hours}h {minutes}m {seconds}s");

        }
    }
}
