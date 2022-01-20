using Catalog.Dtos;
using Catalog.Models;
using Catalog.Repo;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("films")]
    public class FilmControllers : ControllerBase
    {
        private IFilm _FilmRepo;
        public FilmControllers(IFilm filmRepo)
        {
            _FilmRepo = filmRepo;
            //_BookRepo = new InMemBookRepo();
        }
        [HttpGet]
        public ActionResult<IEnumerable<FilmDTO>> GetFilms()
        {
            return _FilmRepo.GetFilms().Select(x => new FilmDTO
            {
                Id = x.Id,
                
                Title = x.Title,
                Description = x.Description,
                PriceInCent = x.PriceInCent,
                Director = x.Director,
                //Studio = x.Studio,
                //Categorie = x.Categorie,
                Writers = x.Writers,
                Tagline = x.Tagline,
                ReleaseDate = x.ReleaseDate,
                RuntimeInMinutes = x.RuntimeInMinutes,
                BudgetInUSDollar = x.BudgetInUSDollar,
                Rating = x.Rating,



            }).ToList();
            }
        
        
    [HttpGet("{id}")]
    public ActionResult<FilmDTO> GetFilm(Guid id)
    {
            var film = _FilmRepo.GetFilm(id);

            //if (film == null) return NotFound();
            var filmDTO = new FilmDTO
            {
                Id = film.Id,

                Title = film.Title,
                Description = film.Description,
                PriceInCent = film.PriceInCent,
                Director = film.Director,
                //Studio = film.Studio,
                //Categorie = film.Categorie,
                Writers = film.Writers,
                Tagline = film.Tagline,
                ReleaseDate = film.ReleaseDate,
                RuntimeInMinutes = film.RuntimeInMinutes,
                BudgetInUSDollar = film.BudgetInUSDollar,
                Rating = film.Rating,

                
            };
            return filmDTO;

    }

        [HttpPost]
        public ActionResult CreateFilm(CreateOrUpdateFilmDTO film)
        {
            var film1=new Film();
            film1.Id=Guid.NewGuid();

            film1.Title = film.Title;
            film1.Description = film.Description;
            film1.PriceInCent = film.PriceInCent;
            film1.Director = film.Director;
            //film1.Studio = film.Studio;
            //film1.Categorie = film.Categorie;
            film1.Writers = film.Writers;
            film1.Tagline = film.Tagline;
            film1.ReleaseDate = film.ReleaseDate;
            film1.RuntimeInMinutes = film.RuntimeInMinutes;
            film1.BudgetInUSDollar = film.BudgetInUSDollar;
            film1.Rating = film.Rating;

            _FilmRepo.CreateFilm(film1);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFilm(Guid id,CreateOrUpdateFilmDTO film)
        {



            var film2 = _FilmRepo.GetFilm(id);

            if (film2 == null) return NotFound();
            
            film2.Title = film.Title;
            film2.Description = film.Description;
            film2.PriceInCent = film.PriceInCent;
            film2.Director = film.Director;
            //film2.Studio = film.Studio;
            //film2.Categorie = film.Categorie;
            film2.Writers = film.Writers;
            film2.Tagline = film.Tagline;
            film2.ReleaseDate = film.ReleaseDate;
            film2.RuntimeInMinutes = film.RuntimeInMinutes;
            film2.BudgetInUSDollar = film.BudgetInUSDollar;
            film2.Rating = film.Rating;
            
            _FilmRepo.UpdateFilm(id, film2);

            return Ok(); 
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFilm(Guid id)
        {
            //var film = _FilmRepo.GetFilm(id);
            //if (film == null) return NotFound();

            _FilmRepo.DeleteFilm(id);
            return Ok();
        }

    }



    }

