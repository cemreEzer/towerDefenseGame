using System.Windows.Forms;

namespace towerDefenseGame
{
    public class Dusman
    {
        // Kapsülleme: Private alanlar
        private int can; // Düşmanın canı
        private double hiz;
        private int altinDegeri;

        // Form1'den yol koordinatlarını alacak property (Önceki hatanın çözümü)
        public Point[] YolNoktalari { get; set; }

        // Düşmanın oyun alanının sonuna ulaşıp ulaşmadığını belirtir.
        public bool HedefeUlastiMi { get; private set; } = false;

        public int Can
        {
            get { return can; }
            set { can = value; }
        }


        public double Hiz { get; set; }
        public int AltinDegeri => altinDegeri;

        // Görsel referans
        public PictureBox Gorunumu { get; set; }

        // Yoldaki mevcut hedef nokta indeksi
        public int MevcutYolIndex { get; set; } = 1;

        // Constructor
        public Dusman(int baslangicCan, double baslangicHiz, int altin, PictureBox pBox)
        {
            this.can = baslangicCan;
            this.hiz = baslangicHiz;
            this.altinDegeri = altin;
            this.Gorunumu = pBox;
        }

        // ----------------------------------------------------
        // ÇÖZÜM: HASAR AL METODU (Kuleler bu metodu çağırır)
        // ----------------------------------------------------
        public void HasarAl(int hasarMiktari)
        {
            // Gelen hasar miktarını mevcut candan düş
            can -= hasarMiktari;

            // Eğer can 0'ın altına düştüyse, 0'da tutabiliriz (Form1'de kontrol ediliyor)
            if (can < 0)
            {
                can = 0;
            }
        }

        public void HareketEt()
        {
            
            // YolNoktalari null ise veya yolun sonuna ulaştıysak (MevcutYolIndex, son indexi geçtiyse)
            if (YolNoktalari == null || MevcutYolIndex >= YolNoktalari.Length)
            {
                HedefeUlastiMi = true; // Oyunun bitişine ulaşıldı
                return;
            }

            //  Hedef Noktayı Belirler
            Point hedefNokta = YolNoktalari[MevcutYolIndex];

            // Düşman görselinin merkezini al
            // Hareket hesaplamaları her zaman PictureBox'ın merkezi üzerinden yapılır,
            // böylece yolun ortasında kalır.
            Point mevcutKonumMerkez = new Point(
                Gorunumu.Left + Gorunumu.Width / 2,
                Gorunumu.Top + Gorunumu.Height / 2
            );

            // Mesafeyi Hesapla (Pisagor teoremi)
            // Hizmetinizdeki Hiz değişkeni int ise, float'a dönüştürüyoruz.
            float mevcutHiz = (float)hiz;

            double mesafe = Math.Sqrt(
                Math.Pow(hedefNokta.X - mevcutKonumMerkez.X, 2) +
                Math.Pow(hedefNokta.Y - mevcutKonumMerkez.Y, 2)
            );

            // Hedefe Yakınlık Kontrolü
            if (mesafe <= mevcutHiz)
            {
                // Hedefe ulaştık: Görseli tam hedefin üzerine yerleştir
                Gorunumu.Location = new Point(
                    hedefNokta.X - Gorunumu.Width / 2,
                    hedefNokta.Y - Gorunumu.Height / 2
                );

                // Bir sonraki yol noktasına ilerle
                MevcutYolIndex++;
            }
            else // Hedefe Doğru İlerleme (Vektörel Hareket)
            {
                // Hedefe doğru gitmek için gereken yönü (birim vektör) hesapla
                float yonX = (float)((hedefNokta.X - mevcutKonumMerkez.X) / mesafe);
                float yonY = (float)((hedefNokta.Y - mevcutKonumMerkez.Y) / mesafe);

                // Yeni konumu hesapla (hız miktarı kadar ilerle)
                int yeniX = Gorunumu.Left + (int)(yonX * mevcutHiz);
                int yeniY = Gorunumu.Top + (int)(yonY * mevcutHiz);

                // PictureBox'ı yeni konuma taşı
                Gorunumu.Location = new Point(yeniX, yeniY);
            }
        }



    }

}