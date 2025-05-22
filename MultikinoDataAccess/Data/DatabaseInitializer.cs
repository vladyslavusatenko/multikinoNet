using System.Data.Entity;

namespace MultikinoDataAccess.Data
{
    public static class DatabaseInitializer
    {
        public static void InitializeDatabase()
        {
            using (var context = new MultikinoContext())
            {
                if (!context.Database.Exists())
                {
                    context.Database.Create();
                    context.ExecuteInitializationScript();
                }
                

            }
        }
    }
}