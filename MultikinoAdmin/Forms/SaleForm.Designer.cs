namespace MultikinoAdmin.Forms
{
    partial class SaleForm
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
            this.dataGridSale = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.btnEdytuj = new System.Windows.Forms.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNazwa = new System.Windows.Forms.Label();
            this.txtNazwa = new System.Windows.Forms.TextBox();
            this.lblLiczbaMiejsc = new System.Windows.Forms.Label();
            this.numLiczbaMiejsc = new System.Windows.Forms.NumericUpDown();
            this.listBoxMiejsca = new System.Windows.Forms.ListBox();
            this.btnAnuluj = new System.Windows.Forms.Button();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.lblMiejsca = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSale)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLiczbaMiejsc)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridSale
            // 
            this.dataGridSale.AllowUserToAddRows = false;
            this.dataGridSale.AllowUserToDeleteRows = false;
            this.dataGridSale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSale.Location = new System.Drawing.Point(1, -2);
            this.dataGridSale.Name = "dataGridSale";
            this.dataGridSale.ReadOnly = true;
            this.dataGridSale.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSale.Size = new System.Drawing.Size(799, 194);
            this.dataGridSale.TabIndex = 0;
            this.dataGridSale.SelectionChanged += new System.EventHandler(this.dataGridSale_SelectionChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnDodaj.Location = new System.Drawing.Point(620, 236);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(79, 32);
            this.btnDodaj.TabIndex = 1;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnUsun.Location = new System.Drawing.Point(620, 358);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(79, 32);
            this.btnUsun.TabIndex = 2;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // btnEdytuj
            // 
            this.btnEdytuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnEdytuj.Location = new System.Drawing.Point(620, 295);
            this.btnEdytuj.Name = "btnEdytuj";
            this.btnEdytuj.Size = new System.Drawing.Size(79, 32);
            this.btnEdytuj.TabIndex = 3;
            this.btnEdytuj.Text = "Edytuj";
            this.btnEdytuj.UseVisualStyleBackColor = true;
            this.btnEdytuj.Click += new System.EventHandler(this.btnEdytuj_Click);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.panel1);
            this.groupBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBoxDetails.Location = new System.Drawing.Point(0, 211);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(518, 338);
            this.groupBoxDetails.TabIndex = 4;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Szczególy sali";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMiejsca);
            this.panel1.Controls.Add(this.btnAnuluj);
            this.panel1.Controls.Add(this.btnZapisz);
            this.panel1.Controls.Add(this.listBoxMiejsca);
            this.panel1.Controls.Add(this.numLiczbaMiejsc);
            this.panel1.Controls.Add(this.lblLiczbaMiejsc);
            this.panel1.Controls.Add(this.lblNazwa);
            this.panel1.Controls.Add(this.txtNazwa);
            this.panel1.Location = new System.Drawing.Point(0, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(498, 316);
            this.panel1.TabIndex = 0;
            // 
            // lblNazwa
            // 
            this.lblNazwa.AutoSize = true;
            this.lblNazwa.Location = new System.Drawing.Point(57, 40);
            this.lblNazwa.Name = "lblNazwa";
            this.lblNazwa.Size = new System.Drawing.Size(60, 20);
            this.lblNazwa.TabIndex = 5;
            this.lblNazwa.Text = "Nazwa";
            // 
            // txtNazwa
            // 
            this.txtNazwa.Location = new System.Drawing.Point(215, 37);
            this.txtNazwa.Name = "txtNazwa";
            this.txtNazwa.Size = new System.Drawing.Size(249, 26);
            this.txtNazwa.TabIndex = 6;
            // 
            // lblLiczbaMiejsc
            // 
            this.lblLiczbaMiejsc.AutoSize = true;
            this.lblLiczbaMiejsc.Location = new System.Drawing.Point(57, 86);
            this.lblLiczbaMiejsc.Name = "lblLiczbaMiejsc";
            this.lblLiczbaMiejsc.Size = new System.Drawing.Size(113, 20);
            this.lblLiczbaMiejsc.TabIndex = 7;
            this.lblLiczbaMiejsc.Text = "Liczba miejsc";
            // 
            // numLiczbaMiejsc
            // 
            this.numLiczbaMiejsc.Location = new System.Drawing.Point(215, 84);
            this.numLiczbaMiejsc.Name = "numLiczbaMiejsc";
            this.numLiczbaMiejsc.Size = new System.Drawing.Size(120, 26);
            this.numLiczbaMiejsc.TabIndex = 8;
            // 
            // listBoxMiejsca
            // 
            this.listBoxMiejsca.FormattingEnabled = true;
            this.listBoxMiejsca.ItemHeight = 20;
            this.listBoxMiejsca.Location = new System.Drawing.Point(215, 129);
            this.listBoxMiejsca.Name = "listBoxMiejsca";
            this.listBoxMiejsca.Size = new System.Drawing.Size(249, 104);
            this.listBoxMiejsca.TabIndex = 9;
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(401, 273);
            this.btnAnuluj.Name = "btnAnuluj";
            this.btnAnuluj.Size = new System.Drawing.Size(81, 29);
            this.btnAnuluj.TabIndex = 5;
            this.btnAnuluj.Text = "Anuluj";
            this.btnAnuluj.UseVisualStyleBackColor = true;
            this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click);
            // 
            // btnZapisz
            // 
            this.btnZapisz.Location = new System.Drawing.Point(12, 273);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(83, 29);
            this.btnZapisz.TabIndex = 6;
            this.btnZapisz.Text = "Zapsiz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // lblMiejsca
            // 
            this.lblMiejsca.AutoSize = true;
            this.lblMiejsca.Location = new System.Drawing.Point(57, 129);
            this.lblMiejsca.Name = "lblMiejsca";
            this.lblMiejsca.Size = new System.Drawing.Size(67, 20);
            this.lblMiejsca.TabIndex = 10;
            this.lblMiejsca.Text = "Miejsca";
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.btnEdytuj);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dataGridSale);
            this.Name = "SaleForm";
            this.Text = "SaleForm";
            this.Load += new System.EventHandler(this.SaleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSale)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLiczbaMiejsc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridSale;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxMiejsca;
        private System.Windows.Forms.NumericUpDown numLiczbaMiejsc;
        private System.Windows.Forms.Label lblLiczbaMiejsc;
        private System.Windows.Forms.Label lblNazwa;
        private System.Windows.Forms.TextBox txtNazwa;
        private System.Windows.Forms.Button btnAnuluj;
        private System.Windows.Forms.Button btnZapisz;
        private System.Windows.Forms.Label lblMiejsca;
    }
}