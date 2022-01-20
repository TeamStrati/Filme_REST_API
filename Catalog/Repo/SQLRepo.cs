using Catalog.Models;
using Catalog.Repo;
using System.Data.SqlClient;
using System;

namespace Filme.Repo
{
    public class SQLRepo : IFilm
    {

        string connectionString = "Server=NG-NB0236\\MSSQLSERVER01;Database=Filme;Trusted_Connection=True;";

        private List<Film> _Film;
        public void CreateFilm(Film film)
        {
            //_Film.Add(film);


           
            SqlConnection connection = new SqlConnection(@connectionString);

            string query = "INSERT INTO Filme(ID, Title, Description, PriceInCent, Director, Studio, Categorie, Writers,Tagline, ReleaseDate, RuntimeInMinutes, BudgetInUSDollar, Rating)  VALUES('" + film.Id + "', '" + film.Title + "','" + film.Description + "'," + film.PriceInCent + ",'" + film.Director + "'," + film.Studio + "," + film.Categorie + ",'" + film.Writers + "','" + film.Tagline + "','" + film.ReleaseDate + "'," + film.RuntimeInMinutes + "," + film.BudgetInUSDollar + "," + film.Rating + ")";
            //Console.WriteLine(query);
            //TODO: Studio und Categorie
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
                //_Film.Add(film);
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                //_Film.Add(film);
            }
            //_Film.Add(film);
           
        }

        public void DeleteFilm(Guid id)
        {
           
                SqlConnection connection = new SqlConnection(@connectionString);
                string query = "DELETE FROM Filme WHERE ID='" + id + "'";

                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Deleted Film " + id);
                    
                }
                catch (SqlException e)
                {
                    Console.WriteLine("Error Generated. Details: " + e.ToString());
                    
                }

        }



        public Film GetFilm(Guid id)
        {
            var film = _Film.Where(x => x.Id == id).FirstOrDefault();
            //return film;

           

            SqlConnection connection = new SqlConnection(@connectionString);
             string query = "SELECT * FROM FILME WHERE ID='" + id + "'";

             SqlCommand command = new SqlCommand(query, connection);

                 connection.Open();
                 SqlDataReader reader = command.ExecuteReader();
                 while (reader.Read()){
                    Guid Id = reader.GetGuid(0);
                     string Title = reader.GetString(1);
                     string Description = reader.GetString(2);
                     decimal PriceInCent = reader.GetInt32(3);
                     string Director = reader.GetString(4);
                     int Studio = reader.GetInt32(5);
                     int Categorie = reader.GetInt32(6);
                     string Writers = reader.GetString(7);
                     string Tagline = reader.GetString(8);
                     string ReleaseData = reader.GetString(9);
                     decimal RuntimeInMinutes = reader.GetInt32(10);
                     decimal Budget = reader.GetInt32(11);
                     decimal Rating = reader.GetInt32(12);


                    film.Id = Id;
                    film.Title = Title;
                    film.Description = Description;
                    film.PriceInCent = PriceInCent;
                    film.Director = Director;
                    film.Studio = Studio;
                    film.Categorie = Categorie;
                    film.Writers = Writers;
                    film.Tagline = Tagline;
                    film.ReleaseDate = ReleaseData;
                    film.RuntimeInMinutes = RuntimeInMinutes;
                    film.BudgetInUSDollar = Budget;
                    film.Rating = Rating;

               
                     //Film SQLFilm = id + Title + Description + PriceInCent + Director + Studio + Categorie + Writers + Tagline + ReleaseData + RuntimeInMinutes + Budget + Rating;
                     //return film;
                      }




            return film;

        
        }

        public IEnumerable<Film> GetFilms()
        {
                return _Film;
            }

        public void UpdateFilm(Guid id, Film film2)
        {

            SqlConnection connection = new SqlConnection(@connectionString);

            string query = "UPDATE Filme SET Title='"+film2.Title+"', Description='"+film2.Description+"', PriceInCent='"+film2.PriceInCent+"',Director='"+film2.Director+"', Writers='"+film2.Writers+"', Tagline ='"+film2.Tagline+"', ReleaseDate='"+film2.ReleaseDate+"', RuntimeInMinutes='"+film2.RuntimeInMinutes+"', BudgetInUSDollar='"+film2.BudgetInUSDollar+"', Rating ='"+film2.Rating+"' WHERE ID=" + id;
            //Console.WriteLine(query);
            //TODO: Studio und Categorie
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Records Inserted Successfully");
                //_Film.Add(film);
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                //_Film.Add(film);
            }
            //_Film.Add(film);
        }
    }
}
