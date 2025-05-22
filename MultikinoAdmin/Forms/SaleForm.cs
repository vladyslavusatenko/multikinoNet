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
    public partial class SaleForm: Form
    {
        private readonly SalaService _salaService;
        private List<Sala> _sale;
        private Sala currentSala;
        private List<Miejsce> currentMiejsca;
        public SaleForm(SalaService salaService)
        {
            InitializeComponent();
            _salaService = salaService;
        }

        private void SaleForm_Load(object sender, EventArgs e)
        {
            LoadSale();

        }
        private void LoadSale()
        {
            try
            {
                _sale = _salaService.GetAllSale();

                dataGridSale.DataSource = null;
                dataGridSale.DataSource = _sale;

                // Popraw nazwy kolumn
                if (dataGridSale.Columns.Contains("SalaId"))
                {
                    dataGridSale.Columns["SalaId"].HeaderText = "ID";
                }
                if (dataGridSale.Columns.Contains("LiczbaMiejsc"))
                {
                    dataGridSale.Columns["LiczbaMiejsc"].HeaderText = "Liczba miejsc";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridSale_SelectionChanged(object sender, EventArgs e)
        {
            btnEdytuj.Enabled = dataGridSale.SelectedRows.Count > 0;
            btnUsun.Enabled = dataGridSale.SelectedRows.Count > 0;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            // Przygotuj panel do dodania nowej sali
            currentSala = null;
            currentMiejsca = null;
            ClearForm();
            groupBoxDetails.Visible = true;

            // W trybie dodawania nie pokazujemy listy miejsc
            listBoxMiejsca.Visible = false;
            lblMiejsca.Visible = false;
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            if (dataGridSale.SelectedRows.Count == 0)
                return;

            int salaId = Convert.ToInt32(dataGridSale.SelectedRows[0].Cells["SalaId"].Value);
            currentSala = _salaService.GetSalaById(salaId);

            if (currentSala != null)
            {
                // Wypełnij formularz danymi
                txtNazwa.Text = currentSala.Nazwa;
                numLiczbaMiejsc.Value = currentSala.LiczbaMiejsc;

                // Pobierz miejsca dla wybranej sali
                currentMiejsca = _salaService.GetMiejscaForSala(salaId);
                LoadMiejsca();

                groupBoxDetails.Visible = true;
                listBoxMiejsca.Visible = true;
                lblMiejsca.Visible = true;
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridSale.SelectedRows.Count == 0)
                return;

            int salaId = Convert.ToInt32(dataGridSale.SelectedRows[0].Cells["SalaId"].Value);
            string nazwa = dataGridSale.SelectedRows[0].Cells["Nazwa"].Value.ToString();

            DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć salę '{nazwa}'?",
                "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _salaService.DeleteSala(salaId);
                    MessageBox.Show("Sala została usunięta.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSale();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas usuwania sali: " + ex.Message, "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazwa.Text))
            {
                MessageBox.Show("Nazwa sali jest wymagana.", "Walidacja",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Przygotuj obiekt sali
                Sala sala = currentSala ?? new Sala();
                sala.Nazwa = txtNazwa.Text;
                sala.LiczbaMiejsc = (int)numLiczbaMiejsc.Value;

                if (currentSala == null)
                {
                    // Dodaj nową salę
                    _salaService.AddSala(sala);
                    MessageBox.Show("Sala została dodana.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Aktualizuj istniejącą salę
                    _salaService.UpdateSala(sala);
                    MessageBox.Show("Sala została zaktualizowana.", "Sukces",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Odśwież listę sal
                LoadSale();
                groupBoxDetails.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas zapisywania sali: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            groupBoxDetails.Visible = false;

        }

        private void ClearForm()
        {
            txtNazwa.Text = string.Empty;
            numLiczbaMiejsc.Value = 50;
            listBoxMiejsca.Items.Clear();
        }

        private void LoadMiejsca()
        {
            listBoxMiejsca.Items.Clear();

            if (currentMiejsca != null && currentMiejsca.Count > 0)
            {
                foreach (var miejsce in currentMiejsca)
                {
                    string status = miejsce.Zajete ? "zajęte" : "wolne";
                    listBoxMiejsca.Items.Add($"Miejsce {miejsce.Numer} - {status}");
                }
            }
        }
    }
}
