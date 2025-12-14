namespace towerDefenseGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlOyunAlani = new Panel();
            panelUst = new Panel();
            lblAltin = new Label();
            lblCan = new Label();
            lblDalga = new Label();
            lblSkor = new Label();
            lblSecilenKule = new Label();
            panelAlt = new Panel();
            btnOkKulesi = new Button();
            btnTopKulesi = new Button();
            btnBuyuKulesi = new Button();
            btnDalgaBaslat = new Button();
            oyunDongusuTimer = new System.Windows.Forms.Timer(components);
            panelUst.SuspendLayout();
            panelAlt.SuspendLayout();
            SuspendLayout();
            // 
            // panelUst
            // 
            panelUst.BackColor = Color.FromArgb(25, 25, 40);
            panelUst.Controls.Add(lblAltin);
            panelUst.Controls.Add(lblCan);
            panelUst.Controls.Add(lblDalga);
            panelUst.Controls.Add(lblSkor);
            panelUst.Controls.Add(lblSecilenKule);
            panelUst.Dock = DockStyle.Top;
            panelUst.Location = new Point(0, 0);
            panelUst.Name = "panelUst";
            panelUst.Padding = new Padding(20, 15, 20, 15);
            panelUst.Size = new Size(1000, 70);
            panelUst.TabIndex = 2;
            // 
            // lblAltin
            // 
            lblAltin.AutoSize = true;
            lblAltin.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblAltin.ForeColor = Color.Gold;
            lblAltin.Location = new Point(30, 22);
            lblAltin.Name = "lblAltin";
            lblAltin.Size = new Size(124, 25);
            lblAltin.TabIndex = 0;
            lblAltin.Text = "💰 Altın: 200";
            // 
            // lblCan
            // 
            lblCan.AutoSize = true;
            lblCan.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCan.ForeColor = Color.Tomato;
            lblCan.Location = new Point(200, 22);
            lblCan.Name = "lblCan";
            lblCan.Size = new Size(105, 25);
            lblCan.TabIndex = 1;
            lblCan.Text = "❤️ Can: 10";
            // 
            // lblDalga
            // 
            lblDalga.AutoSize = true;
            lblDalga.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDalga.ForeColor = Color.DeepSkyBlue;
            lblDalga.Location = new Point(370, 22);
            lblDalga.Name = "lblDalga";
            lblDalga.Size = new Size(151, 25);
            lblDalga.TabIndex = 2;
            lblDalga.Text = "🌊 Dalga: 1 / 10";
            // 
            // lblSkor
            // 
            lblSkor.AutoSize = true;
            lblSkor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblSkor.ForeColor = Color.LimeGreen;
            lblSkor.Location = new Point(570, 22);
            lblSkor.Name = "lblSkor";
            lblSkor.Size = new Size(98, 25);
            lblSkor.TabIndex = 3;
            lblSkor.Text = "⭐ Skor: 0";
            // 
            // lblSecilenKule
            // 
            lblSecilenKule.AutoSize = true;
            lblSecilenKule.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            lblSecilenKule.ForeColor = Color.Silver;
            lblSecilenKule.Location = new Point(760, 25);
            lblSecilenKule.Name = "lblSecilenKule";
            lblSecilenKule.Size = new Size(82, 20);
            lblSecilenKule.TabIndex = 4;
            lblSecilenKule.Text = "Kule seçin...";
            // 
            // panelAlt
            // 
            panelAlt.BackColor = Color.FromArgb(30, 30, 50);
            panelAlt.Controls.Add(btnOkKulesi);
            panelAlt.Controls.Add(btnTopKulesi);
            panelAlt.Controls.Add(btnBuyuKulesi);
            panelAlt.Controls.Add(btnDalgaBaslat);
            panelAlt.Dock = DockStyle.Bottom;
            panelAlt.Location = new Point(0, 500);
            panelAlt.Name = "panelAlt";
            panelAlt.Padding = new Padding(20, 10, 20, 10);
            panelAlt.Size = new Size(1000, 100);
            panelAlt.TabIndex = 1;
            // 
            // btnOkKulesi
            // 
            btnOkKulesi.BackColor = Color.FromArgb(70, 130, 50);
            btnOkKulesi.Cursor = Cursors.Hand;
            btnOkKulesi.FlatAppearance.BorderColor = Color.LimeGreen;
            btnOkKulesi.FlatAppearance.BorderSize = 2;
            btnOkKulesi.FlatStyle = FlatStyle.Flat;
            btnOkKulesi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnOkKulesi.ForeColor = Color.White;
            btnOkKulesi.Location = new Point(50, 15);
            btnOkKulesi.Name = "btnOkKulesi";
            btnOkKulesi.Size = new Size(180, 70);
            btnOkKulesi.TabIndex = 0;
            btnOkKulesi.Text = "🏹 Ok Kulesi\n💰 100 Altın";
            btnOkKulesi.UseVisualStyleBackColor = false;
            btnOkKulesi.Click += btnOkKulesi_Click;
            // 
            // btnTopKulesi
            // 
            btnTopKulesi.BackColor = Color.FromArgb(140, 70, 50);
            btnTopKulesi.Cursor = Cursors.Hand;
            btnTopKulesi.FlatAppearance.BorderColor = Color.OrangeRed;
            btnTopKulesi.FlatAppearance.BorderSize = 2;
            btnTopKulesi.FlatStyle = FlatStyle.Flat;
            btnTopKulesi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnTopKulesi.ForeColor = Color.White;
            btnTopKulesi.Location = new Point(260, 15);
            btnTopKulesi.Name = "btnTopKulesi";
            btnTopKulesi.Size = new Size(180, 70);
            btnTopKulesi.TabIndex = 1;
            btnTopKulesi.Text = "💣 Top Kulesi\n💰 250 Altın";
            btnTopKulesi.UseVisualStyleBackColor = false;
            btnTopKulesi.Click += btnTopKulesi_Click;
            // 
            // btnBuyuKulesi
            // 
            btnBuyuKulesi.BackColor = Color.FromArgb(80, 50, 140);
            btnBuyuKulesi.Cursor = Cursors.Hand;
            btnBuyuKulesi.FlatAppearance.BorderColor = Color.MediumPurple;
            btnBuyuKulesi.FlatAppearance.BorderSize = 2;
            btnBuyuKulesi.FlatStyle = FlatStyle.Flat;
            btnBuyuKulesi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBuyuKulesi.ForeColor = Color.White;
            btnBuyuKulesi.Location = new Point(470, 15);
            btnBuyuKulesi.Name = "btnBuyuKulesi";
            btnBuyuKulesi.Size = new Size(180, 70);
            btnBuyuKulesi.TabIndex = 2;
            btnBuyuKulesi.Text = "✨ Büyü Kulesi\n💰 200 Altın";
            btnBuyuKulesi.UseVisualStyleBackColor = false;
            btnBuyuKulesi.Click += btnBuyuKulesi_Click;
            // 
            // btnDalgaBaslat
            // 
            btnDalgaBaslat.BackColor = Color.FromArgb(200, 50, 50);
            btnDalgaBaslat.Cursor = Cursors.Hand;
            btnDalgaBaslat.FlatAppearance.BorderColor = Color.Red;
            btnDalgaBaslat.FlatAppearance.BorderSize = 2;
            btnDalgaBaslat.FlatStyle = FlatStyle.Flat;
            btnDalgaBaslat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDalgaBaslat.ForeColor = Color.White;
            btnDalgaBaslat.Location = new Point(750, 15);
            btnDalgaBaslat.Name = "btnDalgaBaslat";
            btnDalgaBaslat.Size = new Size(200, 70);
            btnDalgaBaslat.TabIndex = 3;
            btnDalgaBaslat.Text = "⚔️ DALGA BAŞLAT";
            btnDalgaBaslat.UseVisualStyleBackColor = false;
            btnDalgaBaslat.Click += btnDalgaBaslat_Click;
            // 
            // oyunDongusuTimer
            // 
            oyunDongusuTimer.Interval = 50;
            oyunDongusuTimer.Tick += oyunDongusuTimer_Tick;
            // 
            // pnlOyunAlani
            // 
            pnlOyunAlani.BackColor = Color.FromArgb(34, 85, 51);
            pnlOyunAlani.Dock = DockStyle.Fill;
            pnlOyunAlani.Location = new Point(0, 70);
            pnlOyunAlani.Name = "pnlOyunAlani";
            pnlOyunAlani.Size = new Size(1000, 430);
            pnlOyunAlani.TabIndex = 0;
            pnlOyunAlani.Paint += pnlOyunAlani_Paint;
            pnlOyunAlani.MouseClick += pnlOyunAlani_MouseClick;
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(18, 18, 28);
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlOyunAlani);
            Controls.Add(panelAlt);
            Controls.Add(panelUst);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kule Savunmasi - Tower Defense";
            panelUst.ResumeLayout(false);
            panelUst.PerformLayout();
            panelAlt.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlOyunAlani;
        private Panel panelUst;
        private Panel panelAlt;
        private Label lblAltin;
        private Label lblCan;
        private Label lblDalga;
        private Label lblSkor;
        private Label lblSecilenKule;
        private Button btnOkKulesi;
        private Button btnTopKulesi;
        private Button btnBuyuKulesi;
        private Button btnDalgaBaslat;
        private System.Windows.Forms.Timer oyunDongusuTimer;
    }
}
