namespace MultikinoAdmin.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFilmy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSale = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeanse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBilety = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRaporty = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUzytkownicy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWyloguj = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUserInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFilmy,
            this.menuSale,
            this.menuSeanse,
            this.menuBilety,
            this.menuRaporty,
            this.menuUzytkownicy,
            this.menuWyloguj});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFilmy
            // 
            this.menuFilmy.Name = "menuFilmy";
            this.menuFilmy.Size = new System.Drawing.Size(51, 20);
            this.menuFilmy.Text = "Filmy ";
            this.menuFilmy.Click += new System.EventHandler(this.menuFilmy_Click_1);
            // 
            // menuSale
            // 
            this.menuSale.Name = "menuSale";
            this.menuSale.Size = new System.Drawing.Size(40, 20);
            this.menuSale.Text = "Sale";
            this.menuSale.Click += new System.EventHandler(this.menuSale_Click_1);
            // 
            // menuSeanse
            // 
            this.menuSeanse.Name = "menuSeanse";
            this.menuSeanse.Size = new System.Drawing.Size(55, 20);
            this.menuSeanse.Text = "Seanse";
            this.menuSeanse.Click += new System.EventHandler(this.menuSeanse_Click_1);
            // 
            // menuBilety
            // 
            this.menuBilety.Name = "menuBilety";
            this.menuBilety.Size = new System.Drawing.Size(48, 20);
            this.menuBilety.Text = "Bilety";
            this.menuBilety.Click += new System.EventHandler(this.menuBilety_Click_1);
            // 
            // menuRaporty
            // 
            this.menuRaporty.Name = "menuRaporty";
            this.menuRaporty.Size = new System.Drawing.Size(63, 20);
            this.menuRaporty.Text = "Raporty ";
            this.menuRaporty.Click += new System.EventHandler(this.menuRaporty_Click_1);
            // 
            // menuUzytkownicy
            // 
            this.menuUzytkownicy.Name = "menuUzytkownicy";
            this.menuUzytkownicy.Size = new System.Drawing.Size(89, 20);
            this.menuUzytkownicy.Text = "Użytkownicy ";
            this.menuUzytkownicy.Click += new System.EventHandler(this.menuUzytkownicy_Click_1);
            // 
            // menuWyloguj
            // 
            this.menuWyloguj.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuWyloguj.Name = "menuWyloguj";
            this.menuWyloguj.Size = new System.Drawing.Size(66, 20);
            this.menuWyloguj.Text = "Wyloguj ";
            this.menuWyloguj.Click += new System.EventHandler(this.menuWyloguj_Click_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusConnection,
            this.lblUserInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 539);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // lblStatusConnection
            // 
            this.lblStatusConnection.Name = "lblStatusConnection";
            this.lblStatusConnection.Size = new System.Drawing.Size(118, 17);
            this.lblStatusConnection.Text = "toolStripStatusLabel1";
            this.lblStatusConnection.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(118, 17);
            this.lblUserInfo.Text = "toolStripStatusLabel2";
            this.lblUserInfo.Click += new System.EventHandler(this.lblUserInfo_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 24);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(800, 515);
            this.panelContent.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multikino - Panel administratora";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFilmy;
        private System.Windows.Forms.ToolStripMenuItem menuSale;
        private System.Windows.Forms.ToolStripMenuItem menuSeanse;
        private System.Windows.Forms.ToolStripMenuItem menuBilety;
        private System.Windows.Forms.ToolStripMenuItem menuRaporty;
        private System.Windows.Forms.ToolStripMenuItem menuUzytkownicy;
        private System.Windows.Forms.ToolStripMenuItem menuWyloguj;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusConnection;
        private System.Windows.Forms.ToolStripStatusLabel lblUserInfo;
        private System.Windows.Forms.Panel panelContent;
    }
}