using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongsApp.Domain.Enums;

namespace SongsApp.Domain.Models
{
    public class Person
    {
        private int _Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public GenreEnum FavoriteMusicType { get; set; }
        public List<Song> FavoriteSongs { get; set; }   // List of song objects; the default alue of this list is null (not an empty list)
                                                        // therefore in the constructor we must create an empty list

        public Person(string firstName, string lastName, int age, GenreEnum favoriteMusicType)
        {
            _Id = new Random().Next(1, 10000);
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavoriteMusicType = favoriteMusicType;

            //   ! ! !!  Important !!!!
            FavoriteSongs = new List<Song>(); //we must create an empty list,
                                              //otherwisethe value is null and if we try to add new elements
                                              //we will have null.Add() which will throw an exception
        }
        public void GetFavSongs()
        {
            if (FavoriteSongs.Count == 0)
            {
                Console.WriteLine("No favorite songs added yet");
            }
            else
            {
                Console.WriteLine("Favorite songs:");
                foreach (Song song in FavoriteSongs)
                {
                    Console.WriteLine($"Title: {song.Title}, Length: {song.Length}, Genre: {song.Genre}");
                }
            }
        }

    }
}
