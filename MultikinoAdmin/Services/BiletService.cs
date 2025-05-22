using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MultikinoAdmin.Models;

namespace MultikinoAdmin.Services
{
    public class BiletService
    {
        private readonly DatabaseService _dbService;

        public BiletService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public List<Bilet> GetAllBilety()
        {
            string query = @"SELECT b.BiletId, b.SeansId, b.UzytkownikId, b.MiejsceId, 
                           b.Cena, b.DataZakupu, f.Tytul as TytulFilmu, s.DataSeansu,
                           m.Numer as NumerMiejsca, u.Imie + ' ' + u.Nazwisko as DaneKlienta
                           FROM Bilet b
                           JOIN Seans s ON b.SeansId = s.SeansId
                           JOIN Film f ON s.FilmId = f.FilmId
                           JOIN Miejsce m ON b.MiejsceId = m.MiejsceId
                           JOIN Uzytkownik u ON b.UzytkownikId = u.UzytkownikId
                           ORDER BY b.DataZakupu DESC";
            DataTable result = _dbService.ExecuteQuery(query);
            List<Bilet> bilety = new List<Bilet>();

            foreach (DataRow row in result.Rows)
            {
                bilety.Add(new Bilet
                {
                    BiletId = Convert.ToInt32(row["BiletId"]),
                    SeansId = Convert.ToInt32(row["SeansId"]),
                    UzytkownikId = Convert.ToInt32(row["UzytkownikId"]),
                    MiejsceId = Convert.ToInt32(row["MiejsceId"]),
                    Cena = Convert.ToDecimal(row["Cena"]),
                    DataZakupu = Convert.ToDateTime(row["DataZakupu"]),
                    TytulFilmu = row["TytulFilmu"].ToString(),
                    DataSeansu = Convert.ToDateTime(row["DataSeansu"]),
                    NumerMiejsca = Convert.ToInt32(row["NumerMiejsca"]),
                    DaneKlienta = row["DaneKlienta"].ToString()
                });
            }

            return bilety;
        }

        public Bilet GetBiletById(int biletId)
        {
            string query = @"SELECT b.BiletId, b.SeansId, b.UzytkownikId, b.MiejsceId, 
                           b.Cena, b.DataZakupu, f.Tytul as TytulFilmu, s.DataSeansu,
                           m.Numer as NumerMiejsca, u.Imie + ' ' + u.Nazwisko as DaneKlienta
                           FROM Bilet b
                           JOIN Seans s ON b.SeansId = s.SeansId
                           JOIN Film f ON s.FilmId = f.FilmId
                           JOIN Miejsce m ON b.MiejsceId = m.MiejsceId
                           JOIN Uzytkownik u ON b.UzytkownikId = u.UzytkownikId
                           WHERE b.BiletId = " + biletId;
            DataTable result = _dbService.ExecuteQuery(query);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            return new Bilet
            {
                BiletId = Convert.ToInt32(row["BiletId"]),
                SeansId = Convert.ToInt32(row["SeansId"]),
                UzytkownikId = Convert.ToInt32(row["UzytkownikId"]),
                MiejsceId = Convert.ToInt32(row["MiejsceId"]),
                Cena = Convert.ToDecimal(row["Cena"]),
                DataZakupu = Convert.ToDateTime(row["DataZakupu"]),
                TytulFilmu = row["TytulFilmu"].ToString(),
                DataSeansu = Convert.ToDateTime(row["DataSeansu"]),
                NumerMiejsca = Convert.ToInt32(row["NumerMiejsca"]),
                DaneKlienta = row["DaneKlienta"].ToString()
            };
        }

        public void AddBilet(Bilet bilet)
        {
            // Sprawdź, czy miejsce nie jest już zajęte na ten seans
            string checkQuery = $"SELECT COUNT(*) FROM Bilet WHERE SeansId = {bilet.SeansId} AND MiejsceId = {bilet.MiejsceId}";
            int occupiedCount = Convert.ToInt32(_dbService.ExecuteScalar(checkQuery));

            if (occupiedCount > 0)
            {
                throw new Exception("To miejsce jest już zajęte na wybrany seans.");
            }

            SqlParameter[] parameters = {
                new SqlParameter("@SeansId", bilet.SeansId),
                new SqlParameter("@UzytkownikId", bilet.UzytkownikId),
                new SqlParameter("@Cena", bilet.Cena),
                new SqlParameter("@DataZakupu", bilet.DataZakupu)
            };

            _dbService.ExecuteStoredProcedure("sp_KupBilet", parameters);

            // Pobierz ID ostatnio wstawionego biletu
            int biletId = Convert.ToInt32(_dbService.ExecuteScalar("SELECT MAX(BiletId) FROM Bilet"));

            // Aktualizuj informację o miejscu
            _dbService.ExecuteNonQuery($"UPDATE Bilet SET MiejsceId = {bilet.MiejsceId} WHERE BiletId = {biletId}");
            _dbService.ExecuteNonQuery($"UPDATE Miejsce SET Zajete = 1 WHERE MiejsceId = {bilet.MiejsceId}");
        }

        public void DeleteBilet(int biletId)
        {
            // Pobierz informacje o miejscu, aby je zwolnić po usunięciu biletu
            int miejsceId = Convert.ToInt32(_dbService.ExecuteScalar($"SELECT MiejsceId FROM Bilet WHERE BiletId = {biletId}"));

            SqlParameter[] parameters = {
                new SqlParameter("@BiletId", biletId)
            };

            _dbService.ExecuteStoredProcedure("sp_ZwrocBilet", parameters);

            if (miejsceId > 0)
            {
                // Zwolnij miejsce
                _dbService.ExecuteNonQuery($"UPDATE Miejsce SET Zajete = 0 WHERE MiejsceId = {miejsceId}");
            }
        }
    }
}