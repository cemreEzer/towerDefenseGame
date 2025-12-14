
using System.Collections.Generic;

namespace towerDefenseGame
{
    public interface ISaldirabilir
    {
        // Saldırı metodunu tanımlama
        void Saldir(List<Dusman> hedefListesi);

        // Saldırı zamanı takibi
        DateTime SonSaldiriZamani { get; set; }
    }
}