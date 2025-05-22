namespace MultikinoAdmin.Forms
{
    partial class SeanseForm
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
            this.rbActive = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.dataGridSeanse = new System.Windows.Forms.DataGridView();
            this.btnEdytuj = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.lblFilm = new System.Windows.Forms.Label();
            this.comboFilmy = new System.Windows.Forms.ComboBox();
            this.lblData = new System.Windows.Forms.Label();
            this.comboSale = new System.Windows.Forms.ComboBox();
            this.lblSala = new System.Windows.Forms.Label();
            this.datePickerSeans = new System.Windows.Forms.DateTimePicker();
            this.timePickerSeans = new System.Windows.Forms.DateTimePicker();
            this.lblGodzina = new System.Windows.Forms.Label();
            this.btnAnuluj = new System.Windows.Forms.Button();
            this.btnZapisz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSeanse)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbActive
            // 
            this.rbActive.AutoSize = true;
            this.rbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.rbActive.Location = new System.Drawing.Point(674, 42);
            this.rbActive.Name = "rbActive";
            this.rbActive.Size = new System.Drawing.Size(114, 24);
            this.rbActive.TabIndex = 0;
            this.rbActive.TabStop = true;
            this.rbActive.Text = "Filter active";
            this.rbActive.UseVisualStyleBackColor = true;
            this.rbActive.CheckedChanged += new System.EventHandler(this.rbActive_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.rbAll.Location = new System.Drawing.Point(674, 106);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(87, 24);
            this.rbAll.TabIndex = 1;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Filter all";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // dataGridSeanse
            // 
            this.dataGridSeanse.AllowUserToAddRows = false;
            this.dataGridSeanse.AllowUserToDeleteRows = false;
            this.dataGridSeanse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSeanse.Location = new System.Drawing.Point(0, -1);
            this.dataGridSeanse.Name = "dataGridSeanse";
            this.dataGridSeanse.ReadOnly = true;
            this.dataGridSeanse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSeanse.Size = new System.Drawing.Size(653, 197);
            this.dataGridSeanse.TabIndex = 2;
            this.dataGridSeanse.SelectionChanged += new System.EventHandler(this.dataGridSeanse_SelectionChanged);
            // 
            // btnEdytuj
            // 
            this.btnEdytuj.AutoSize = true;
            this.btnEdytuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnEdytuj.Location = new System.Drawing.Point(620, 295);
            this.btnEdytuj.Name = "btnEdytuj";
            this.btnEdytuj.Size = new System.Drawing.Size(79, 32);
            this.btnEdytuj.TabIndex = 6;
            this.btnEdytuj.Text = "Edytuj";
            this.btnEdytuj.UseVisualStyleBackColor = true;
            this.btnEdytuj.Click += new System.EventHandler(this.btnEdytuj_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.AutoSize = true;
            this.btnUsun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnUsun.Location = new System.Drawing.Point(620, 358);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(79, 32);
            this.btnUsun.TabIndex = 5;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.AutoSize = true;
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnDodaj.Location = new System.Drawing.Point(620, 236);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(79, 32);
            this.btnDodaj.TabIndex = 4;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.btnAnuluj);
            this.groupBoxDetails.Controls.Add(this.btnZapisz);
            this.groupBoxDetails.Controls.Add(this.lblFilm);
            this.groupBoxDetails.Controls.Add(this.comboFilmy);
            this.groupBoxDetails.Controls.Add(this.timePickerSeans);
            this.groupBoxDetails.Controls.Add(this.lblSala);
            this.groupBoxDetails.Controls.Add(this.lblGodzina);
            this.groupBoxDetails.Controls.Add(this.comboSale);
            this.groupBoxDetails.Controls.Add(this.datePickerSeans);
            this.groupBoxDetails.Controls.Add(this.lblData);
            this.groupBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 211);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(518, 314);
            this.groupBoxDetails.TabIndex = 7;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Szczególy seansu";
            // 
            // lblFilm
            // 
            this.lblFilm.AutoSize = true;
            this.lblFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblFilm.Location = new System.Drawing.Point(57, 40);
            this.lblFilm.Name = "lblFilm";
            this.lblFilm.Size = new System.Drawing.Size(41, 20);
            this.lblFilm.TabIndex = 8;
            this.lblFilm.Text = "Film";
            this.lblFilm.Click += new System.EventHandler(this.lblFilm_Click);
            // 
            // comboFilmy
            // 
            this.comboFilmy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.comboFilmy.FormattingEnabled = true;
            this.comboFilmy.Location = new System.Drawing.Point(163, 40);
            this.comboFilmy.Name = "comboFilmy";
            this.comboFilmy.Size = new System.Drawing.Size(121, 28);
            this.comboFilmy.TabIndex = 9;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblData.Location = new System.Drawing.Point(57, 140);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(45, 20);
            this.lblData.TabIndex = 10;
            this.lblData.Text = "Data";
            // 
            // comboSale
            // 
            this.comboSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.comboSale.FormattingEnabled = true;
            this.comboSale.Location = new System.Drawing.Point(163, 87);
            this.comboSale.Name = "comboSale";
            this.comboSale.Size = new System.Drawing.Size(121, 28);
            this.comboSale.TabIndex = 13;
            // 
            // lblSala
            // 
            this.lblSala.AutoSize = true;
            this.lblSala.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblSala.Location = new System.Drawing.Point(56, 90);
            this.lblSala.Name = "lblSala";
            this.lblSala.Size = new System.Drawing.Size(42, 20);
            this.lblSala.TabIndex = 12;
            this.lblSala.Text = "Sala";
            // 
            // datePickerSeans
            // 
            this.datePickerSeans.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.datePickerSeans.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerSeans.Location = new System.Drawing.Point(163, 134);
            this.datePickerSeans.Name = "datePickerSeans";
            this.datePickerSeans.Size = new System.Drawing.Size(200, 26);
            this.datePickerSeans.TabIndex = 14;
            this.datePickerSeans.Value = new System.DateTime(2025, 5, 18, 0, 37, 25, 0);
            // 
            // timePickerSeans
            // 
            this.timePickerSeans.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.timePickerSeans.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePickerSeans.Location = new System.Drawing.Point(163, 182);
            this.timePickerSeans.Name = "timePickerSeans";
            this.timePickerSeans.Size = new System.Drawing.Size(200, 26);
            this.timePickerSeans.TabIndex = 16;
            // 
            // lblGodzina
            // 
            this.lblGodzina.AutoSize = true;
            this.lblGodzina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblGodzina.Location = new System.Drawing.Point(57, 188);
            this.lblGodzina.Name = "lblGodzina";
            this.lblGodzina.Size = new System.Drawing.Size(71, 20);
            this.lblGodzina.TabIndex = 15;
            this.lblGodzina.Text = "Godzina";
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnAnuluj.Location = new System.Drawing.Point(434, 273);
            this.btnAnuluj.Name = "btnAnuluj";
            this.btnAnuluj.Size = new System.Drawing.Size(78, 31);
            this.btnAnuluj.TabIndex = 17;
            this.btnAnuluj.Text = "Anuluj";
            this.btnAnuluj.UseVisualStyleBackColor = true;
            this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click);
            // 
            // btnZapisz
            // 
            this.btnZapisz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnZapisz.Location = new System.Drawing.Point(6, 273);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(75, 29);
            this.btnZapisz.TabIndex = 18;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // SeanseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.btnEdytuj);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dataGridSeanse);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.rbActive);
            this.Name = "SeanseForm";
            this.Text = "SeanseForm";
            this.Load += new System.EventHandler(this.SeanseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSeanse)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbActive;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.DataGridView dataGridSeanse;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblFilm;
        private System.Windows.Forms.ComboBox comboFilmy;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.ComboBox comboSale;
        private System.Windows.Forms.Label lblSala;
        private System.Windows.Forms.DateTimePicker datePickerSeans;
        private System.Windows.Forms.DateTimePicker timePickerSeans;
        private System.Windows.Forms.Label lblGodzina;
        private System.Windows.Forms.Button btnAnuluj;
        private System.Windows.Forms.Button btnZapisz;
    }
}