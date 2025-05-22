using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MultikinoAdmin.Services;


namespace MultikinoAdmin.Forms
{
    public partial class RaportyForm: Form
    {
        private readonly ReportService _reportService;
        public RaportyForm(ReportService reportService)
        {
            InitializeComponent();
            _reportService = reportService;
        }

        private void RaportyForm_Load(object sender, EventArgs e)
        {
            LoadPrzychodyNaFilm();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Ładuj dane odpowiednie dla wybranej zakładki
                switch (tabControl1.SelectedIndex)
                {
                    case 0: // Przychody na film
                        LoadPrzychodyNaFilm();
                        break;
                    case 1: // Zapełnienie sal
                        LoadZapelnienieSal();
                        break;
                    case 2: // Raport dzienny
                        LoadRaportDzienny();
                        break;
                    case 3: // Raport miesięczny
                        LoadRaportMiesieczny();
                        break;
                    case 4: // Trendy sprzedaży
                        LoadTrendySprzedazy();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadPrzychodyNaFilm()
        {
            try
            {
                DataTable przychodyData = _reportService.GetSalesPerFilm();

                // Konfiguruj wykres
                chartPrzychody.Series.Clear();
                chartPrzychody.Titles.Clear();
                chartPrzychody.ChartAreas.Clear();

                // Dodaj obszar wykresu jeśli nie istnieje
                if (chartPrzychody.ChartAreas.Count == 0)
                {
                    chartPrzychody.ChartAreas.Add(new ChartArea("PrzychodyArea"));
                }

                // Dodaj tytuł
                chartPrzychody.Titles.Add(new Title("Przychody na film", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.Black));

                // Konfiguruj oś X i Y
                chartPrzychody.ChartAreas[0].AxisX.Title = "Film";
                chartPrzychody.ChartAreas[0].AxisY.Title = "Przychody (zł)";
                chartPrzychody.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartPrzychody.ChartAreas[0].AxisX.Interval = 1;
                chartPrzychody.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);
                chartPrzychody.ChartAreas[0].AxisY.LabelStyle.Format = "C";
                chartPrzychody.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chartPrzychody.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;

                // Tworzenie serii danych
                Series series = new Series("Przychody");
                series.ChartType = SeriesChartType.Column;
                series.Color = Color.SteelBlue;
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "C";
                series.Font = new Font("Arial", 8);

                // Czy są dane do wyświetlenia?
                if (przychodyData.Rows.Count == 0)
                {
                    // Brak danych - pokaż informację
                    Series noDataSeries = new Series("NoData");
                    noDataSeries.ChartType = SeriesChartType.Column;
                    noDataSeries.Points.AddXY("Brak danych", 0);
                    chartPrzychody.Series.Add(noDataSeries);

                    chartPrzychody.Titles.Clear();
                    chartPrzychody.Titles.Add(new Title("Brak danych o przychodach", Docking.Top, new Font("Arial", 14, FontStyle.Bold), Color.Red));
                }
                else
                {
                    // Dodaj dane do wykresu
                    foreach (DataRow row in przychodyData.Rows)
                    {
                        string tytul = row["Tytul"].ToString();
                        decimal przychody = Convert.ToDecimal(row["Przychody"]);

                        DataPoint point = new DataPoint();
                        point.AxisLabel = tytul;
                        point.YValues = new double[] { Convert.ToDouble(przychody) };
                        series.Points.Add(point);
                    }
                    chartPrzychody.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych przychodów: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadZapelnienieSal()
        {
            try
            {
                DataTable zapelnienieData = _reportService.GetHallOccupancy();
                dataGridZapelnienie.DataSource = zapelnienieData;

                // Formatuj kolumny
                if (dataGridZapelnienie.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn column in dataGridZapelnienie.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania danych zapełnienia sal: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadRaportDzienny()
        {
            try
            {
                DataTable dziennyData = _reportService.GetDailySales();
                dataGridDzienne.DataSource = dziennyData;

                // Formatuj kolumny
                if (dataGridDzienne.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn column in dataGridDzienne.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    if (dataGridDzienne.Columns.Contains("Przychody"))
                    {
                        dataGridDzienne.Columns["Przychody"].DefaultCellStyle.Format = "C";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania raportu dziennego: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadRaportMiesieczny()
        {
            try
            {
                DataTable miesiecznyData = _reportService.GetMonthlySales();
                dataGridMiesieczne.DataSource = miesiecznyData;

                // Formatuj kolumny
                if (dataGridMiesieczne.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn column in dataGridMiesieczne.Columns)
                    {
                        column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }

                    if (dataGridMiesieczne.Columns.Contains("Przychody"))
                    {
                        dataGridMiesieczne.Columns["Przychody"].DefaultCellStyle.Format = "C";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania raportu miesięcznego: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrendySprzedazy()
        {
            try
            {
                DataTable trendyData = _reportService.GetSalesTrend();

                // Konfiguruj wykres
                chartTrendy.Series.Clear();
                Series series = new Series("Trend sprzedaży");
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 3;
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 8;

                // Dodaj dane do wykresu
                foreach (DataRow row in trendyData.Rows)
                {
                    DateTime data = Convert.ToDateTime(row["DataSprzedazy"]);
                    decimal przychody = Convert.ToDecimal(row["DzienneObroty"]);

                    series.Points.AddXY(data, przychody);
                }

                chartTrendy.Series.Add(series);
                chartTrendy.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
                chartTrendy.ChartAreas[0].AxisX.LabelStyle.Format = "dd.MM.yyyy";
                chartTrendy.ChartAreas[0].AxisY.Title = "Przychody (zł)";
                chartTrendy.ChartAreas[0].AxisX.Title = "Data";
                chartTrendy.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                chartTrendy.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                chartTrendy.Titles.Clear();
                chartTrendy.Titles.Add("Trendy sprzedaży w ostatnich 30 dniach");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania trendów sprzedaży: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportDzienne_Click(object sender, EventArgs e)
        {
            ExportToCSV(dataGridDzienne, "RaportDzienny");
        }

        private void btnExportMiesieczne_Click(object sender, EventArgs e)
        {
            ExportToCSV(dataGridMiesieczne, "RaportMiesieczny");

        }
        private void ExportToCSV(DataGridView dataGrid, string fileName)
        {
            try
            {
                // Sprawdź, czy są dane do eksportu
                if (dataGrid.Rows.Count == 0)
                {
                    MessageBox.Show("Brak danych do eksportu.", "Informacja",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.FileName = fileName + "_" + DateTime.Now.ToString("yyyyMMdd");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Nagłówki kolumn
                        for (int i = 0; i < dataGrid.Columns.Count; i++)
                        {
                            writer.Write(dataGrid.Columns[i].HeaderText);
                            if (i < dataGrid.Columns.Count - 1)
                                writer.Write(",");
                        }
                        writer.WriteLine();

                        // Dane
                        foreach (DataGridViewRow row in dataGrid.Rows)
                        {
                            for (int i = 0; i < dataGrid.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                {
                                    string value = row.Cells[i].Value.ToString();
                                    // Jeśli wartość zawiera przecinek, ujmij ją w cudzysłowy
                                    if (value.Contains(","))
                                        value = "\"" + value + "\"";
                                    writer.Write(value);
                                }
                                if (i < dataGrid.Columns.Count - 1)
                                    writer.Write(",");
                            }
                            writer.WriteLine();
                        }
                    }

                    MessageBox.Show("Dane zostały wyeksportowane do pliku: " + saveFileDialog.FileName,
                        "Eksport zakończony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas eksportu danych: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ExportChartAsImage(Chart chart, string defaultFileName)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpg)|*.jpg|BMP Files (*.bmp)|*.bmp";
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.FileName = defaultFileName + "_" + DateTime.Now.ToString("yyyyMMdd");

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ChartImageFormat format;
                    string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();

                    switch (extension)
                    {
                        case ".jpg":
                        case ".jpeg":
                            format = ChartImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ChartImageFormat.Bmp;
                            break;
                        default:
                            format = ChartImageFormat.Png;
                            break;
                    }

                    chart.SaveImage(saveFileDialog.FileName, format);
                    MessageBox.Show("Wykres został wyeksportowany do pliku: " + saveFileDialog.FileName,
                        "Eksport zakończony", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas eksportu wykresu: " + ex.Message, "Błąd",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chartPrzychody_Click(object sender, EventArgs e)
        {

        }

        private void btnExportPrzychodyWykres_Click(object sender, EventArgs e)
        {
            ExportChartAsImage(chartPrzychody, "WykresPrzychodyNaFilm");

        }

        private void btnExportTrendyWykres_Click(object sender, EventArgs e)
        {
            ExportChartAsImage(chartTrendy, "WykresTrendySprzedazy");

        }


    }
}
