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
    public partial class BiletyForm: Form
    {
        private readonly BiletService _biletService;
        private List<Bilet> _bilety;
        private Bilet currentBilet;
        public BiletyForm(BiletService biletService)
        {
            InitializeComponent();
            _biletService = biletService;
        }
        private void BiletyForm_Load(object sender, EventArgs e)
        {
            LoadBilety();

        }
        private void LoadBilety()
        {
            try
            {
                _bilety = _biletService.GetAllBilety();

                dataGridBilety.DataSource = null;
                dataGridBilety.DataSource = _bilety;

                // Ukryj niepotrzebne kolumny
                if (dataGridBilety.Columns.Contains("UzytkownikId"))
                {
                    dataGridBilety.Columns["UzytkownikId"].Visible = false;
                }
                if (dataGridBilety.Columns.Contains("SeansId"))
                {
                    dataGridBilety.Columns["SeansId"].Visible = false;
                }
                if (dataGridBilety.Columns.Contains("MiejsceId"))
                {
                    dataGridBilety.Columns["MiejsceId"].Visible = false;
                }

                // Popraw nazwy kolumn
                if (dataGridBilety.Columns.Contains("BiletId"))
                {
                    dataGridBilety.Columns["BiletId"].HeaderText = "ID";
                }
                if (dataGridBilety.Columns.Contains("TytulFilmu"))
                {
                    dataGridBilety.Columns["TytulFilmu"].HeaderText = "Film";
                }
                if (dataGridBilety.Columns.Contains("DataSeansu"))
                {
                    dataGridBilety.Columns["DataSeansu"].HeaderText = "Data seansu";
                    dataGridBilety.Columns["DataSeansu"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
                if (dataGridBilety.Columns.Contains("NumerMiejsca"))
                {
                    dataGridBilety.Columns["NumerMiejsca"].HeaderText = "Miejsce";
                }
                if (dataGridBilety.Columns.Contains("DaneKlienta"))
                {
                    dataGridBilety.Columns["DaneKlienta"].HeaderText = "Klient";
                }
                if (dataGridBilety.Columns.Contains("Cena"))
                {
                    dataGridBilety.Columns["Cena"].HeaderText = "Cena (zł)";
                    dataGridBilety.Columns["Cena"].DefaultCellStyle.Format = "0.00";
                }
                if (dataGridBilety.Columns.Contains("DataZakupu"))
                {
                    dataGridBilety.Columns["DataZakupu"].HeaderText = "Data zakupu";
                    dataGridBilety.Columns["DataZakupu"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridBilety_SelectionChanged(object sender, EventArgs e)
        {
            btnUsun.Enabled = dataGridBilety.SelectedRows.Count > 0;
            btnDrukuj.Enabled = dataGridBilety.SelectedRows.Count > 0;
        }

        private void dataGridBilety_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShowBiletDetails(Convert.ToInt32(dataGridBilety.Rows[e.RowIndex].Cells["BiletId"].Value));
            }
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridBilety.SelectedRows.Count == 0)
                return;

            int biletId = Convert.ToInt32(dataGridBilety.SelectedRows[0].Cells["BiletId"].Value);
            string film = dataGridBilety.SelectedRows[0].Cells["TytulFilmu"].Value.ToString();
            string klient = dataGridBilety.SelectedRows[0].Cells["DaneKlienta"].Value.ToString();

            DialogResult result = MessageBox.Show($"Czy na pewno chcesz usunąć bilet na film '{film}' dla klienta {klient}?",
                "Potwierdź usunięcie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _biletService.DeleteBilet(biletId);
                    MessageBox.Show("Bilet został usunięty.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBilety();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas usuwania biletu: " + ex.Message, "Błąd",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDrukuj_Click(object sender, EventArgs e)
        {
            if (dataGridBilety.SelectedRows.Count == 0)
                return;

            int biletId = Convert.ToInt32(dataGridBilety.SelectedRows[0].Cells["BiletId"].Value);
            ShowBiletDetails(biletId);
            MessageBox.Show("Funkcja drukowania nie została jeszcze zaimplementowana.", "Informacja",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnZamknij_Click(object sender, EventArgs e)
        {
            groupBoxDetails.Visible = false;

        }
        private void ShowBiletDetails(int biletId)
        {
            try
            {
                currentBilet = _biletService.GetBiletById(biletId);
                if (currentBilet != null)
                {
                    // Wypełnij formularz danymi
                    txtFilm.Text = currentBilet.TytulFilmu;
                    txtData.Text = currentBilet.DataSeansu.ToString("dd.MM.yyyy HH:mm");
                    txtMiejsce.Text = currentBilet.NumerMiejsca.ToString();
                    txtKlient.Text = currentBilet.DaneKlienta;
                    txtCena.Text = currentBilet.Cena.ToString("0.00") + " zł";
                    txtDataZakupu.Text = currentBilet.DataZakupu.ToString("dd.MM.yyyy HH:mm");

                    groupBoxDetails.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania szczegółów biletu: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
