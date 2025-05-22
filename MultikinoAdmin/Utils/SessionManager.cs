using MultikinoAdmin.Models;

namespace MultikinoAdmin.Utils
{
    public static class SessionManager
    {
        public static User CurrentUser { get; set; }

        public static bool IsLoggedIn
        {
            get { return CurrentUser != null; }
        }

        public static bool IsAdmin
        {
            get { return IsLoggedIn && CurrentUser.Rola == "Administrator"; }
        }

        public static void Login(User user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}