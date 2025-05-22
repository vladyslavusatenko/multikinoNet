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
    public partial class SeanseForm: Form
    {
        private readonly SeansService _seansService;
        private readonly FilmService _filmService;
        private readonly SalaService _salaService;
        private List<Seans> _seanse;
        private List<Film> _filmy;
        private List<Sala> _sale;
        private Seans currentSeans;


        public SeanseForm(SeansService seansService, FilmService filmService, SalaService salaService)
        {
            var culture = new System.Globalization.CultureInfo("en-EN");
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
            InitializeComponent();
            _seansService = seansService;
            _filmService = filmService;
            _salaService = salaService;
        }

        private void lblFilm_Click(object sender, EventArgs e)
        {

        }

        private void SeanseForm_Load(object sender, EventArgs e)
        {
            LoadComboboxData();
            LoadSeanse();
        }

        private void LoadComboboxData()
        {
            try
            {
                // Załaduj filmy do combobox
                _filmy = _filmService.GetAllFilms();
                comboFilmy.DataSource = null;
                comboFilmy.DisplayMember = "Tytul";
                comboFilmy.ValueMember = "FilmId";
                comboFilmy.DataSource = _filmy;

                // Załaduj sale do combobox
                _sale = _salaService.GetAllSale();
                comboSale.DataSource = null;
                comboSale.DisplayMember = "Nazwa";
                comboSale.ValueMember = "SalaId";
                comboSale.DataSource = _sale;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSeanse()
        {
            try
            {
                if (rbActive.Checked)
                {
                    _seanse = _seansService.GetActiveSeanse();
                }
                else
                {
                    _seanse = _seansService.GetAllSeanse();
                }

                dataGridSeanse.DataSource = null;
                dataGridSeanse.DataSource = _seanse;

                // Ukryj niepotrzebne kolumny
                if (dataGridSeanse.Columns.Contains("FilmId"))
                {
                    dataGridSeanse.Columns["FilmId"].Visible = false;
                }
                if (dataGridSeanse.Columns.Contains("SalaId"))
                {
                    dataGridSeanse.Columns["SalaId"].Visible = false;
                }

                // Popraw nazwy kolumn
                if (dataGridSeanse.Columns.Contains("SeansId"))
                {
                    dataGridSeanse.Columns["SeansId"].HeaderText = "ID";
                }
                if (dataGridSeanse.Columns.Contains("TytulFilmu"))
                {
                    dataGridSeanse.Columns["TytulFilmu"].HeaderText = "Film";
                }
                if (dataGridSeanse.Columns.Contains("NazwaSali"))
                {
                    dataGridSeanse.Columns["NazwaSali"].HeaderText = "Sala";
                }
                if (dataGridSeanse.Columns.Contains("DataSeansu"))
                {
                    dataGridSeanse.Columns["DataSeansu"].HeaderText = "Data i godzina";
                    dataGridSeanse.Columns["DataSeansu"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridSeanse_SelectionChanged(object sender, EventArgs e)
        {
            btnEdytuj.Enabled = dataGridSeanse.SelectedRows.Count > 0;
            btnUsun.Enabled = dataGridSeanse.SelectedRows.Count > 0;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            currentSeans = null;
            ClearForm();
            groupBoxDetails.Visible = true;
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridSeanse.SelectedRows.Count == 0)
                return;

            int seansId = Convert.ToInt32(dataGridSeanse.SelectedRows[0].Cells["SeansId"].Value);
            currentSeans = _seansService.GetSeansById(seansId);

            if (currentSeans != null)
            {
                // Wypełnij formularz danymi
                comboFilmy.SelectedValue = currentSeans.FilmId;
                comboSale.SelectedValue = currentSeans.SalaId;
                datePickerSeans.Value = currentSeans.DataSeansu.Date;
                timePickerSeans.Value = currentSeans.DataSeansu;

                groupBoxDetails.Visible = true;
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridSeanse.SelectedRows.Count == 0)
                return;

            int seansId = Convert.ToInt32(dataGridSeanse.SelectedRows[0].Cells["SeansId"].Value);
            string filmTytul = dataGridSeanse.SelectedRows[0].Cells["TytulFilmu"].Value.ToString();
            DateTime dataSeansu = Convert.ToDateTime(dataGridSeanse.SelectedRows[0].Cells["DataSeansu"].Value);

            DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć seans filmu '{filmTytul}' z dnia {dataSeansu:dd.MM.yyyy HH:mm}?",
                "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _seansService.DeleteSeans(seansId);
                    MessageBox.Show("Seans został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSeanse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas usuwania seansu: " + ex.Message, "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (comboFilmy.SelectedItem == null)
            {
                MessageBox.Show("Wybierz film.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (comboSale.SelectedItem == null)
            {
                MessageBox.Show("Wybierz salę.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime dataSeansu = datePickerSeans.Value.Date;
                DateTime godzinaSeansu = timePickerSeans.Value;
                DateTime fullDateTimeSeans = new DateTime(
                    dataSeansu.Year, dataSeansu.Month, dataSeansu.Day,
                    godzinaSeansu.Hour, godzinaSeansu.Minute, 0);

                // Sprawdź, czy data mieści się w zakresie SQL Server
                if (fullDateTimeSeans < new DateTime(1753, 1, 1) ||
                    fullDateTimeSeans > new DateTime(9999, 12, 31, 23, 59, 59))
                {
                    MessageBox.Show("Data seansu musi być między 01.01.1753 a 31.12.9999.",
                        "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Sprawdź, czy data seansu nie jest w przeszłości
                if (fullDateTimeSeans < DateTime.Now)
                {
                    MessageBox.Show("Data seansu nie może być w przeszłości.",
                        "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Przygotuj obiekt seansu
                Seans seans = currentSeans ?? new Seans();
                seans.FilmId = (int)comboFilmy.SelectedValue;
                seans.SalaId = (int)comboSale.SelectedValue;

                // Połącz datę i godzinę
                seans.DataSeansu = new DateTime(
                    dataSeansu.Year, dataSeansu.Month, dataSeansu.Day,
                    godzinaSeansu.Hour, godzinaSeansu.Minute, 0);

                if (currentSeans == null)
                {
                    // Dodaj nowy seans
                    _seansService.AddSeans(seans);
                    MessageBox.Show("Seans został dodany.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Aktualizuj istniejący seans
                    _seansService.UpdateSeans(seans);
                    MessageBox.Show("Seans został zaktualizowany.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Odśwież listę seansów
                LoadSeanse();
                groupBoxDetails.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania seansu: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            groupBoxDetails.Visible = false;

        }

        private void ClearForm()
        {
            comboFilmy.SelectedIndex = comboFilmy.Items.Count > 0 ? 0 : -1;
            comboSale.SelectedIndex = comboSale.Items.Count > 0 ? 0 : -1;
            datePickerSeans.Value = DateTime.Today;
            timePickerSeans.Value = DateTime.Now;
        }

        private void rbActive_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActive.Checked)
            {
                LoadSeanse();
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                LoadSeanse();
            }
        }
    }
}
