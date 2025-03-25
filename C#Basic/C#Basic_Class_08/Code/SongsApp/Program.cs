using SongsApp.Domain.Enums;
using SongsApp.Domain.Models;

Person person = new Person("Petko", "Petkovski", 25, GenreEnum.Rock);
person.GetFavSongs();

person.FavoriteSongs.Add(new Song("Stairway to Heaven", 8.02, GenreEnum.Rock));
person.FavoriteSongs.Add(new Song("Bohemian Rhapsody", 5.55, GenreEnum.Rock));

person.GetFavSongs();