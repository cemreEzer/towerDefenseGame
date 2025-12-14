
using System.Collections.Generic;
using System.Linq;

namespace towerDefenseGame
{
  
    public class BuyuKulesi : Kule
    {
        private const int BASE_HASAR = 25;
        private const int BASE_MENZIL = 130;
        private const int BASE_FIYAT = 200;
        private const double BASE_SALDIRI_HIZI = 1.5;
        public BuyuKulesi() : base(BASE_HASAR, BASE_MENZIL, BASE_FIYAT, BASE_SALDIRI_HIZI)
        {
        }

        public override void Yukselt()
        {
            seviye++;
            hasar = (int)(hasar * 1.6); // Dengeli hasar artışı
            menzil = (int)(menzil * 1.15); // Daha iyi menzil artışı
            SaldiriHizi *= 0.90; // Saldırı hızını biraz artır (düşür)
            yukseltmeMaliyeti = (int)(yukseltmeMaliyeti * 1.9);
         
        }

        // Saldırı: Menzildeki en yakın 5 düşmana hasar verir.
        public override void Saldir(List<Dusman> hedefListesi)
        {
            // Gelen objenin List<Dusman> olduğunu varsayar.
           
                foreach (var dusman in hedefListesi)
                {
                // Kendi Hasar değerini kullanarak düşmana HasarAl metodunu uygula.
                dusman.HasarAl(this.Hasar);
            }
            
        }
    }
}