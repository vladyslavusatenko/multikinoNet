namespace MultikinoAdmin.Forms
{
    partial class UzytkownicyForm
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
            this.dataGridUzytkownicy = new System.Windows.Forms.DataGridView();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnEdytuj = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.btnZmienHaslo = new System.Windows.Forms.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxPassword = new System.Windows.Forms.GroupBox();
            this.btnAnulujHaslo = new System.Windows.Forms.Button();
            this.btnZapiszHaslo = new System.Windows.Forms.Button();
            this.txtPotwierdzHaslo = new System.Windows.Forms.TextBox();
            this.lblPotwierdzHaslo = new System.Windows.Forms.Label();
            this.txtNoweHaslo = new System.Windows.Forms.TextBox();
            this.lblNoweHaslo = new System.Windows.Forms.Label();
            this.btnAnuluj = new System.Windows.Forms.Button();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.comboRola = new System.Windows.Forms.ComboBox();
            this.lblRola = new System.Windows.Forms.Label();
            this.txtHaslo = new System.Windows.Forms.TextBox();
            this.lblHaslo = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtNazwisko = new System.Windows.Forms.TextBox();
            this.lblNazwisko = new System.Windows.Forms.Label();
            this.txtImie = new System.Windows.Forms.TextBox();
            this.lblImie = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUzytkownicy)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            this.groupBoxPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridUzytkownicy
            // 
            this.dataGridUzytkownicy.AllowUserToAddRows = false;
            this.dataGridUzytkownicy.AllowUserToDeleteRows = false;
            this.dataGridUzytkownicy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridUzytkownicy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridUzytkownicy.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridUzytkownicy.Location = new System.Drawing.Point(0, 0);
            this.dataGridUzytkownicy.MultiSelect = false;
            this.dataGridUzytkownicy.Name = "dataGridUzytkownicy";
            this.dataGridUzytkownicy.ReadOnly = true;
            this.dataGridUzytkownicy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridUzytkownicy.Size = new System.Drawing.Size(960, 248);
            this.dataGridUzytkownicy.TabIndex = 0;
            this.dataGridUzytkownicy.SelectionChanged += new System.EventHandler(this.dataGridUzytkownicy_SelectionChanged);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnDodaj.Location = new System.Drawing.Point(554, 330);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(156, 30);
            this.btnDodaj.TabIndex = 1;
            this.btnDodaj.Text = "Dodaj uzytkownika";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnEdytuj
            // 
            this.btnEdytuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnEdytuj.Location = new System.Drawing.Point(586, 366);
            this.btnEdytuj.Name = "btnEdytuj";
            this.btnEdytuj.Size = new System.Drawing.Size(92, 30);
            this.btnEdytuj.TabIndex = 2;
            this.btnEdytuj.Text = "Edytuj";
            this.btnEdytuj.UseVisualStyleBackColor = true;
            this.btnEdytuj.Click += new System.EventHandler(this.btnEdytuj_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnUsun.Location = new System.Drawing.Point(586, 438);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(92, 30);
            this.btnUsun.TabIndex = 3;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // btnZmienHaslo
            // 
            this.btnZmienHaslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnZmienHaslo.Location = new System.Drawing.Point(576, 402);
            this.btnZmienHaslo.Name = "btnZmienHaslo";
            this.btnZmienHaslo.Size = new System.Drawing.Size(113, 30);
            this.btnZmienHaslo.TabIndex = 4;
            this.btnZmienHaslo.Text = "Zmień hasło";
            this.btnZmienHaslo.UseVisualStyleBackColor = true;
            this.btnZmienHaslo.Click += new System.EventHandler(this.btnZmienHaslo_Click);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.btnAnuluj);
            this.groupBoxDetails.Controls.Add(this.btnZapisz);
            this.groupBoxDetails.Controls.Add(this.comboRola);
            this.groupBoxDetails.Controls.Add(this.lblRola);
            this.groupBoxDetails.Controls.Add(this.txtHaslo);
            this.groupBoxDetails.Controls.Add(this.lblHaslo);
            this.groupBoxDetails.Controls.Add(this.txtEmail);
            this.groupBoxDetails.Controls.Add(this.lblEmail);
            this.groupBoxDetails.Controls.Add(this.txtNazwisko);
            this.groupBoxDetails.Controls.Add(this.lblNazwisko);
            this.groupBoxDetails.Controls.Add(this.txtImie);
            this.groupBoxDetails.Controls.Add(this.lblImie);
            this.groupBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 277);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(440, 251);
            this.groupBoxDetails.TabIndex = 5;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Dodaj nowego użytkownika";
            // 
            // groupBoxPassword
            // 
            this.groupBoxPassword.Controls.Add(this.btnAnulujHaslo);
            this.groupBoxPassword.Controls.Add(this.btnZapiszHaslo);
            this.groupBoxPassword.Controls.Add(this.txtPotwierdzHaslo);
            this.groupBoxPassword.Controls.Add(this.lblPotwierdzHaslo);
            this.groupBoxPassword.Controls.Add(this.txtNoweHaslo);
            this.groupBoxPassword.Controls.Add(this.lblNoweHaslo);
            this.groupBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBoxPassword.Location = new System.Drawing.Point(12, 277);
            this.groupBoxPassword.Name = "groupBoxPassword";
            this.groupBoxPassword.Size = new System.Drawing.Size(440, 251);
            this.groupBoxPassword.TabIndex = 12;
            this.groupBoxPassword.TabStop = false;
            this.groupBoxPassword.Text = "Podaj nowe hasło";
            // 
            // btnAnulujHaslo
            // 
            this.btnAnulujHaslo.Location = new System.Drawing.Point(351, 213);
            this.btnAnulujHaslo.Name = "btnAnulujHaslo";
            this.btnAnulujHaslo.Size = new System.Drawing.Size(77, 28);
            this.btnAnulujHaslo.TabIndex = 5;
            this.btnAnulujHaslo.Text = "Anuluj";
            this.btnAnulujHaslo.UseVisualStyleBackColor = true;
            this.btnAnulujHaslo.Click += new System.EventHandler(this.btnAnulujHaslo_Click);
            // 
            // btnZapiszHaslo
            // 
            this.btnZapiszHaslo.Location = new System.Drawing.Point(6, 212);
            this.btnZapiszHaslo.Name = "btnZapiszHaslo";
            this.btnZapiszHaslo.Size = new System.Drawing.Size(116, 28);
            this.btnZapiszHaslo.TabIndex = 4;
            this.btnZapiszHaslo.Text = "Zapisz hasło";
            this.btnZapiszHaslo.UseVisualStyleBackColor = true;
            this.btnZapiszHaslo.Click += new System.EventHandler(this.btnZapiszHaslo_Click);
            // 
            // txtPotwierdzHaslo
            // 
            this.txtPotwierdzHaslo.Location = new System.Drawing.Point(172, 107);
            this.txtPotwierdzHaslo.Name = "txtPotwierdzHaslo";
            this.txtPotwierdzHaslo.PasswordChar = '*';
            this.txtPotwierdzHaslo.Size = new System.Drawing.Size(186, 26);
            this.txtPotwierdzHaslo.TabIndex = 3;
            // 
            // lblPotwierdzHaslo
            // 
            this.lblPotwierdzHaslo.AutoSize = true;
            this.lblPotwierdzHaslo.Location = new System.Drawing.Point(47, 110);
            this.lblPotwierdzHaslo.Name = "lblPotwierdzHaslo";
            this.lblPotwierdzHaslo.Size = new System.Drawing.Size(70, 20);
            this.lblPotwierdzHaslo.TabIndex = 2;
            this.lblPotwierdzHaslo.Text = "Powtórz";
            // 
            // txtNoweHaslo
            // 
            this.txtNoweHaslo.Location = new System.Drawing.Point(172, 61);
            this.txtNoweHaslo.Name = "txtNoweHaslo";
            this.txtNoweHaslo.PasswordChar = '*';
            this.txtNoweHaslo.Size = new System.Drawing.Size(186, 26);
            this.txtNoweHaslo.TabIndex = 1;
            // 
            // lblNoweHaslo
            // 
            this.lblNoweHaslo.AutoSize = true;
            this.lblNoweHaslo.Location = new System.Drawing.Point(47, 61);
            this.lblNoweHaslo.Name = "lblNoweHaslo";
            this.lblNoweHaslo.Size = new System.Drawing.Size(96, 20);
            this.lblNoweHaslo.TabIndex = 0;
            this.lblNoweHaslo.Text = "Nowe hasło";
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(340, 212);
            this.btnAnuluj.Name = "btnAnuluj";
            this.btnAnuluj.Size = new System.Drawing.Size(94, 33);
            this.btnAnuluj.TabIndex = 11;
            this.btnAnuluj.Text = "Anuluj";
            this.btnAnuluj.UseVisualStyleBackColor = true;
            this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click);
            // 
            // btnZapisz
            // 
            this.btnZapisz.Location = new System.Drawing.Point(6, 212);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(94, 33);
            this.btnZapisz.TabIndex = 10;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = true;
            this.btnZapisz.Click += new System.EventHandler(this.btnZapisz_Click);
            // 
            // comboRola
            // 
            this.comboRola.FormattingEnabled = true;
            this.comboRola.Location = new System.Drawing.Point(178, 163);
            this.comboRola.Name = "comboRola";
            this.comboRola.Size = new System.Drawing.Size(216, 28);
            this.comboRola.TabIndex = 9;
            // 
            // lblRola
            // 
            this.lblRola.AutoSize = true;
            this.lblRola.Location = new System.Drawing.Point(53, 171);
            this.lblRola.Name = "lblRola";
            this.lblRola.Size = new System.Drawing.Size(43, 20);
            this.lblRola.TabIndex = 8;
            this.lblRola.Text = "Rola";
            // 
            // txtHaslo
            // 
            this.txtHaslo.Location = new System.Drawing.Point(178, 129);
            this.txtHaslo.Name = "txtHaslo";
            this.txtHaslo.PasswordChar = '*';
            this.txtHaslo.Size = new System.Drawing.Size(216, 26);
            this.txtHaslo.TabIndex = 7;
            // 
            // lblHaslo
            // 
            this.lblHaslo.AutoSize = true;
            this.lblHaslo.Location = new System.Drawing.Point(53, 132);
            this.lblHaslo.Name = "lblHaslo";
            this.lblHaslo.Size = new System.Drawing.Size(53, 20);
            this.lblHaslo.TabIndex = 6;
            this.lblHaslo.Text = "Hasło";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(178, 93);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(216, 26);
            this.txtEmail.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(53, 96);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 20);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email";
            // 
            // txtNazwisko
            // 
            this.txtNazwisko.Location = new System.Drawing.Point(178, 57);
            this.txtNazwisko.Name = "txtNazwisko";
            this.txtNazwisko.Size = new System.Drawing.Size(216, 26);
            this.txtNazwisko.TabIndex = 3;
            // 
            // lblNazwisko
            // 
            this.lblNazwisko.AutoSize = true;
            this.lblNazwisko.Location = new System.Drawing.Point(53, 60);
            this.lblNazwisko.Name = "lblNazwisko";
            this.lblNazwisko.Size = new System.Drawing.Size(81, 20);
            this.lblNazwisko.TabIndex = 2;
            this.lblNazwisko.Text = "Nazwisko";
            // 
            // txtImie
            // 
            this.txtImie.Location = new System.Drawing.Point(178, 25);
            this.txtImie.Name = "txtImie";
            this.txtImie.Size = new System.Drawing.Size(216, 26);
            this.txtImie.TabIndex = 1;
            // 
            // lblImie
            // 
            this.lblImie.AutoSize = true;
            this.lblImie.Location = new System.Drawing.Point(53, 28);
            this.lblImie.Name = "lblImie";
            this.lblImie.Size = new System.Drawing.Size(40, 20);
            this.lblImie.TabIndex = 0;
            this.lblImie.Text = "Imię";
            // 
            // UzytkownicyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 561);
            this.Controls.Add(this.groupBoxPassword);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.btnZmienHaslo);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnEdytuj);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dataGridUzytkownicy);
            this.Name = "UzytkownicyForm";
            this.Text = "UzytkownicyForm";
            this.Load += new System.EventHandler(this.UzytkownicyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridUzytkownicy)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.groupBoxPassword.ResumeLayout(false);
            this.groupBoxPassword.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridUzytkownicy;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnEdytuj;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.Button btnZmienHaslo;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.Label lblRola;
        private System.Windows.Forms.TextBox txtHaslo;
        private System.Windows.Forms.Label lblHaslo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtNazwisko;
        private System.Windows.Forms.Label lblNazwisko;
        private System.Windows.Forms.TextBox txtImie;
        private System.Windows.Forms.Label lblImie;
        private System.Windows.Forms.ComboBox comboRola;
        private System.Windows.Forms.GroupBox groupBoxPassword;
        private System.Windows.Forms.Button btnAnulujHaslo;
        private System.Windows.Forms.Button btnZapiszHaslo;
        private System.Windows.Forms.TextBox txtPotwierdzHaslo;
        private System.Windows.Forms.Label lblPotwierdzHaslo;
        private System.Windows.Forms.TextBox txtNoweHaslo;
        private System.Windows.Forms.Label lblNoweHaslo;
        private System.Windows.Forms.Button btnAnuluj;
        private System.Windows.Forms.Button btnZapisz;
    }
}