using System;

namespace MultikinoAdmin.Models
{
    public class User
    {
        public int UzytkownikId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        public string Rola { get; set; }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko}";
        }
    }
}