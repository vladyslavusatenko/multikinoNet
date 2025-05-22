using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MultikinoAdmin.Models;

namespace MultikinoAdmin.Services
{
    public class FilmService
    {
        private readonly DatabaseService _dbService;

        public FilmService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Film> GetAllFilms()
        {
            string query = "SELECT * FROM Film";
            DataTable result = _dbService.ExecuteQuery(query);
            List<Film> films = new List<Film>();

            foreach (DataRow row in result.Rows)
            {
                Film film = new Film
                {
                    FilmId = Convert.ToInt32(row["FilmId"]),
                    Tytul = row["Tytul"].ToString(),
                    Gatunek = row["Gatunek"].ToString(),
                    Opis = row["Opis"].ToString(),
                    CzasTrwania = Convert.ToInt32(row["CzasTrwania"])
                };

                if (row["Plakat"] != DBNull.Value)
                {
                    film.Plakat = (byte[])row["Plakat"];
                }

                films.Add(film);
            }

            return films;
        }

        public Film GetFilmById(int filmId)
        {
            string query = $"SELECT * FROM Film WHERE FilmId = {filmId}";
            DataTable result = _dbService.ExecuteQuery(query);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            Film film = new Film
            {
                FilmId = Convert.ToInt32(row["FilmId"]),
                Tytul = row["Tytul"].ToString(),
                Gatunek = row["Gatunek"].ToString(),
                Opis = row["Opis"].ToString(),
                CzasTrwania = Convert.ToInt32(row["CzasTrwania"])
            };

            if (row["Plakat"] != DBNull.Value)
            {
                film.Plakat = (byte[])row["Plakat"];
            }

            return film;
        }

        public void AddFilm(Film film)
        {
            string query = "INSERT INTO Film (Tytul, Gatunek, Opis, CzasTrwania";
            string values = $"VALUES ('{film.Tytul}', '{film.Gatunek}', '{film.Opis}', {film.CzasTrwania}";

            if (film.Plakat != null)
            {
                query += ", Plakat";
                values += ", @Plakat";
            }

            query += ") " + values + ")";

            using (SqlConnection connection = _dbService.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (film.Plakat != null)
                {
                    command.Parameters.Add("@Plakat", SqlDbType.VarBinary).Value = film.Plakat;
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd podczas dodawania filmu: " + ex.Message, ex);
                }
            }
        }

        public void UpdateFilm(Film film)
        {
            string query = $"UPDATE Film SET Tytul = '{film.Tytul}', Gatunek = '{film.Gatunek}', " +
                           $"Opis = '{film.Opis}', CzasTrwania = {film.CzasTrwania}";

            if (film.Plakat != null)
            {
                query += ", Plakat = @Plakat";
            }

            query += $" WHERE FilmId = {film.FilmId}";

            using (SqlConnection connection = _dbService.GetConnection())
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (film.Plakat != null)
                {
                    command.Parameters.Add("@Plakat", SqlDbType.VarBinary).Value = film.Plakat;
                }

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd podczas aktualizacji filmu: " + ex.Message, ex);
                }
            }
        }

        public void DeleteFilm(int filmId)
        {
            string query = $"DELETE FROM Film WHERE FilmId = {filmId}";
            try
            {
                _dbService.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception("Nie można usunąć filmu, który ma przypisane seanse. " + ex.Message, ex);
            }
        }
    }
}