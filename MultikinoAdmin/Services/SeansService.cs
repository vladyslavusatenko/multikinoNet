using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MultikinoAdmin.Models;

namespace MultikinoAdmin.Services
{
    public class SeansService
    {
        private readonly DatabaseService _dbService;

        public SeansService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Seans> GetAllSeanse()
        {
            string query = @"SELECT s.SeansId, s.FilmId, f.Tytul as TytulFilmu, 
                            s.SalaId, sa.Nazwa as NazwaSali, s.DataSeansu
                            FROM Seans s
                            JOIN Film f ON s.FilmId = f.FilmId
                            JOIN Sala sa ON s.SalaId = sa.SalaId
                            ORDER BY s.DataSeansu DESC";
            DataTable result = _dbService.ExecuteQuery(query);
            List<Seans> seanse = new List<Seans>();

            foreach (DataRow row in result.Rows)
            {
                seanse.Add(new Seans
                {
                    SeansId = Convert.ToInt32(row["SeansId"]),
                    FilmId = Convert.ToInt32(row["FilmId"]),
                    TytulFilmu = row["TytulFilmu"].ToString(),
                    SalaId = Convert.ToInt32(row["SalaId"]),
                    NazwaSali = row["NazwaSali"].ToString(),
                    DataSeansu = Convert.ToDateTime(row["DataSeansu"])
                });
            }

            return seanse;
        }

        public List<Seans> GetActiveSeanse()
        {
            string query = @"SELECT s.SeansId, s.FilmId, f.Tytul as TytulFilmu, 
                            s.SalaId, sa.Nazwa as NazwaSali, s.DataSeansu
                            FROM Seans s
                            JOIN Film f ON s.FilmId = f.FilmId
                            JOIN Sala sa ON s.SalaId = sa.SalaId
                            WHERE s.DataSeansu > GETDATE()
                            ORDER BY s.DataSeansu";
            DataTable result = _dbService.ExecuteQuery(query);
            List<Seans> seanse = new List<Seans>();

            foreach (DataRow row in result.Rows)
            {
                seanse.Add(new Seans
                {
                    SeansId = Convert.ToInt32(row["SeansId"]),
                    FilmId = Convert.ToInt32(row["FilmId"]),
                    TytulFilmu = row["TytulFilmu"].ToString(),
                    SalaId = Convert.ToInt32(row["SalaId"]),
                    NazwaSali = row["NazwaSali"].ToString(),
                    DataSeansu = Convert.ToDateTime(row["DataSeansu"])
                });
            }

            return seanse;
        }

        public Seans GetSeansById(int seansId)
        {
            string query = @"SELECT s.SeansId, s.FilmId, f.Tytul as TytulFilmu, 
                            s.SalaId, sa.Nazwa as NazwaSali, s.DataSeansu
                            FROM Seans s
                            JOIN Film f ON s.FilmId = f.FilmId
                            JOIN Sala sa ON s.SalaId = sa.SalaId
                            WHERE s.SeansId = " + seansId;
            DataTable result = _dbService.ExecuteQuery(query);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            return new Seans
            {
                SeansId = Convert.ToInt32(row["SeansId"]),
                FilmId = Convert.ToInt32(row["FilmId"]),
                TytulFilmu = row["TytulFilmu"].ToString(),
                SalaId = Convert.ToInt32(row["SalaId"]),
                NazwaSali = row["NazwaSali"].ToString(),
                DataSeansu = Convert.ToDateTime(row["DataSeansu"])
            };
        }

        public void AddSeans(Seans seans)
        {
            // Sprawdź, czy sala nie jest już zajęta w tym czasie
            if (IsSalaOccupied(seans.SalaId, seans.DataSeansu, null))
            {
                throw new Exception("Sala jest już zajęta w wybranym terminie.");
            }

            using (SqlConnection connection = _dbService.GetConnection())
            {
                string query = "INSERT INTO Seans (FilmId, SalaId, DataSeansu) VALUES (@FilmId, @SalaId, @DataSeansu)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilmId", seans.FilmId);
                    command.Parameters.AddWithValue("@SalaId", seans.SalaId);
                    command.Parameters.AddWithValue("@DataSeansu", seans.DataSeansu);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Błąd podczas dodawania seansu: " + ex.Message, ex);
                    }
                }
            }
        }

        public void UpdateSeans(Seans seans)
        {
            // Sprawdź, czy sala nie jest już zajęta w tym czasie (z wyjątkiem obecnego seansu)
            if (IsSalaOccupied(seans.SalaId, seans.DataSeansu, seans.SeansId))
            {
                throw new Exception("Sala jest już zajęta w wybranym terminie.");
            }

            using (SqlConnection connection = _dbService.GetConnection())
            {
                string query = "UPDATE Seans SET FilmId = @FilmId, SalaId = @SalaId, DataSeansu = @DataSeansu WHERE SeansId = @SeansId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FilmId", seans.FilmId);
                    command.Parameters.AddWithValue("@SalaId", seans.SalaId);
                    command.Parameters.AddWithValue("@DataSeansu", seans.DataSeansu);
                    command.Parameters.AddWithValue("@SeansId", seans.SeansId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Błąd podczas aktualizacji seansu: " + ex.Message, ex);
                    }
                }
            }
        }

        public void DeleteSeans(int seansId)
        {
            // Sprawdź, czy istnieją bilety na ten seans
            string checkQuery = $"SELECT COUNT(*) FROM Bilet WHERE SeansId = {seansId}";
            int biletCount = Convert.ToInt32(_dbService.ExecuteScalar(checkQuery));

            if (biletCount > 0)
            {
                throw new Exception("Nie można usunąć seansu, na który zostały już sprzedane bilety.");
            }

            SqlParameter[] parameters = {
                new SqlParameter("@SeansId", seansId)
            };

            _dbService.ExecuteStoredProcedure("sp_UsunSeans", parameters);
        }

        private bool IsSalaOccupied(int salaId, DateTime dataSeansu, int? excludeSeansId)
        {
            // Sprawdź, czy data mieści się w dozwolonym zakresie SQL Server
            DateTime minSqlDate = new DateTime(1753, 1, 1);
            DateTime maxSqlDate = new DateTime(9999, 12, 31, 23, 59, 59);

            if (dataSeansu < minSqlDate || dataSeansu > maxSqlDate)
            {
                throw new Exception($"Data seansu musi być między {minSqlDate.ToString("dd.MM.yyyy")} a {maxSqlDate.ToString("dd.MM.yyyy")}");
            }

            // Dalej jak było...
            using (SqlConnection connection = _dbService.GetConnection())
            {
                // Zmodyfikuj zapytanie, aby uniknąć przekroczenia zakresu daty
                string query = @"
            SELECT COUNT(*) FROM Seans s
            JOIN Film f ON s.FilmId = f.FilmId
            WHERE s.SalaId = @SalaId 
            AND (
                (s.DataSeansu <= @DataSeansu AND DATEADD(MINUTE, 
                    CASE WHEN (f.CzasTrwania + 30) > 527040 THEN 527040 ELSE (f.CzasTrwania + 30) END, 
                    s.DataSeansu) > @DataSeansu)
                OR
                (s.DataSeansu >= @DataSeansu AND s.DataSeansu < DATEADD(MINUTE, 
                    CASE WHEN 
                        ((SELECT CzasTrwania FROM Film WHERE FilmId = 
                            (SELECT ISNULL(FilmId, 0) FROM Seans WHERE SeansId = @CurrentSeansId)) + 30) > 527040 
                    THEN 527040 
                    ELSE ((SELECT ISNULL(CzasTrwania, 120) FROM Film WHERE FilmId = 
                            (SELECT ISNULL(FilmId, 0) FROM Seans WHERE SeansId = @CurrentSeansId)) + 30) 
                    END, 
                    @DataSeansu))
            )";

                if (excludeSeansId.HasValue)
                {
                    query += " AND s.SeansId <> @ExcludeSeansId";
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SalaId", salaId);
                    command.Parameters.AddWithValue("@DataSeansu", dataSeansu);
                    command.Parameters.AddWithValue("@CurrentSeansId", excludeSeansId.HasValue ? excludeSeansId.Value : 0);

                    if (excludeSeansId.HasValue)
                    {
                        command.Parameters.AddWithValue("@ExcludeSeansId", excludeSeansId.Value);
                    }

                    try
                    {
                        connection.Open();
                        int conflictCount = (int)command.ExecuteScalar();
                        return conflictCount > 0;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Błąd podczas sprawdzania dostępności sali: " + ex.Message, ex);
                    }
                }
            }
        }

        public DataTable GetDailySalesReport()
        {
            return _dbService.ExecuteQuery("EXEC sp_GenerujRaportDzienny");
        }

        public DataTable GetMonthlySalesReport()
        {
            return _dbService.ExecuteQuery("EXEC sp_GenerujRaportMiesieczny");
        }
    }
}