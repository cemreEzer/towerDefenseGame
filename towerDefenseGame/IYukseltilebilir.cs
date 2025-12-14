namespace towerDefenseGame
{
    
    public interface IYukseltilebilir
    {
        // Yükseltmenin maliyetini döndürür (property)
        int YukseltmeMaliyeti { get; }

        // Kuleyi yükselten ana metot
        void Yukselt();

        // Yükseltme seviyesini gösterir
        int Seviye { get; }
    }
}