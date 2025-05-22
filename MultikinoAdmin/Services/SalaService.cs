using System;
using System.Collections.Generic;
using System.Data;
using MultikinoAdmin.Models;

namespace MultikinoAdmin.Services
{
    public class SalaService
    {
        private readonly DatabaseService _dbService;

        public SalaService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Sala> GetAllSale()
        {
            string query = "SELECT * FROM Sala";
            DataTable result = _dbService.ExecuteQuery(query);
            List<Sala> sale = new List<Sala>();

            foreach (DataRow row in result.Rows)
            {
                sale.Add(new Sala
                {
                    SalaId = Convert.ToInt32(row["SalaId"]),
                    Nazwa = row["Nazwa"].ToString(),
                    LiczbaMiejsc = Convert.ToInt32(row["LiczbaMiejsc"])
                });
            }

            return sale;
        }

        public Sala GetSalaById(int salaId)
        {
            string query = $"SELECT * FROM Sala WHERE SalaId = {salaId}";
            DataTable result = _dbService.ExecuteQuery(query);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            return new Sala
            {
                SalaId = Convert.ToInt32(row["SalaId"]),
                Nazwa = row["Nazwa"].ToString(),
                LiczbaMiejsc = Convert.ToInt32(row["LiczbaMiejsc"])
            };
        }

        public void AddSala(Sala sala)
        {
            string query = $"INSERT INTO Sala (Nazwa, LiczbaMiejsc) VALUES ('{sala.Nazwa}', {sala.LiczbaMiejsc})";
            int salaId = Convert.ToInt32(_dbService.ExecuteScalar(query + "; SELECT SCOPE_IDENTITY();"));

            // Dodaj miejsca dla nowej sali
            for (int i = 1; i <= sala.LiczbaMiejsc; i++)
            {
                string miejsceQuery = $"INSERT INTO Miejsce (SalaId, Numer, Zajete) VALUES ({salaId}, {i}, 0)";
                _dbService.ExecuteNonQuery(miejsceQuery);
            }
        }

        public void UpdateSala(Sala sala)
        {
            // Pobierz aktualną liczbę miejsc
            string currentSeatsQuery = $"SELECT LiczbaMiejsc FROM Sala WHERE SalaId = {sala.SalaId}";
            int currentSeats = Convert.ToInt32(_dbService.ExecuteScalar(currentSeatsQuery));

            // Aktualizuj salę
            string query = $"UPDATE Sala SET Nazwa = '{sala.Nazwa}', LiczbaMiejsc = {sala.LiczbaMiejsc} WHERE SalaId = {sala.SalaId}";
            _dbService.ExecuteNonQuery(query);

            // Jeśli zwiększono liczbę miejsc, dodaj nowe miejsca
            if (sala.LiczbaMiejsc > currentSeats)
            {
                for (int i = currentSeats + 1; i <= sala.LiczbaMiejsc; i++)
                {
                    string miejsceQuery = $"INSERT INTO Miejsce (SalaId, Numer, Zajete) VALUES ({sala.SalaId}, {i}, 0)";
                    _dbService.ExecuteNonQuery(miejsceQuery);
                }
            }
            // Jeśli zmniejszono liczbę miejsc, usuń nadmiarowe (tylko te, które nie są wykorzystywane w biletach)
            else if (sala.LiczbaMiejsc < currentSeats)
            {
                string deleteQuery = $@"DELETE FROM Miejsce 
                                      WHERE SalaId = {sala.SalaId} 
                                      AND Numer > {sala.LiczbaMiejsc}
                                      AND MiejsceId NOT IN (SELECT MiejsceId FROM Bilet WHERE MiejsceId IS NOT NULL)";
                _dbService.ExecuteNonQuery(deleteQuery);
            }
        }

        public void DeleteSala(int salaId)
        {
            // Sprawdź, czy sala ma przypisane seanse
            string checkQuery = $"SELECT COUNT(*) FROM Seans WHERE SalaId = {salaId}";
            int seansCount = Convert.ToInt32(_dbService.ExecuteScalar(checkQuery));

            if (seansCount > 0)
            {
                throw new Exception("Nie można usunąć sali, która ma przypisane seanse.");
            }

            // Usuń miejsca dla tej sali
            string deleteMiejscaQuery = $"DELETE FROM Miejsce WHERE SalaId = {salaId}";
            _dbService.ExecuteNonQuery(deleteMiejscaQuery);

            // Usuń salę
            string deleteSalaQuery = $"DELETE FROM Sala WHERE SalaId = {salaId}";
            _dbService.ExecuteNonQuery(deleteSalaQuery);
        }

        public List<Miejsce> GetMiejscaForSala(int salaId)
        {
            string query = $"SELECT * FROM Miejsce WHERE SalaId = {salaId}";
            DataTable result = _dbService.ExecuteQuery(query);
            List<Miejsce> miejsca = new List<Miejsce>();

            foreach (DataRow row in result.Rows)
            {
                miejsca.Add(new Miejsce
                {
                    MiejsceId = Convert.ToInt32(row["MiejsceId"]),
                    SalaId = Convert.ToInt32(row["SalaId"]),
                    Numer = Convert.ToInt32(row["Numer"]),
                    Zajete = Convert.ToBoolean(row["Zajete"])
                });
            }

            return miejsca;
        }
    }
}