using System;
using System.Data;
using System.Collections.Generic;

namespace MultikinoAdmin.Services
{
    public class ReportService
    {
        private readonly DatabaseService _dbService;

        public ReportService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public DataTable GetSalesPerFilm()
        {
            string query = "SELECT * FROM v_SprzedazNaFilm ORDER BY Przychody DESC";
            return _dbService.ExecuteQuery(query);
        }

        public DataTable GetHallOccupancy()
        {
            string query = "SELECT * FROM v_ZapelnienieSal";
            return _dbService.ExecuteQuery(query);
        }

        public DataTable GetScreeningsPerDay()
        {
            string query = "SELECT * FROM v_SeanseDzienTygodnia";
            return _dbService.ExecuteQuery(query);
        }

        public DataTable GetDailySales()
        {
            string query = @"SELECT F.Tytul, COUNT(B.BiletId) AS LiczbaBiletow, SUM(B.Cena) AS Przychody
                           FROM Bilet B
                           JOIN Seans S ON B.SeansId = S.SeansId
                           JOIN Film F ON S.FilmId = F.FilmId
                           WHERE CONVERT(date, B.DataZakupu) = CONVERT(date, GETDATE())
                           GROUP BY F.Tytul
                           ORDER BY Przychody DESC";
            return _dbService.ExecuteQuery(query);
        }

        public DataTable GetMonthlySales()
        {
            string query = @"SELECT F.Tytul, COUNT(B.BiletId) AS LiczbaBiletow, SUM(B.Cena) AS Przychody
                           FROM Bilet B
                           JOIN Seans S ON B.SeansId = S.SeansId
                           JOIN Film F ON S.FilmId = F.FilmId
                           WHERE YEAR(B.DataZakupu) = YEAR(GETDATE()) AND MONTH(B.DataZakupu) = MONTH(GETDATE())
                           GROUP BY F.Tytul
                           ORDER BY Przychody DESC";
            return _dbService.ExecuteQuery(query);
        }

        public DataTable GetSalesTrend()
        {
            string query = @"SELECT CONVERT(date, B.DataZakupu) AS DataSprzedazy, 
                           SUM(B.Cena) AS DzienneObroty
                           FROM Bilet B
                           WHERE B.DataZakupu >= DATEADD(day, -30, GETDATE())
                           GROUP BY CONVERT(date, B.DataZakupu)
                           ORDER BY DataSprzedazy";
            return _dbService.ExecuteQuery(query);
        }
    }
}