using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using MultikinoAdmin.Models;
using BCrypt.Net;

namespace MultikinoAdmin.Services
{
    public class UserService
    {
        private readonly DatabaseService _dbService;

        public UserService(DatabaseService dbService)
        {
            _dbService = dbService;
        }

        public User Authenticate(string email, string password)
        {
            // Najpierw znajdź użytkownika na podstawie emaila
            string query = $"SELECT * FROM Uzytkownik WHERE Email = '{email}'";
            DataTable result = _dbService.ExecuteQuery(query);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            string storedHash = row["Haslo"].ToString();

            // Sprawdź, czy hasło jest poprawne
            bool verified = false;
            try
            {
                // Weryfikacja hasła przy użyciu BCrypt
                verified = BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            catch
            {
                // Jeśli wystąpi błąd (np. hash jest w złym formacie), weryfikacja nie powiedzie się
                verified = false;
            }

            if (!verified)
                return null;

            // Jeśli hasło jest poprawne, zwróć użytkownika
            return new User
            {
                UzytkownikId = Convert.ToInt32(row["UzytkownikId"]),
                Imie = row["Imie"].ToString(),
                Nazwisko = row["Nazwisko"].ToString(),
                Email = row["Email"].ToString(),
                Rola = row["Rola"].ToString()
            };
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM Uzytkownik";
            DataTable result = _dbService.ExecuteQuery(query);
            List<User> users = new List<User>();

            foreach (DataRow row in result.Rows)
            {
                users.Add(new User
                {
                    UzytkownikId = Convert.ToInt32(row["UzytkownikId"]),
                    Imie = row["Imie"].ToString(),
                    Nazwisko = row["Nazwisko"].ToString(),
                    Email = row["Email"].ToString(),
                    Rola = row["Rola"].ToString()
                });
            }

            return users;
        }

        public void AddUser(User user)
        {
            // Hashuj hasło przy użyciu BCrypt
            user.Haslo = BCrypt.Net.BCrypt.HashPassword(user.Haslo);

            // Parametryzowane zapytanie
            string query = "INSERT INTO Uzytkownik (Imie, Nazwisko, Email, Haslo, Rola) VALUES (@Imie, @Nazwisko, @Email, @Haslo, @Rola)";

            var parameters = new Dictionary<string, object>
            {
                { "@Imie", user.Imie },
                { "@Nazwisko", user.Nazwisko },
                { "@Email", user.Email },
                { "@Haslo", user.Haslo },
                { "@Rola", user.Rola }
            };

            _dbService.ExecuteNonQueryWithParams(query, parameters);
        }
        //public void AddUser(User user)
        //{
        //    // Zapisz oryginalne hasło do debugowania
        //    string originalPassword = user.Haslo;

        //    try
        //    {
        //        // Hashuj hasło
        //        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Haslo);

        //        // Zapisz hasło po hashowaniu
        //        user.Haslo = hashedPassword;

        //        // Wyświetl informacje debugowania
        //        Console.WriteLine($"Oryginalne hasło: {originalPassword}");
        //        Console.WriteLine($"Zahashowane hasło: {hashedPassword}");

        //        // Reszta kodu...
        //        // Zapisz użytkownika do bazy danych z parametryzowanym zapytaniem
        //    }
        //    catch (Exception ex)
        //    {
        //        // Loguj szczegóły wyjątku
        //        Console.WriteLine($"Błąd podczas hashowania/zapisywania: {ex.Message}");
        //        Console.WriteLine($"Oryginalne hasło: {originalPassword}");
        //        throw; // Rzuć wyjątek dalej
        //    }
        //}

        public void UpdateUser(User user)
        {
            string query = $"UPDATE Uzytkownik SET Imie = '{user.Imie}', Nazwisko = '{user.Nazwisko}', " +
                           $"Email = '{user.Email}', Rola = '{user.Rola}' WHERE UzytkownikId = {user.UzytkownikId}";
            _dbService.ExecuteNonQuery(query);
        }

        public void DeleteUser(int userId)
        {
            string query = $"DELETE FROM Uzytkownik WHERE UzytkownikId = {userId}";
            _dbService.ExecuteNonQuery(query);
        }

        public void ChangePassword(int userId, string newPassword)
        {
            string hashedPassword = HashPassword(newPassword);
            string query = $"UPDATE Uzytkownik SET Haslo = '{hashedPassword}' WHERE UzytkownikId = {userId}";
            _dbService.ExecuteNonQuery(query);
        }

        public string HashPassword(string password)
        {
            // Używamy BCrypt do hashowania hasła
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }
        // UWAGA: Tylko do celów testowych! Usuń przed wdrożeniem produkcyjnym!
        public string TestHashPassword(string password)
        {
            return HashPassword(password);
        }

        public void RepairUserPassword(string email, string newPassword)
        {
            string hashedPassword = HashPassword(newPassword);
            string query = $"UPDATE Uzytkownik SET Haslo = '{hashedPassword}' WHERE Email = '{email}'";
            _dbService.ExecuteNonQuery(query);
        }
    }
}