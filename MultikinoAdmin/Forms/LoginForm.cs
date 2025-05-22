using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultikinoAdmin.Services;
using MultikinoAdmin.Utils;

namespace MultikinoAdmin.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        private readonly DatabaseService _dbService;
        public LoginForm()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _userService = new UserService(_dbService);
            //_userService.RepairUserPassword("test@email.com", "123");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            bool isConnected = _dbService.TestConnection();
            if (!isConnected)
            {
                lblStatus.Text = "Brak połączenia z bazą danych!";
                btnLogin.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {

                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                // Walidacja danych
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                {
                    lblStatus.Text = "Wprowadź email i hasło!";
                    return;
                }

                //Próba autentykacji
                var user = _userService.Authenticate(email, password);
                if (user == null)
                {
                    lblStatus.Text = "Nieprawidłowy email lub hasło!";
                    return;
                }

                // Sprawdź rolę
                if (user.Rola != "Administrator")
                {
                    lblStatus.Text = "Brak uprawnień administratora!";
                    return;
                }

                // Zapisz dane użytkownika w sesji
                SessionManager.Login(user);

                //Otwórz główne okno aplikacji
                var mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Błąd logowania: " + ex.Message;
            }

        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
