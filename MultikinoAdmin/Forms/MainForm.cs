using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultikinoAdmin.Services;
using MultikinoAdmin.Utils;


namespace MultikinoAdmin.Forms
{
    public partial class MainForm: Form
    {
        private readonly DatabaseService _dbService;
        private readonly UserService _userService;
        private readonly FilmService _filmService;
        private readonly SalaService _salaService;
        private readonly SeansService _seansService;
        private readonly BiletService _biletService;
        private readonly ReportService _reportService;



        public MainForm()
        {
            // Set culture for the current thread
            

            InitializeComponent();

            _dbService = new DatabaseService();
            _userService = new UserService(_dbService);
            _filmService = new FilmService(_dbService);
            _salaService = new SalaService(_dbService);
            _seansService = new SeansService(_dbService);
            _biletService = new BiletService(_dbService);
            _reportService = new ReportService(_dbService);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Sprawdź, czy użytkownik jest zalogowany
            if (!SessionManager.IsLoggedIn)
            {
                MessageBox.Show("Musisz być zalogowany, aby korzystać z aplikacji!", "Brak autoryzacji",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
                return;
            }

            // Sprawdź połączenie z bazą danych
            bool isConnected = _dbService.TestConnection();
            lblStatusConnection.Text = "Status połączenia: " + (isConnected ? "Połączono" : "Brak połączenia");
            lblStatusConnection.ForeColor = isConnected ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            // Wyświetl informacje o zalogowanym użytkowniku
            lblUserInfo.Text = $"Użytkownik: {SessionManager.CurrentUser.Imie} {SessionManager.CurrentUser.Nazwisko} ({SessionManager.CurrentUser.Rola})";

            // Domyślnie otwórz panel filmów
            menuFilmy_Click_1(null, null);
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
     

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuFilmy_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new FilmyForm(_filmService));

        }

        private void menuSale_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new SaleForm(_salaService));

        }

        private void menuSeanse_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new SeanseForm(_seansService, _filmService, _salaService));

        }

        private void menuBilety_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new BiletyForm(_biletService));

        }

        private void menuRaporty_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new RaportyForm(_reportService));

        }

        private void menuUzytkownicy_Click_1(object sender, EventArgs e)
        {
            LoadFormIntoPanel(new UzytkownicyForm(_userService));

        }

        private void menuWyloguj_Click_1(object sender, EventArgs e)
        {
            SessionManager.Logout();
            this.Close();
            new LoginForm().Show();
        }

        private void lblUserInfo_Click(object sender, EventArgs e)
        {

        }
        private void LoadFormIntoPanel(Form form)
        {
            // Usuń poprzedni formularz
            panelContent.Controls.Clear();

            // Dostosuj nowy formularz
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            // Dodaj i pokaż
            panelContent.Controls.Add(form);
            form.Show();
        }
    }
}
