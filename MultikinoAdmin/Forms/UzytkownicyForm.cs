using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultikinoAdmin.Models;
using MultikinoAdmin.Services;
using MultikinoAdmin.Utils;

namespace MultikinoAdmin.Forms
{
    public partial class UzytkownicyForm: Form
    {
        private readonly UserService _userService;
        private List<User> _users;
        private User currentUser;
        public UzytkownicyForm(UserService userService)
        {
            InitializeComponent();
            _userService = userService;

            // Wypełnij combo z rolami
            comboRola.Items.Clear();
            comboRola.Items.Add("Administrator");
            comboRola.Items.Add("Użytkownik");

            // Na początku ukryj panele do edycji
            groupBoxDetails.Visible = false;
            groupBoxPassword.Visible = false;
        }

        private void UzytkownicyForm_Load(object sender, EventArgs e)
        {
            LoadUsers();
            UpdateButtonStates();
        }

        private void LoadUsers()
        {
            try
            {
                _users = _userService.GetAllUsers();

                dataGridUzytkownicy.DataSource = null;
                dataGridUzytkownicy.DataSource = _users;

                // Ukryj kolumnę z hasłem
                if (dataGridUzytkownicy.Columns.Contains("Haslo"))
                {
                    dataGridUzytkownicy.Columns["Haslo"].Visible = false;
                }

                // Popraw nazwy kolumn
                if (dataGridUzytkownicy.Columns.Contains("UzytkownikId"))
                {
                    dataGridUzytkownicy.Columns["UzytkownikId"].HeaderText = "ID";
                    dataGridUzytkownicy.Columns["UzytkownikId"].Width = 50;
                }
                if (dataGridUzytkownicy.Columns.Contains("Imie"))
                {
                    dataGridUzytkownicy.Columns["Imie"].HeaderText = "Imię";
                }
                if (dataGridUzytkownicy.Columns.Contains("Nazwisko"))
                {
                    dataGridUzytkownicy.Columns["Nazwisko"].HeaderText = "Nazwisko";
                }
                if (dataGridUzytkownicy.Columns.Contains("Email"))
                {
                    dataGridUzytkownicy.Columns["Email"].HeaderText = "E-mail";
                }
                if (dataGridUzytkownicy.Columns.Contains("Rola"))
                {
                    dataGridUzytkownicy.Columns["Rola"].HeaderText = "Rola";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridUzytkownicy_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }
        private void UpdateButtonStates()
        {
            // Aktywuj przyciski edycji tylko gdy jest zaznaczony wiersz
            bool hasSelection = dataGridUzytkownicy.SelectedRows.Count > 0;
            btnEdytuj.Enabled = hasSelection;
            btnUsun.Enabled = hasSelection;
            btnZmienHaslo.Enabled = hasSelection;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            currentUser = null;
            ClearForm();
            lblHaslo.Visible = true;
            txtHaslo.Visible = true;
            groupBoxDetails.Visible = true;
            groupBoxPassword.Visible = false;
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridUzytkownicy.SelectedRows.Count == 0)
                return;

            int userId = Convert.ToInt32(dataGridUzytkownicy.SelectedRows[0].Cells["UzytkownikId"].Value);
            currentUser = _users.Find(u => u.UzytkownikId == userId);

            if (currentUser != null)
            {
                // Wypełnij formularz danymi
                txtImie.Text = currentUser.Imie;
                txtNazwisko.Text = currentUser.Nazwisko;
                txtEmail.Text = currentUser.Email;
                comboRola.SelectedItem = currentUser.Rola;

                // Przy edycji nie pokazujemy pola hasła
                lblHaslo.Visible = false;
                txtHaslo.Visible = false;
                txtHaslo.Text = string.Empty;

                groupBoxDetails.Visible = true;
                groupBoxPassword.Visible = false;
            }
        }

        private void btnZmienHaslo_Click(object sender, EventArgs e)
        {
            if (dataGridUzytkownicy.SelectedRows.Count == 0)
                return;

            int userId = Convert.ToInt32(dataGridUzytkownicy.SelectedRows[0].Cells["UzytkownikId"].Value);
            currentUser = _users.Find(u => u.UzytkownikId == userId);

            if (currentUser != null)
            {
                // Przygotuj panel zmiany hasła
                ClearPasswordForm();
                groupBoxPassword.Visible = true;
                groupBoxDetails.Visible = false;
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridUzytkownicy.SelectedRows.Count == 0)
                return;

            int userId = Convert.ToInt32(dataGridUzytkownicy.SelectedRows[0].Cells["UzytkownikId"].Value);
            string email = dataGridUzytkownicy.SelectedRows[0].Cells["Email"].Value.ToString();

            // Sprawdź, czy to nie jest zalogowany użytkownik
            if (SessionManager.CurrentUser.UzytkownikId == userId)
            {
                MessageBox.Show("Nie możesz usunąć własnego konta!", "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć użytkownika '{email}'?",
                "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _userService.DeleteUser(userId);
                    MessageBox.Show("Użytkownik został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas usuwania użytkownika: " + ex.Message, "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtImie.Text))
            {
                MessageBox.Show("Imię jest wymagane.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNazwisko.Text))
            {
                MessageBox.Show("Nazwisko jest wymagane.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("E-mail jest wymagany.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sprawdź, czy e-mail ma prawidłowy format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Podaj prawidłowy adres e-mail.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboRola.SelectedItem == null)
            {
                MessageBox.Show("Wybierz rolę użytkownika.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dla nowego użytkownika hasło jest wymagane
            if (currentUser == null && string.IsNullOrWhiteSpace(txtHaslo.Text))
            {
                MessageBox.Show("Hasło jest wymagane.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Przygotuj obiekt użytkownika
                User user = currentUser ?? new User();
                user.Imie = txtImie.Text;
                user.Nazwisko = txtNazwisko.Text;
                user.Email = txtEmail.Text;
                user.Rola = comboRola.SelectedItem.ToString();

                if (currentUser == null)
                {
                    // Dodaj nowego użytkownika (z hasłem)
                    user.Haslo = txtHaslo.Text;
                    _userService.AddUser(user);
                    MessageBox.Show("Użytkownik został dodany.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Aktualizuj istniejącego użytkownika (bez zmiany hasła)
                    _userService.UpdateUser(user);
                    MessageBox.Show("Użytkownik został zaktualizowany.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Odśwież listę użytkowników
                LoadUsers();
                groupBoxDetails.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania użytkownika: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            groupBoxDetails.Visible = false;
        }

        private void btnZapiszHaslo_Click(object sender, EventArgs e)
        {
            if (currentUser == null)
                return;

            // Walidacja danych
            if (string.IsNullOrWhiteSpace(txtNoweHaslo.Text))
            {
                MessageBox.Show("Nowe hasło jest wymagane.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNoweHaslo.Text != txtPotwierdzHaslo.Text)
            {
                MessageBox.Show("Hasła muszą być identyczne.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Zmień hasło użytkownika
                _userService.ChangePassword(currentUser.UzytkownikId, txtNoweHaslo.Text);
                MessageBox.Show("Hasło zostało zmienione.", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                groupBoxPassword.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zmiany hasła: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnulujHaslo_Click(object sender, EventArgs e)
        {
            groupBoxPassword.Visible = false;

        }
        private void ClearForm()
        {
            txtImie.Text = string.Empty;
            txtNazwisko.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtHaslo.Text = string.Empty;
            comboRola.SelectedIndex = -1;
        }
        private void ClearPasswordForm()
        {
            txtNoweHaslo.Text = string.Empty;
            txtPotwierdzHaslo.Text = string.Empty;
        }
        private bool IsValidEmail(string email)
        {
            // Prosty regex do walidacji adresu e-mail
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
