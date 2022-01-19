using Catalog.Models;

namespace Catalog.Repo
{
    public interface IFilm
    {

        public IEnumerable<Film> GetFilms();

        public Film GetFilm(Guid id);

        public void CreateFilm(Film book);

        public void UpdateFilm(Guid id, Film book);
        public void DeleteFilm(Guid id);


    }
}
