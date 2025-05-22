using System;
using System.Collections.Generic;
using System.Data;
using MultikinoAdmin.Models;
using BCrypt.Net;

namespace MultikinoAdmin.Services
{
    public class UserService
    {
        private readonly DatabaseService _dbService;

        public UserService(DatabaseService dbService)
        {
            _dbService = dbService ?? throw new ArgumentNullException(nameof(dbService));
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return null;

            string query = "SELECT * FROM Uzytkownik WHERE Email = @Email";
            var parameters = new Dictionary<string, object> { { "@Email", email } };
            DataTable result = _dbService.ExecuteQuery(query, parameters);

            if (result.Rows.Count == 0)
                return null;

            DataRow row = result.Rows[0];
            string storedHash = row["Haslo"].ToString();

            bool verified = BCrypt.Net.BCrypt.Verify(password, storedHash);
            if (!verified)
                return null;

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
            if (user == null || string.IsNullOrWhiteSpace(user.Imie) || string.IsNullOrWhiteSpace(user.Nazwisko) ||
                string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Haslo) || string.IsNullOrWhiteSpace(user.Rola))
                throw new ArgumentException("Wszystkie pola użytkownika są wymagane.");

            if (IsEmailTaken(user.Email))
                throw new InvalidOperationException("Email jest już w użyciu.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Haslo);

            string query = "INSERT INTO Uzytkownik (Imie, Nazwisko, Email, Haslo, Rola) VALUES (@Imie, @Nazwisko, @Email, @Haslo, @Rola)";
            var parameters = new Dictionary<string, object>
            {
                { "@Imie", user.Imie },
                { "@Nazwisko", user.Nazwisko },
                { "@Email", user.Email },
                { "@Haslo", hashedPassword },
                { "@Rola", user.Rola }
            };

            _dbService.ExecuteNonQueryWithParams(query, parameters);
        }

        public void UpdateUser(User user)
        {
            if (user == null || user.UzytkownikId <= 0)
                throw new ArgumentException("Nieprawidłowy identyfikator użytkownika.");

            string query = "UPDATE Uzytkownik SET Imie = @Imie, Nazwisko = @Nazwisko, Email = @Email, Rola = @Rola WHERE UzytkownikId = @UzytkownikId";
            var parameters = new Dictionary<string, object>
            {
                { "@UzytkownikId", user.UzytkownikId },
                { "@Imie", user.Imie },
                { "@Nazwisko", user.Nazwisko },
                { "@Email", user.Email },
                { "@Rola", user.Rola }
            };

            _dbService.ExecuteNonQueryWithParams(query, parameters);
        }

        public void DeleteUser(int userId)
        {
            if (userId <= 0)
                throw new ArgumentException("Nieprawidłowy identyfikator użytkownika.");

            string query = "DELETE FROM Uzytkownik WHERE UzytkownikId = @UzytkownikId";
            var parameters = new Dictionary<string, object> { { "@UzytkownikId", userId } };

            _dbService.ExecuteNonQueryWithParams(query, parameters);
        }

        public void ChangePassword(int userId, string newPassword)
        {
            if (userId <= 0 || string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("Nieprawidłowe dane do zmiany hasła.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            string query = "UPDATE Uzytkownik SET Haslo = @Haslo WHERE UzytkownikId = @UzytkownikId";
            var parameters = new Dictionary<string, object>
            {
                { "@UzytkownikId", userId },
                { "@Haslo", hashedPassword }
            };

            _dbService.ExecuteNonQueryWithParams(query, parameters);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
        }

        public void RepairUserPassword(string email, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(newPassword))
                throw new ArgumentException("Nieprawidłowe dane do naprawy hasła.");

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
            string query = "UPDATE Uzytkownik SET Haslo = @Haslo WHERE Email = @Email";
            var parameters = new Dictionary<string, object>
            {
                { "@Email", email },
                { "@Haslo", hashedPassword }
            };

            _dbService.ExecuteNonQueryWithParams(query, parameters);
        }

        private bool IsEmailTaken(string email)
        {
            string query = "SELECT COUNT(*) FROM Uzytkownik WHERE Email = @Email";
            var parameters = new Dictionary<string, object> { { "@Email", email } };
            DataTable result = _dbService.ExecuteQuery(query, parameters);
            return Convert.ToInt32(result.Rows[0][0]) > 0;
        }
    }
}