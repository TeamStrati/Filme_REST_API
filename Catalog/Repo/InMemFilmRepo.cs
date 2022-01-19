using Catalog.Models;

namespace Catalog.Repo
{
    public class InMemFilmRepo : IFilm
    {

        private List<Film> _Film;


        public InMemFilmRepo()
        {
            _Film = new()
            {
                new Film { 
                    Id = Guid.NewGuid(),
                    Title = "Film 0",
                    Description = "Description 0",
                    PriceInCent = 10,
                    Director = "Director 0",
                    //Studio = "Studio 0",
                    //Categorie = "Categorie 0",
                    Writers = "Writer 0",
                    Tagline = "Tagline 0",
                    ReleaseDate = "00.00.0000",
                    RuntimeInMinutes = 100,
                    BudgetInUSDollar = 100,
                    Rating = 9,
                }
            };
        }

        public void CreateFilm(Film film)
        {
            _Film.Add(film);
            
        }

        public void DeleteFilm(Guid id)
        {
            var filmIndex = _Film.FindIndex(x => x.Id == id);

            if (filmIndex > -1)
                _Film.RemoveAt(filmIndex);



        }

        public Film GetFilm(Guid id)
        {
            var film = _Film.Where(x => x.Id == id).FirstOrDefault();
            return film;


        }

        public IEnumerable<Film> GetFilms()
        {
            return _Film;
        }

        public void UpdateFilm(Guid id, Film film2)
        {
            var filmIndex = _Film.FindIndex(x => x.Id == id);

            if (filmIndex > -1)

                _Film[filmIndex] = film2;


            
            
        }
    }
}
