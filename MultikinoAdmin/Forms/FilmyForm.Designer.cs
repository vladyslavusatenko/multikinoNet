namespace MultikinoAdmin.Forms
{
    partial class FilmyForm
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
            this.dataGridFilmy = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnEdytuj = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.lblTytul = new System.Windows.Forms.Label();
            this.txtTytul = new System.Windows.Forms.TextBox();
            this.lblGatunek = new System.Windows.Forms.Label();
            this.txtGatunek = new System.Windows.Forms.TextBox();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.lblOpis = new System.Windows.Forms.Label();
            this.lblCzasTrwania = new System.Windows.Forms.Label();
            this.numCzasTrwania = new System.Windows.Forms.NumericUpDown();
            this.lblPlakat = new System.Windows.Forms.Label();
            this.picPlakat = new System.Windows.Forms.PictureBox();
            this.btnWybierzPlakat = new System.Windows.Forms.Button();
            this.btnAnuluj = new System.Windows.Forms.Button();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilmy)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCzasTrwania)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlakat)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridFilmy
            // 
            this.dataGridFilmy.AllowUserToAddRows = false;
            this.dataGridFilmy.AllowUserToDeleteRows = false;
            this.dataGridFilmy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFilmy.Location = new System.Drawing.Point(0, 0);
            this.dataGridFilmy.Name = "dataGridFilmy";
            this.dataGridFilmy.ReadOnly = true;
            this.dataGridFilmy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFilmy.Size = new System.Drawing.Size(799, 191);
            this.dataGridFilmy.TabIndex = 0;
            this.dataGridFilmy.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridFilmy.SelectionChanged += new System.EventHandler(this.dataGridFilmy_SelectionChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnDodaj.Location = new System.Drawing.Point(620, 236);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(81, 34);
            this.btnDodaj.TabIndex = 1;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnEdytuj
            // 
            this.btnEdytuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnEdytuj.Location = new System.Drawing.Point(620, 295);
            this.btnEdytuj.Name = "btnEdytuj";
            this.btnEdytuj.Size = new System.Drawing.Size(81, 34);
            this.btnEdytuj.TabIndex = 2;
            this.btnEdytuj.Text = "Edytuj";
            this.btnEdytuj.UseVisualStyleBackColor = true;
            this.btnEdytuj.Click += new System.EventHandler(this.btnEdytuj_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnUsun.Location = new System.Drawing.Point(620, 358);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(81, 34);
            this.btnUsun.TabIndex = 3;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.AutoSize = true;
            this.groupBoxDetails.Controls.Add(this.panel1);
            this.groupBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 211);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(518, 338);
            this.groupBoxDetails.TabIndex = 4;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Szszególy filmu";
            this.groupBoxDetails.Resize += new System.EventHandler(this.groupBoxDetails_Resize);
            // 
            // lblTytul
            // 
            this.lblTytul.AutoSize = true;
            this.lblTytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblTytul.Location = new System.Drawing.Point(56, 25);
            this.lblTytul.Name = "lblTytul";
            this.lblTytul.Size = new System.Drawing.Size(45, 20);
            this.lblTytul.TabIndex = 0;
            this.lblTytul.Text = "Tytuł";
            // 
            // txtTytul
            // 
            this.txtTytul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtTytul.Location = new System.Drawing.Point(176, 22);
            this.txtTytul.Name = "txtTytul";
            this.txtTytul.Size = new System.Drawing.Size(244, 26);
            this.txtTytul.TabIndex = 1;
            // 
            // lblGatunek
            // 
            this.lblGatunek.AutoSize = true;
            this.lblGatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblGatunek.Location = new System.Drawing.Point(56, 59);
            this.lblGatunek.Name = "lblGatunek";
            this.lblGatunek.Size = new System.Drawing.Size(71, 20);
            this.lblGatunek.TabIndex = 2;
            this.lblGatunek.Text = "Gatunek";
            // 
            // txtGatunek
            // 
            this.txtGatunek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtGatunek.Location = new System.Drawing.Point(176, 56);
            this.txtGatunek.Name = "txtGatunek";
            this.txtGatunek.Size = new System.Drawing.Size(244, 26);
            this.txtGatunek.TabIndex = 3;
            // 
            // txtOpis
            // 
            this.txtOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtOpis.Location = new System.Drawing.Point(176, 91);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(244, 65);
            this.txtOpis.TabIndex = 5;
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblOpis.Location = new System.Drawing.Point(56, 91);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(44, 20);
            this.lblOpis.TabIndex = 4;
            this.lblOpis.Text = "Opis";
            // 
            // lblCzasTrwania
            // 
            this.lblCzasTrwania.AutoSize = true;
            this.lblCzasTrwania.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblCzasTrwania.Location = new System.Drawing.Point(57, 177);
            this.lblCzasTrwania.Name = "lblCzasTrwania";
            this.lblCzasTrwania.Size = new System.Drawing.Size(112, 20);
            this.lblCzasTrwania.TabIndex = 6;
            this.lblCzasTrwania.Text = "Czas Trwania";
            // 
            // numCzasTrwania
            // 
            this.numCzasTrwania.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.numCzasTrwania.Location = new System.Drawing.Point(176, 171);
            this.numCzasTrwania.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.numCzasTrwania.Name = "numCzasTrwania";
            this.numCzasTrwania.Size = new System.Drawing.Size(120, 26);
            this.numCzasTrwania.TabIndex = 7;
            // 
            // lblPlakat
            // 
            this.lblPlakat.AutoSize = true;
            this.lblPlakat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblPlakat.Location = new System.Drawing.Point(57, 223);
            this.lblPlakat.Name = "lblPlakat";
            this.lblPlakat.Size = new System.Drawing.Size(55, 20);
            this.lblPlakat.TabIndex = 8;
            this.lblPlakat.Text = "Plakat";
            // 
            // picPlakat
            // 
            this.picPlakat.Location = new System.Drawing.Point(176, 223);
            this.picPlakat.Name = "picPlakat";
            this.picPlakat.Size = new System.Drawing.Size(201, 190);
            this.picPlakat.TabIndex = 9;
            this.picPlakat.TabStop = false;
            // 
            // btnWybierzPlakat
            // 
            this.btnWybierzPlakat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnWybierzPlakat.Location = new System.Drawing.Point(296, 419);
            this.btnWybierzPlakat.Name = "btnWybierzPlakat";
            this.btnWybierzPlakat.Size = new System.Drawing.Size(81, 25);
            this.btnWybierzPlakat.TabIndex = 5;
            this.btnWybierzPlakat.Text = "Dodaj";
            this.btnWybierzPlakat.UseVisualStyleBackColor = true;
            this.btnWybierzPlakat.Click += new System.EventHandler(this.btnWybierzPlakat_Click);
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnAnuluj.Location = new System.Drawing.Point(395, 501);
            this.btnAnuluj.Name = "btnAnuluj";
            this.btnAnuluj.Size = new System.Drawing.Size(81, 34);
            this.btnAnuluj.TabIndex = 5;
            this.btnAnuluj.Text = "Anuluj";
            this.btnAnuluj.UseVisualStyleBackColor = true;
            this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click);
            // 
            // btnZapisz
            // 
            this.btnZapisz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnZapisz.Location = new System.Drawing.Point(1, 501);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(81, 34);
            this.btnZapisz.TabIndex = 6;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnAnuluj);
            this.panel1.Controls.Add(this.picPlakat);
            this.panel1.Controls.Add(this.btnZapisz);
            this.panel1.Controls.Add(this.lblTytul);
            this.panel1.Controls.Add(this.btnWybierzPlakat);
            this.panel1.Controls.Add(this.txtTytul);
            this.panel1.Controls.Add(this.lblGatunek);
            this.panel1.Controls.Add(this.lblPlakat);
            this.panel1.Controls.Add(this.txtGatunek);
            this.panel1.Controls.Add(this.numCzasTrwania);
            this.panel1.Controls.Add(this.lblOpis);
            this.panel1.Controls.Add(this.lblCzasTrwania);
            this.panel1.Controls.Add(this.txtOpis);
            this.panel1.Location = new System.Drawing.Point(12, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 273);
            this.panel1.TabIndex = 10;
            // 
            // FilmyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnEdytuj);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dataGridFilmy);
            this.Name = "FilmyForm";
            this.Text = "FilmyForm";
            this.Load += new System.EventHandler(this.FilmyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFilmy)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numCzasTrwania)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlakat)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFilmy;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label lblOpis;
        private System.Windows.Forms.TextBox txtGatunek;
        private System.Windows.Forms.Label lblGatunek;
        private System.Windows.Forms.TextBox txtTytul;
        private System.Windows.Forms.Label lblTytul;
        private System.Windows.Forms.PictureBox picPlakat;
        private System.Windows.Forms.Label lblPlakat;
        private System.Windows.Forms.NumericUpDown numCzasTrwania;
        private System.Windows.Forms.Label lblCzasTrwania;
        private System.Windows.Forms.Button btnAnuluj;
        private System.Windows.Forms.Button btnZapisz;
        private System.Windows.Forms.Button btnWybierzPlakat;
        private System.Windows.Forms.Panel panel1;
    }
}