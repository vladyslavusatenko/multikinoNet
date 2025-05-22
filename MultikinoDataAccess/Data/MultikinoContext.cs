using MultikinoDataAccess.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;

namespace MultikinoDataAccess.Data
{
    public class MultikinoContext : DbContext
    {
        public MultikinoContext() : base("name=MultikinoEntities")
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
            var resourceName = "MultikinoDataAccess.InitializeDatabase.sql"; // Zmień jeśli jest w podfolderze

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string script = reader.ReadToEnd();

                // DZIELIMY po "GO" (musi być na osobnej linii)
                var batches = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

                foreach (var batch in batches)
                {
                    string trimmed = batch.Trim();
                    if (!string.IsNullOrEmpty(trimmed))
                    {
                        try
                        {
                            this.Database.ExecuteSqlCommand(trimmed);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Błąd w batchu SQL:\n{trimmed.Substring(0, Math.Min(300, trimmed.Length))}\n\n{ex.Message}", ex);
                        }
                    }
                }
            }
        }
    }
}
