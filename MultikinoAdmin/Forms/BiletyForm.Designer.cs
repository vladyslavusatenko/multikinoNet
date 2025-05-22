namespace MultikinoAdmin.Forms
{
    partial class BiletyForm
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
            this.dataGridBilety = new System.Windows.Forms.DataGridView();
            this.btnDrukuj = new System.Windows.Forms.Button();
            this.btnUsun = new System.Windows.Forms.Button();
            this.groupBoxDetails = new System.Windows.Forms.GroupBox();
            this.lblFilm = new System.Windows.Forms.Label();
            this.txtFilm = new System.Windows.Forms.TextBox();
            this.lblData = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.lblMiejsce = new System.Windows.Forms.Label();
            this.txtMiejsce = new System.Windows.Forms.TextBox();
            this.lblKlient = new System.Windows.Forms.Label();
            this.txtKlient = new System.Windows.Forms.TextBox();
            this.lblCena = new System.Windows.Forms.Label();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.lblDataZakupu = new System.Windows.Forms.Label();
            this.txtDataZakupu = new System.Windows.Forms.TextBox();
            this.btnZamknij = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBilety)).BeginInit();
            this.groupBoxDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridBilety
            // 
            this.dataGridBilety.AllowUserToAddRows = false;
            this.dataGridBilety.AllowUserToDeleteRows = false;
            this.dataGridBilety.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBilety.Location = new System.Drawing.Point(0, 0);
            this.dataGridBilety.Name = "dataGridBilety";
            this.dataGridBilety.ReadOnly = true;
            this.dataGridBilety.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBilety.Size = new System.Drawing.Size(799, 150);
            this.dataGridBilety.TabIndex = 0;
            this.dataGridBilety.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBilety_CellDoubleClick);
            this.dataGridBilety.SelectionChanged += new System.EventHandler(this.dataGridBilety_SelectionChanged);
            // 
            // btnDrukuj
            // 
            this.btnDrukuj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnDrukuj.Location = new System.Drawing.Point(620, 295);
            this.btnDrukuj.Name = "btnDrukuj";
            this.btnDrukuj.Size = new System.Drawing.Size(75, 32);
            this.btnDrukuj.TabIndex = 1;
            this.btnDrukuj.Text = "Drukuj";
            this.btnDrukuj.UseVisualStyleBackColor = true;
            this.btnDrukuj.Click += new System.EventHandler(this.btnDrukuj_Click);
            // 
            // btnUsun
            // 
            this.btnUsun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.btnUsun.Location = new System.Drawing.Point(620, 236);
            this.btnUsun.Name = "btnUsun";
            this.btnUsun.Size = new System.Drawing.Size(75, 32);
            this.btnUsun.TabIndex = 2;
            this.btnUsun.Text = "Usuń";
            this.btnUsun.UseVisualStyleBackColor = true;
            this.btnUsun.Click += new System.EventHandler(this.btnUsun_Click);
            // 
            // groupBoxDetails
            // 
            this.groupBoxDetails.Controls.Add(this.btnZamknij);
            this.groupBoxDetails.Controls.Add(this.txtDataZakupu);
            this.groupBoxDetails.Controls.Add(this.txtData);
            this.groupBoxDetails.Controls.Add(this.lblDataZakupu);
            this.groupBoxDetails.Controls.Add(this.lblData);
            this.groupBoxDetails.Controls.Add(this.lblMiejsce);
            this.groupBoxDetails.Controls.Add(this.txtCena);
            this.groupBoxDetails.Controls.Add(this.txtFilm);
            this.groupBoxDetails.Controls.Add(this.lblCena);
            this.groupBoxDetails.Controls.Add(this.txtMiejsce);
            this.groupBoxDetails.Controls.Add(this.lblFilm);
            this.groupBoxDetails.Controls.Add(this.txtKlient);
            this.groupBoxDetails.Controls.Add(this.lblKlient);
            this.groupBoxDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.groupBoxDetails.Location = new System.Drawing.Point(12, 165);
            this.groupBoxDetails.Name = "groupBoxDetails";
            this.groupBoxDetails.Size = new System.Drawing.Size(518, 372);
            this.groupBoxDetails.TabIndex = 3;
            this.groupBoxDetails.TabStop = false;
            this.groupBoxDetails.Text = "Szczególy biletu";
            // 
            // lblFilm
            // 
            this.lblFilm.AutoSize = true;
            this.lblFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblFilm.Location = new System.Drawing.Point(57, 44);
            this.lblFilm.Name = "lblFilm";
            this.lblFilm.Size = new System.Drawing.Size(41, 20);
            this.lblFilm.TabIndex = 0;
            this.lblFilm.Text = "Film";
            // 
            // txtFilm
            // 
            this.txtFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtFilm.Location = new System.Drawing.Point(193, 38);
            this.txtFilm.Name = "txtFilm";
            this.txtFilm.Size = new System.Drawing.Size(220, 26);
            this.txtFilm.TabIndex = 1;
            this.txtFilm.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblData.Location = new System.Drawing.Point(57, 90);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(45, 20);
            this.lblData.TabIndex = 2;
            this.lblData.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtData.Location = new System.Drawing.Point(193, 84);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(220, 26);
            this.txtData.TabIndex = 3;
            // 
            // lblMiejsce
            // 
            this.lblMiejsce.AutoSize = true;
            this.lblMiejsce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblMiejsce.Location = new System.Drawing.Point(57, 136);
            this.lblMiejsce.Name = "lblMiejsce";
            this.lblMiejsce.Size = new System.Drawing.Size(67, 20);
            this.lblMiejsce.TabIndex = 4;
            this.lblMiejsce.Text = "Miejsce";
            this.lblMiejsce.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtMiejsce
            // 
            this.txtMiejsce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtMiejsce.Location = new System.Drawing.Point(193, 133);
            this.txtMiejsce.Name = "txtMiejsce";
            this.txtMiejsce.Size = new System.Drawing.Size(220, 26);
            this.txtMiejsce.TabIndex = 5;
            this.txtMiejsce.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // lblKlient
            // 
            this.lblKlient.AutoSize = true;
            this.lblKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblKlient.Location = new System.Drawing.Point(57, 181);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(51, 20);
            this.lblKlient.TabIndex = 6;
            this.lblKlient.Text = "Klient";
            // 
            // txtKlient
            // 
            this.txtKlient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtKlient.Location = new System.Drawing.Point(193, 178);
            this.txtKlient.Name = "txtKlient";
            this.txtKlient.Size = new System.Drawing.Size(220, 26);
            this.txtKlient.TabIndex = 7;
            // 
            // lblCena
            // 
            this.lblCena.AutoSize = true;
            this.lblCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblCena.Location = new System.Drawing.Point(57, 224);
            this.lblCena.Name = "lblCena";
            this.lblCena.Size = new System.Drawing.Size(48, 20);
            this.lblCena.TabIndex = 8;
            this.lblCena.Text = "Cena";
            // 
            // txtCena
            // 
            this.txtCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtCena.Location = new System.Drawing.Point(193, 221);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(220, 26);
            this.txtCena.TabIndex = 9;
            // 
            // lblDataZakupu
            // 
            this.lblDataZakupu.AutoSize = true;
            this.lblDataZakupu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.lblDataZakupu.Location = new System.Drawing.Point(57, 268);
            this.lblDataZakupu.Name = "lblDataZakupu";
            this.lblDataZakupu.Size = new System.Drawing.Size(103, 20);
            this.lblDataZakupu.TabIndex = 10;
            this.lblDataZakupu.Text = "Data zakupu";
            // 
            // txtDataZakupu
            // 
            this.txtDataZakupu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.txtDataZakupu.Location = new System.Drawing.Point(193, 262);
            this.txtDataZakupu.Name = "txtDataZakupu";
            this.txtDataZakupu.Size = new System.Drawing.Size(220, 26);
            this.txtDataZakupu.TabIndex = 11;
            // 
            // btnZamknij
            // 
            this.btnZamknij.Location = new System.Drawing.Point(415, 324);
            this.btnZamknij.Name = "btnZamknij";
            this.btnZamknij.Size = new System.Drawing.Size(78, 30);
            this.btnZamknij.TabIndex = 12;
            this.btnZamknij.Text = "Zamknij";
            this.btnZamknij.UseVisualStyleBackColor = true;
            this.btnZamknij.Click += new System.EventHandler(this.btnZamknij_Click);
            // 
            // BiletyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.groupBoxDetails);
            this.Controls.Add(this.btnUsun);
            this.Controls.Add(this.btnDrukuj);
            this.Controls.Add(this.dataGridBilety);
            this.Name = "BiletyForm";
            this.Text = "BiletyForm";
            this.Load += new System.EventHandler(this.BiletyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBilety)).EndInit();
            this.groupBoxDetails.ResumeLayout(false);
            this.groupBoxDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridBilety;
        private System.Windows.Forms.Button btnDrukuj;
        private System.Windows.Forms.Button btnUsun;
        private System.Windows.Forms.GroupBox groupBoxDetails;
        private System.Windows.Forms.TextBox txtDataZakupu;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label lblDataZakupu;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblMiejsce;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.TextBox txtFilm;
        private System.Windows.Forms.Label lblCena;
        private System.Windows.Forms.TextBox txtMiejsce;
        private System.Windows.Forms.Label lblFilm;
        private System.Windows.Forms.TextBox txtKlient;
        private System.Windows.Forms.Label lblKlient;
        private System.Windows.Forms.Button btnZamknij;
    }
}