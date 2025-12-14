using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace towerDefenseGame
{
    public partial class Form1 : Form
    {
       
        private int altin = 200;
        private int can = 10;
        private int skor = 0;
        private int mevcutDalga = 0;
        private const int MAX_DALGA = 10;

        // Aktif nesneler
        private List<Kule> aktifKuleler = new List<Kule>();
        private List<Dusman> aktifDusmanlar = new List<Dusman>();
        private List<Mermi> aktifMermiler = new List<Mermi>();

        // Kule secimi
        private int seciliKuleTuru = 0;
        private Kule seciliKule = null;

        // Dalga durumu
        private bool dalgaAktif = false;
        private int spawnSayaci = 0;
        private int spawnHedefi = 0;
        private int spawnGecikme = 0;

        // Mevcut dalga dusman bilgileri
        private int dalgaDusmanCani = 100;
        private double dalgaDusmanHizi = 2.0;
        private int dalgaAltinDegeri = 10;

        // Yol koordinatlari
        private List<Point> yolKoordinatlari = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            YoluTanimla();
            UIGuncelle();
        }

        private void YoluTanimla()
        {
            yolKoordinatlari = new List<Point>
            {
                new Point(0, 200),
                new Point(200, 200),
                new Point(200, 100),
                new Point(600, 100),
                new Point(600, 300),
                new Point(400, 300),
                new Point(400, 350),
                new Point(900, 350),
                new Point(1000, 350)
            };
        }

        private void UIGuncelle()
        {
            lblAltin.Text = "Altin: " + altin;
            lblCan.Text = "Can: " + can;
            lblDalga.Text = "Dalga: " + mevcutDalga + " / " + MAX_DALGA;
            lblSkor.Text = "Skor: " + skor;
        }

        private void btnDalgaBaslat_Click(object sender, EventArgs e)
        {
            if (!dalgaAktif && mevcutDalga < MAX_DALGA)
            {
                mevcutDalga++;
                DalgaBaslat(mevcutDalga);
            }
        }

        private void DalgaBaslat(int dalgaSeviyesi)
        {
            dalgaAktif = true;
            int dusmanSayisi = 5 + (dalgaSeviyesi * 2);
            dalgaDusmanCani = 80 + (dalgaSeviyesi * 20);
            dalgaDusmanHizi = 1.5 + (dalgaSeviyesi * 0.2);
            dalgaAltinDegeri = 10 + (dalgaSeviyesi * 2);

            spawnSayaci = 0;
            spawnHedefi = dusmanSayisi;
            spawnGecikme = 0;

            oyunDongusuTimer.Start();
            lblSecilenKule.Text = "Dalga " + dalgaSeviyesi + " basladi!";
            UIGuncelle();
        }

        private void oyunDongusuTimer_Tick(object sender, EventArgs e)
        {
            if (dalgaAktif && spawnSayaci < spawnHedefi)
            {
                spawnGecikme++;
                if (spawnGecikme >= 20)
                {
                    DusmanYarat(dalgaDusmanCani, dalgaDusmanHizi, dalgaAltinDegeri, yolKoordinatlari[0]);
                    spawnSayaci++;
                    spawnGecikme = 0;
                }
            }

            foreach (var dusman in aktifDusmanlar.ToList())
            {
                dusman.HareketEt();
            }

            KuleleriSaldir();
            MermileriKontrolEt();
            DusmanlariTemizle();
            DalgaKontrolEt();
            UIGuncelle();
            pnlOyunAlani.Invalidate();
        }

        private void DusmanYarat(int dusmanCani, double hiz, int altinDegeri, Point baslangicKonumu)
        {
            PictureBox dusmanPBox = new PictureBox
            {
                Size = new Size(25, 25),
                Location = new Point(baslangicKonumu.X - 12, baslangicKonumu.Y - 12),
                BackColor = Color.Brown,
                Tag = "Dusman"
            };

            Dusman yeniDusman = new Dusman(dusmanCani, hiz, altinDegeri, dusmanPBox);
            yeniDusman.YolNoktalari = yolKoordinatlari.ToArray();

            pnlOyunAlani.Controls.Add(dusmanPBox);
            aktifDusmanlar.Add(yeniDusman);
            dusmanPBox.BringToFront();
        }

        private void KuleleriSaldir()
        {
            DateTime simdi = DateTime.Now;

            foreach (var kule in aktifKuleler)
            {
                if ((simdi - kule.SonSaldiriZamani).TotalSeconds < kule.SaldiriHizi)
                    continue;

                Point kuleMerkez = new Point(
                    kule.Gorunumu.Left + kule.Gorunumu.Width / 2,
                    kule.Gorunumu.Top + kule.Gorunumu.Height / 2
                );

                var menzildekiDusmanlar = aktifDusmanlar.Where(d =>
                {
                    Point dusmanMerkez = new Point(
                        d.Gorunumu.Left + d.Gorunumu.Width / 2,
                        d.Gorunumu.Top + d.Gorunumu.Height / 2
                    );
                    double mesafe = Math.Sqrt(
                        Math.Pow(kuleMerkez.X - dusmanMerkez.X, 2) +
                        Math.Pow(kuleMerkez.Y - dusmanMerkez.Y, 2)
                    );
                    return mesafe <= kule.Menzil;
                }).OrderBy(d => d.MevcutYolIndex).ToList();

                if (!menzildekiDusmanlar.Any()) continue;

                kule.SonSaldiriZamani = simdi;

                if (kule is OkKulesi)
                {
                    var hedef = menzildekiDusmanlar.LastOrDefault();
                    if (hedef != null)
                    {
                        MermiOlustur(kule, hedef, Color.Yellow);
                        kule.Saldir(new List<Dusman> { hedef });
                    }
                }
                else if (kule is TopKulesi)
                {
                    foreach (var d in menzildekiDusmanlar)
                    {
                        MermiOlustur(kule, d, Color.OrangeRed);
                    }
                    kule.Saldir(menzildekiDusmanlar);
                }
                else if (kule is BuyuKulesi)
                {
                    var top5 = menzildekiDusmanlar.Take(5).ToList();
                    foreach (var d in top5)
                    {
                        MermiOlustur(kule, d, Color.MediumPurple);
                    }
                    kule.Saldir(top5);
                }
            }
        }

        private void MermiOlustur(Kule kule, Dusman hedef, Color renk)
        {
            Point baslangic = new Point(
                kule.Gorunumu.Location.X + kule.Gorunumu.Width / 2,
                kule.Gorunumu.Location.Y + kule.Gorunumu.Height / 2
            );

            PictureBox mermiPBox = new PictureBox
            {
                Size = new Size(8, 8),
                Location = baslangic,
                BackColor = renk,
                Tag = "Mermi"
            };

            Mermi yeniMermi = new Mermi(baslangic, hedef, kule, mermiPBox);
            pnlOyunAlani.Controls.Add(mermiPBox);
            aktifMermiler.Add(yeniMermi);
            mermiPBox.BringToFront();
        }

        private void MermileriKontrolEt()
        {
            List<Mermi> silinecekler = new List<Mermi>();

            foreach (var mermi in aktifMermiler)
            {
                if (mermi.Hedef == null || !aktifDusmanlar.Contains(mermi.Hedef))
                {
                    silinecekler.Add(mermi);
                    continue;
                }

                Point hedefMerkez = new Point(
                    mermi.Hedef.Gorunumu.Left + mermi.Hedef.Gorunumu.Width / 2,
                    mermi.Hedef.Gorunumu.Top + mermi.Hedef.Gorunumu.Height / 2
                );

                Point mermiKonum = mermi.Gorunumu.Location;
                double mesafe = Math.Sqrt(
                    Math.Pow(hedefMerkez.X - mermiKonum.X, 2) +
                    Math.Pow(hedefMerkez.Y - mermiKonum.Y, 2)
                );

                if (mesafe < mermi.Hiz)
                {
                    silinecekler.Add(mermi);
                }
                else
                {
                    float yonX = (float)((hedefMerkez.X - mermiKonum.X) / mesafe);
                    float yonY = (float)((hedefMerkez.Y - mermiKonum.Y) / mesafe);
                    mermi.Gorunumu.Location = new Point(
                        (int)(mermiKonum.X + yonX * mermi.Hiz),
                        (int)(mermiKonum.Y + yonY * mermi.Hiz)
                    );
                }
            }

            foreach (var mermi in silinecekler)
            {
                pnlOyunAlani.Controls.Remove(mermi.Gorunumu);
                aktifMermiler.Remove(mermi);
            }
        }

        private void DusmanlariTemizle()
        {
            for (int i = aktifDusmanlar.Count - 1; i >= 0; i--)
            {
                Dusman dusman = aktifDusmanlar[i];

                if (dusman.Can <= 0)
                {
                    altin += dusman.AltinDegeri;
                    skor += dusman.AltinDegeri * 10;
                    pnlOyunAlani.Controls.Remove(dusman.Gorunumu);
                    aktifDusmanlar.RemoveAt(i);
                }
                else if (dusman.HedefeUlastiMi)
                {
                    can--;
                    pnlOyunAlani.Controls.Remove(dusman.Gorunumu);
                    aktifDusmanlar.RemoveAt(i);

                    if (can <= 0)
                    {
                        OyunBitti(false);
                    }
                }
            }
        }

        private void DalgaKontrolEt()
        {
            if (dalgaAktif && spawnSayaci >= spawnHedefi && aktifDusmanlar.Count == 0)
            {
                dalgaAktif = false;
                lblSecilenKule.Text = "Dalga tamamlandi! Kule secin.";
                altin += 50;

                if (mevcutDalga >= MAX_DALGA)
                {
                    OyunBitti(true);
                }
            }
        }

        private void OyunBitti(bool kazandi)
        {
            oyunDongusuTimer.Stop();

            string mesaj = kazandi
                ? "TEBRIKLER! Oyunu kazandiniz!\n\nSkorunuz: " + skor + "\nKalan Can: " + can
                : "Oyun Bitti!\n\nUlasilan Dalga: " + mevcutDalga + "\nSkorunuz: " + skor;

            string baslik = kazandi ? "Zafer!" : "Maglubiyet";
            MessageBox.Show(mesaj, baslik, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool YolUzerindeMi(Point tiklananNokta)
        {
            int yaricap = 25;

            for (int i = 0; i < yolKoordinatlari.Count - 1; i++)
            {
                Point A = yolKoordinatlari[i];
                Point B = yolKoordinatlari[i + 1];

                Rectangle yolAlani = new Rectangle(
                    Math.Min(A.X, B.X) - yaricap,
                    Math.Min(A.Y, B.Y) - yaricap,
                    Math.Abs(A.X - B.X) + yaricap * 2,
                    Math.Abs(A.Y - B.Y) + yaricap * 2
                );

                if (yolAlani.Contains(tiklananNokta))
                    return true;
            }
            return false;
        }

        private void btnOkKulesi_Click(object sender, EventArgs e)
        {
            seciliKuleTuru = 1;
            lblSecilenKule.Text = "Ok Kulesi secildi (100 Altin)";
        }

        private void btnTopKulesi_Click(object sender, EventArgs e)
        {
            seciliKuleTuru = 2;
            lblSecilenKule.Text = "Top Kulesi secildi (250 Altin)";
        }

        private void btnBuyuKulesi_Click(object sender, EventArgs e)
        {
            seciliKuleTuru = 3;
            lblSecilenKule.Text = "Buyu Kulesi secildi (200 Altin)";
        }

        private void pnlOyunAlani_MouseClick(object sender, MouseEventArgs e)
        {
            if (seciliKuleTuru == 0) return;

            Kule yeniKule = null;
            Color kuleRengi = Color.Gray;

            switch (seciliKuleTuru)
            {
                case 1:
                    yeniKule = new OkKulesi();
                    kuleRengi = Color.FromArgb(70, 180, 70);
                    break;
                case 2:
                    yeniKule = new TopKulesi();
                    kuleRengi = Color.FromArgb(200, 100, 50);
                    break;
                case 3:
                    yeniKule = new BuyuKulesi();
                    kuleRengi = Color.FromArgb(140, 80, 200);
                    break;
            }

            if (yeniKule == null) return;

            if (altin < yeniKule.Fiyat)
            {
                MessageBox.Show("Yeterli altin yok!", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (YolUzerindeMi(e.Location))
            {
                MessageBox.Show("Yol uzerine kule kurulamaz!", "Uyari", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PictureBox kulePBox = new PictureBox
            {
                Size = new Size(35, 35),
                Location = new Point(e.X - 17, e.Y - 17),
                BackColor = kuleRengi,
                BorderStyle = BorderStyle.FixedSingle,
                Tag = yeniKule
            };

            yeniKule.Gorunumu = kulePBox;
            yeniKule.X = e.X;
            yeniKule.Y = e.Y;

            aktifKuleler.Add(yeniKule);
            pnlOyunAlani.Controls.Add(kulePBox);
            kulePBox.BringToFront();

            altin -= yeniKule.Fiyat;
            seciliKuleTuru = 0;
            lblSecilenKule.Text = "Kule secin...";
            UIGuncelle();
        }

        private void pnlOyunAlani_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (yolKoordinatlari.Count > 1)
            {
                using (Pen yolPen = new Pen(Color.FromArgb(139, 119, 101), 40))
                {
                    yolPen.StartCap = LineCap.Round;
                    yolPen.EndCap = LineCap.Round;
                    yolPen.LineJoin = LineJoin.Round;

                    for (int i = 0; i < yolKoordinatlari.Count - 1; i++)
                    {
                        g.DrawLine(yolPen, yolKoordinatlari[i], yolKoordinatlari[i + 1]);
                    }
                }
            }

            foreach (var kule in aktifKuleler)
            {
                Point merkez = new Point(
                    kule.Gorunumu.Left + kule.Gorunumu.Width / 2,
                    kule.Gorunumu.Top + kule.Gorunumu.Height / 2
                );

                Color menzilRengi = Color.FromArgb(30, 255, 255, 255);
                if (kule is OkKulesi) menzilRengi = Color.FromArgb(30, 0, 255, 0);
                else if (kule is TopKulesi) menzilRengi = Color.FromArgb(30, 255, 100, 0);
                else if (kule is BuyuKulesi) menzilRengi = Color.FromArgb(30, 150, 0, 255);

                using (SolidBrush menzilBrush = new SolidBrush(menzilRengi))
                {
                    g.FillEllipse(menzilBrush,
                        merkez.X - kule.Menzil,
                        merkez.Y - kule.Menzil,
                        kule.Menzil * 2,
                        kule.Menzil * 2);
                }
            }

            foreach (var dusman in aktifDusmanlar)
            {
                int canYuzdesi = (int)((dusman.Can / (double)dalgaDusmanCani) * 100);
                int canCubuguGenislik = (int)(dusman.Gorunumu.Width * (canYuzdesi / 100.0));

                Rectangle arkaplan = new Rectangle(
                    dusman.Gorunumu.Left,
                    dusman.Gorunumu.Top - 8,
                    dusman.Gorunumu.Width,
                    5
                );

                Rectangle canCubugu = new Rectangle(
                    dusman.Gorunumu.Left,
                    dusman.Gorunumu.Top - 8,
                    canCubuguGenislik,
                    5
                );

                g.FillRectangle(Brushes.DarkRed, arkaplan);
                g.FillRectangle(Brushes.LimeGreen, canCubugu);
            }
        }
    }
}
