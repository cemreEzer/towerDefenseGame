
using System.Collections.Generic;
using System.Linq;

namespace towerDefenseGame
{
    // Ok Kulesi, temel Kule sınıfından miras alır (Inheritance)
    public class OkKulesi : Kule
    {
        // Ok Kulesi'ne özgü sabitler veya ayarlar
        private const int BASE_HASAR = 15;
        private const int BASE_MENZIL = 150;
        private const int BASE_FIYAT = 100;
        private const double BASE_SALDIRI_HIZI = 1.0; // 1.0 saniyede bir saldırı

        // Constructor
        public OkKulesi() : base(BASE_HASAR, BASE_MENZIL, BASE_FIYAT, BASE_SALDIRI_HIZI)
        {
            // Eğer Ok Kulesi'nin kendine özgü ek başlangıç ayarları varsa buraya yazılır.
        }

        // ---------------------------------------------
        // 1. IYukseltilebilir Arayüzü Uygulaması (Polymorphism & Interface)
        // ---------------------------------------------
        public override void Yukselt()
        {
            // Temel sınıftaki protected alanları kullanarak değeri değiştirme
            seviye++;

            // Hasarı artır (Örn: %50 artış)
            hasar = (int)(hasar * 1.5);

            // Menzili artır (Örn: %10 artış)
            menzil = (int)(menzil * 1.15);
            SaldiriHizi *= 0.85; // Saldırı hızını %15 artır (daha düşük saniye değeri)
            yukseltmeMaliyeti = (int)(yukseltmeMaliyeti * 1.7);
           
        }

        // ---------------------------------------------
        // 2. ISaldirabilir Arayüzü Uygulaması (Polymorphism & Abstract Class)
        // ---------------------------------------------
        // Kule sınıfından miras alınan soyut metot implementasyonu
        public override void Saldir(List<Dusman> hedefListesi)
        {
            // Ok Kulesi TEK HEDEF aldığı için, gelen object'in Dusman olup olmadığını kontrol et
            if (hedefListesi.Any())
            {
                // Hasar vermeden önce saldırı hızı (timer) kontrolü yapılabilir.
                Dusman hedef = hedefListesi.First();
                // Düşmana hasar ver
                hedef.HasarAl(this.Hasar);
            }
        }
    }
}