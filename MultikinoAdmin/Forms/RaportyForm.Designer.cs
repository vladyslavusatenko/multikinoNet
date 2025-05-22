namespace MultikinoAdmin.Forms
{
    partial class RaportyForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePrzychody = new System.Windows.Forms.TabPage();
            this.tabPageZapelnienie = new System.Windows.Forms.TabPage();
            this.tabPageDzienne = new System.Windows.Forms.TabPage();
            this.tabPageMiesieczne = new System.Windows.Forms.TabPage();
            this.tabPageTrendy = new System.Windows.Forms.TabPage();
            this.chartPrzychody = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridZapelnienie = new System.Windows.Forms.DataGridView();
            this.dataGridDzienne = new System.Windows.Forms.DataGridView();
            this.btnExportDzienne = new System.Windows.Forms.Button();
            this.dataGridMiesieczne = new System.Windows.Forms.DataGridView();
            this.btnExportMiesieczne = new System.Windows.Forms.Button();
            this.chartTrendy = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportPrzychodyWykres = new System.Windows.Forms.Button();
            this.btnExportTrendyWykres = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPagePrzychody.SuspendLayout();
            this.tabPageZapelnienie.SuspendLayout();
            this.tabPageDzienne.SuspendLayout();
            this.tabPageMiesieczne.SuspendLayout();
            this.tabPageTrendy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPrzychody)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridZapelnienie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDzienne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMiesieczne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrendy)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPagePrzychody);
            this.tabControl1.Controls.Add(this.tabPageZapelnienie);
            this.tabControl1.Controls.Add(this.tabPageDzienne);
            this.tabControl1.Controls.Add(this.tabPageMiesieczne);
            this.tabControl1.Controls.Add(this.tabPageTrendy);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 451);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPagePrzychody
            // 
            this.tabPagePrzychody.Controls.Add(this.btnExportPrzychodyWykres);
            this.tabPagePrzychody.Controls.Add(this.chartPrzychody);
            this.tabPagePrzychody.Location = new System.Drawing.Point(4, 29);
            this.tabPagePrzychody.Name = "tabPagePrzychody";
            this.tabPagePrzychody.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrzychody.Size = new System.Drawing.Size(792, 418);
            this.tabPagePrzychody.TabIndex = 0;
            this.tabPagePrzychody.Text = "Przychody na film";
            this.tabPagePrzychody.UseVisualStyleBackColor = true;
            // 
            // tabPageZapelnienie
            // 
            this.tabPageZapelnienie.Controls.Add(this.dataGridZapelnienie);
            this.tabPageZapelnienie.Location = new System.Drawing.Point(4, 29);
            this.tabPageZapelnienie.Name = "tabPageZapelnienie";
            this.tabPageZapelnienie.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageZapelnienie.Size = new System.Drawing.Size(792, 418);
            this.tabPageZapelnienie.TabIndex = 1;
            this.tabPageZapelnienie.Text = "Zapełnienie sal";
            this.tabPageZapelnienie.UseVisualStyleBackColor = true;
            // 
            // tabPageDzienne
            // 
            this.tabPageDzienne.Controls.Add(this.btnExportDzienne);
            this.tabPageDzienne.Controls.Add(this.dataGridDzienne);
            this.tabPageDzienne.Location = new System.Drawing.Point(4, 29);
            this.tabPageDzienne.Name = "tabPageDzienne";
            this.tabPageDzienne.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDzienne.Size = new System.Drawing.Size(792, 418);
            this.tabPageDzienne.TabIndex = 2;
            this.tabPageDzienne.Text = "Raport dzienny";
            this.tabPageDzienne.UseVisualStyleBackColor = true;
            // 
            // tabPageMiesieczne
            // 
            this.tabPageMiesieczne.Controls.Add(this.btnExportMiesieczne);
            this.tabPageMiesieczne.Controls.Add(this.dataGridMiesieczne);
            this.tabPageMiesieczne.Location = new System.Drawing.Point(4, 29);
            this.tabPageMiesieczne.Name = "tabPageMiesieczne";
            this.tabPageMiesieczne.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMiesieczne.Size = new System.Drawing.Size(792, 418);
            this.tabPageMiesieczne.TabIndex = 3;
            this.tabPageMiesieczne.Text = "Raport miesięczny";
            this.tabPageMiesieczne.UseVisualStyleBackColor = true;
            // 
            // tabPageTrendy
            // 
            this.tabPageTrendy.Controls.Add(this.btnExportTrendyWykres);
            this.tabPageTrendy.Controls.Add(this.chartTrendy);
            this.tabPageTrendy.Location = new System.Drawing.Point(4, 29);
            this.tabPageTrendy.Name = "tabPageTrendy";
            this.tabPageTrendy.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTrendy.Size = new System.Drawing.Size(792, 418);
            this.tabPageTrendy.TabIndex = 4;
            this.tabPageTrendy.Text = "Trendy sprzedaży";
            this.tabPageTrendy.UseVisualStyleBackColor = true;
            // 
            // chartPrzychody
            // 
            chartArea1.Name = "ChartArea1";
            this.chartPrzychody.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartPrzychody.Legends.Add(legend1);
            this.chartPrzychody.Location = new System.Drawing.Point(90, 32);
            this.chartPrzychody.Name = "chartPrzychody";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartPrzychody.Series.Add(series1);
            this.chartPrzychody.Size = new System.Drawing.Size(620, 326);
            this.chartPrzychody.TabIndex = 0;
            this.chartPrzychody.Text = "chart1";
            this.chartPrzychody.Click += new System.EventHandler(this.chartPrzychody_Click);
            // 
            // dataGridZapelnienie
            // 
            this.dataGridZapelnienie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridZapelnienie.Location = new System.Drawing.Point(8, 8);
            this.dataGridZapelnienie.Name = "dataGridZapelnienie";
            this.dataGridZapelnienie.Size = new System.Drawing.Size(776, 401);
            this.dataGridZapelnienie.TabIndex = 0;
            // 
            // dataGridDzienne
            // 
            this.dataGridDzienne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDzienne.Location = new System.Drawing.Point(8, 8);
            this.dataGridDzienne.Name = "dataGridDzienne";
            this.dataGridDzienne.Size = new System.Drawing.Size(776, 348);
            this.dataGridDzienne.TabIndex = 0;
            // 
            // btnExportDzienne
            // 
            this.btnExportDzienne.Location = new System.Drawing.Point(695, 379);
            this.btnExportDzienne.Name = "btnExportDzienne";
            this.btnExportDzienne.Size = new System.Drawing.Size(90, 32);
            this.btnExportDzienne.TabIndex = 1;
            this.btnExportDzienne.Text = "Exportuj";
            this.btnExportDzienne.UseVisualStyleBackColor = true;
            this.btnExportDzienne.Click += new System.EventHandler(this.btnExportDzienne_Click);
            // 
            // dataGridMiesieczne
            // 
            this.dataGridMiesieczne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridMiesieczne.Location = new System.Drawing.Point(8, 8);
            this.dataGridMiesieczne.Name = "dataGridMiesieczne";
            this.dataGridMiesieczne.Size = new System.Drawing.Size(776, 348);
            this.dataGridMiesieczne.TabIndex = 0;
            // 
            // btnExportMiesieczne
            // 
            this.btnExportMiesieczne.Location = new System.Drawing.Point(695, 379);
            this.btnExportMiesieczne.Name = "btnExportMiesieczne";
            this.btnExportMiesieczne.Size = new System.Drawing.Size(90, 32);
            this.btnExportMiesieczne.TabIndex = 1;
            this.btnExportMiesieczne.Text = "Eksportuj";
            this.btnExportMiesieczne.UseVisualStyleBackColor = true;
            this.btnExportMiesieczne.Click += new System.EventHandler(this.btnExportMiesieczne_Click);
            // 
            // chartTrendy
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTrendy.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTrendy.Legends.Add(legend2);
            this.chartTrendy.Location = new System.Drawing.Point(90, 32);
            this.chartTrendy.Name = "chartTrendy";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartTrendy.Series.Add(series2);
            this.chartTrendy.Size = new System.Drawing.Size(620, 326);
            this.chartTrendy.TabIndex = 0;
            this.chartTrendy.Text = "chart1";
            // 
            // btnExportPrzychodyWykres
            // 
            this.btnExportPrzychodyWykres.Location = new System.Drawing.Point(694, 377);
            this.btnExportPrzychodyWykres.Name = "btnExportPrzychodyWykres";
            this.btnExportPrzychodyWykres.Size = new System.Drawing.Size(90, 32);
            this.btnExportPrzychodyWykres.TabIndex = 1;
            this.btnExportPrzychodyWykres.Text = "Eksportuj";
            this.btnExportPrzychodyWykres.UseVisualStyleBackColor = true;
            this.btnExportPrzychodyWykres.Click += new System.EventHandler(this.btnExportPrzychodyWykres_Click);
            // 
            // btnExportTrendyWykres
            // 
            this.btnExportTrendyWykres.Location = new System.Drawing.Point(694, 377);
            this.btnExportTrendyWykres.Name = "btnExportTrendyWykres";
            this.btnExportTrendyWykres.Size = new System.Drawing.Size(90, 32);
            this.btnExportTrendyWykres.TabIndex = 1;
            this.btnExportTrendyWykres.Text = "Eksportuj ";
            this.btnExportTrendyWykres.UseVisualStyleBackColor = true;
            this.btnExportTrendyWykres.Click += new System.EventHandler(this.btnExportTrendyWykres_Click);
            // 
            // RaportyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "RaportyForm";
            this.Text = "RaportyForm";
            this.Load += new System.EventHandler(this.RaportyForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePrzychody.ResumeLayout(false);
            this.tabPageZapelnienie.ResumeLayout(false);
            this.tabPageDzienne.ResumeLayout(false);
            this.tabPageMiesieczne.ResumeLayout(false);
            this.tabPageTrendy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPrzychody)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridZapelnienie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDzienne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridMiesieczne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTrendy)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePrzychody;
        private System.Windows.Forms.TabPage tabPageZapelnienie;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPrzychody;
        private System.Windows.Forms.TabPage tabPageDzienne;
        private System.Windows.Forms.TabPage tabPageMiesieczne;
        private System.Windows.Forms.TabPage tabPageTrendy;
        private System.Windows.Forms.DataGridView dataGridZapelnienie;
        private System.Windows.Forms.Button btnExportDzienne;
        private System.Windows.Forms.DataGridView dataGridDzienne;
        private System.Windows.Forms.Button btnExportMiesieczne;
        private System.Windows.Forms.DataGridView dataGridMiesieczne;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTrendy;
        private System.Windows.Forms.Button btnExportPrzychodyWykres;
        private System.Windows.Forms.Button btnExportTrendyWykres;
    }
}