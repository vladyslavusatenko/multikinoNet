using MultikinoDataAccess.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MultikinoDataAccess.Data
{
    public class MultikinoContext : DbContext
    {
        public MultikinoContext() : base("name=MultikinoDB")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MultikinoContext>());

            if (!Database.Exists())
            {
                Database.Initialize(true);
                ExecuteInitializationScript(); // <-- Twój plik .sql
            }
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Błąd inicjalizacji bazy danych: " + ex.Message,
            //        "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        public DbSet<Uzytkownik> Uzytkownik { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<Seans> Seans { get; set; }
        public DbSet<Miejsce> Miejsce { get; set; }
        public DbSet<Bilet> Bilet { get; set; }
        public DbSet<HistoriaBiletow> HistoriaBiletow { get; set; }
        public DbSet<LogZdarzen> LogZdarzen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void ExecuteInitializationScript()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "MultikinoDataAccess.InitializeDatabase.sql"; // Zmień jeśli plik ma inną nazwę lub folder

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string script = reader.ReadToEnd();
                this.Database.ExecuteSqlCommand(script);
            }
        }
    }
}
