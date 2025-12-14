
using System.Collections.Generic;
using System.Linq;

namespace towerDefenseGame
{
   
    public class TopKulesi : Kule
    {
        private const int BASE_HASAR = 50;
        private const int BASE_MENZIL = 120;
        private const int BASE_FIYAT = 250;
        private const double BASE_SALDIRI_HIZI = 3.0; // 3.0 saniyede bir saldırı (Yavaş)

        public TopKulesi() : base(BASE_HASAR, BASE_MENZIL, BASE_FIYAT, BASE_SALDIRI_HIZI)
        {
        }

        public override void Yukselt()
        {
            seviye++;
            hasar = (int)(hasar * 1.8); // Daha büyük hasar artışı
            menzil = (int)(menzil * 1.05); // Daha az menzil artışı
            SaldiriHizi *= 0.95;
            yukseltmeMaliyeti = (int)(yukseltmeMaliyeti * 2.2); // Daha pahalı yükseltme
           
        }

        // Saldırı: Gelen objenin List<Dusman> olduğunu varsayar ve hepsine hasar verir.
        public override void Saldir(List<Dusman> hedefListesi)
        {
           
                foreach (var dusman in hedefListesi)
                {
               
                dusman.HasarAl(this.Hasar);
           
            }

        }
    }
}