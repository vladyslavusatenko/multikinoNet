using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultikinoAdmin.Models;
using MultikinoAdmin.Services;

namespace MultikinoAdmin.Forms
{
    public partial class FilmyForm: Form
    {
        private readonly FilmService _filmService;
        private List<Film> _filmy;
        private Film currentFilm;
        private byte[] selectedImageBytes;
        public FilmyForm(FilmService filmService)
        {
            InitializeComponent();
            _filmService = filmService;
        }
        private void LoadFilmy()
        {
            try
            {
                _filmy = _filmService.GetAllFilms();

                dataGridFilmy.DataSource = null;
                dataGridFilmy.DataSource = _filmy;

                // Ukryj kolumnę z posterem (dane binarne)
                if (dataGridFilmy.Columns.Contains("Plakat"))
                {
                    dataGridFilmy.Columns["Plakat"].Visible = false;
                }

                // Popraw nazwy kolumn
                if (dataGridFilmy.Columns.Contains("FilmId"))
                {
                    dataGridFilmy.Columns["FilmId"].HeaderText = "ID";
                }
                if (dataGridFilmy.Columns.Contains("Tytul"))
                {
                    dataGridFilmy.Columns["Tytul"].HeaderText = "Tytuł";
                }
                if (dataGridFilmy.Columns.Contains("CzasTrwania"))
                {
                    dataGridFilmy.Columns["CzasTrwania"].HeaderText = "Czas trwania (min)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FilmyForm_Load(object sender, EventArgs e)
        {
            LoadFilmy();
            groupBoxDetails.Visible = false;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            currentFilm = null;
            ClearForm();
            groupBoxDetails.Visible = true;
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridFilmy.SelectedRows.Count == 0)
                return;

            int filmId = Convert.ToInt32(dataGridFilmy.SelectedRows[0].Cells["FilmId"].Value);
            currentFilm = _filmService.GetFilmById(filmId);

            if (currentFilm != null)
            {
                // Wypełnij formularz danymi
                txtTytul.Text = currentFilm.Tytul;
                txtGatunek.Text = currentFilm.Gatunek;
                txtOpis.Text = currentFilm.Opis;
                numCzasTrwania.Value = currentFilm.CzasTrwania;

                if (currentFilm.Plakat != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(currentFilm.Plakat))
                    {
                        try
                        {
                            picPlakat.Image = System.Drawing.Image.FromStream(ms);
                            selectedImageBytes = currentFilm.Plakat;
                        }
                        catch
                        {
                            picPlakat.Image = null;
                            selectedImageBytes = null;
                        }
                    }
                }
                else
                {
                    picPlakat.Image = null;
                    selectedImageBytes = null;
                }

                groupBoxDetails.Visible = true;
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridFilmy.SelectedRows.Count == 0)
                return;

            int filmId = Convert.ToInt32(dataGridFilmy.SelectedRows[0].Cells["FilmId"].Value);
            string tytul = dataGridFilmy.SelectedRows[0].Cells["Tytul"].Value.ToString();

            DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć film '{tytul}'?",
                "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _filmService.DeleteFilm(filmId);
                    MessageBox.Show("Film został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadFilmy();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas usuwania filmu: " + ex.Message, "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnWybierzPlakat_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Pliki obrazów|*.jpg;*.jpeg;*.png;*.gif|Wszystkie pliki|*.*";
                openFileDialog.Title = "Wybierz plakat filmu";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Wczytaj obraz i konwertuj do tabeli bajtów
                        System.Drawing.Image img = System.Drawing.Image.FromFile(openFileDialog.FileName);
                        picPlakat.Image = img;

                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            img.Save(ms, img.RawFormat);
                            selectedImageBytes = ms.ToArray();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas wczytywania obrazu: " + ex.Message, "Błąd",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTytul.Text))
            {
                MessageBox.Show("Tytuł filmu jest wymagany.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGatunek.Text))
            {
                MessageBox.Show("Gatunek filmu jest wymagany.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Przygotuj obiekt filmu
                Film film = currentFilm ?? new Film();
                film.Tytul = txtTytul.Text;
                film.Gatunek = txtGatunek.Text;
                film.Opis = txtOpis.Text;
                film.CzasTrwania = (int)numCzasTrwania.Value;
                film.Plakat = selectedImageBytes;

                if (currentFilm == null)
                {
                    // Dodaj nowy film
                    _filmService.AddFilm(film);
                    MessageBox.Show("Film został dodany.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Aktualizuj istniejący film
                    _filmService.UpdateFilm(film);
                    MessageBox.Show("Film został zaktualizowany.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Odśwież listę filmów
                LoadFilmy();
                groupBoxDetails.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania filmu: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            groupBoxDetails.Visible = false;

        }
        private void ClearForm()
        {
            txtTytul.Text = string.Empty;
            txtGatunek.Text = string.Empty;
            txtOpis.Text = string.Empty;
            numCzasTrwania.Value = 90;
            picPlakat.Image = null;
            selectedImageBytes = null;
        }

        private void dataGridFilmy_SelectionChanged(object sender, EventArgs e)
        {
            btnEdytuj.Enabled = dataGridFilmy.SelectedRows.Count > 0;
            btnUsun.Enabled = dataGridFilmy.SelectedRows.Count > 0;
        }

        private void groupBoxDetails_Resize(object sender, EventArgs e)
        {

        }
    }
}
