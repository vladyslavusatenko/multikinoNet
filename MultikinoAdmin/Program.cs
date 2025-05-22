using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using MultikinoAdmin.Forms;
using MultikinoDataAccess.Data;

namespace MultikinoAdmin
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.GetDirectoryName(Application.ExecutablePath));

            // Ustawienia regionalne
            CultureInfo customCulture = (CultureInfo)CultureInfo.InvariantCulture.Clone();
            customCulture.NumberFormat.CurrencySymbol = "zł";
            customCulture.NumberFormat.CurrencyDecimalSeparator = ",";
            customCulture.NumberFormat.CurrencyGroupSeparator = " ";

            Thread.CurrentThread.CurrentCulture = customCulture;
            Thread.CurrentThread.CurrentUICulture = customCulture;


            try
            {
                DatabaseInitializer.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd inicjalizacji bazy danych:\n" + ex.Message,
                    "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
