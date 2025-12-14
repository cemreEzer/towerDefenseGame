
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic; 
using System.Linq; 

namespace towerDefenseGame
{
    internal class Mermi
    {
        //  Alanlar (Fields)
        public PictureBox Gorunumu { get; set; } 
        public Dusman Hedef { get; private set; }
        public Kule AticiKule { get; private set; }
        public int Hiz { get; set; } = 8; // Mermi hızı

        // 2. Yapıcı Metot (Constructor)
        public Mermi(Point baslangic, Dusman hedef, Kule aticiKule, PictureBox gorunum)
        {
            this.Hedef = hedef;
            this.AticiKule = aticiKule;
            this.Gorunumu = gorunum; //Gelen PictureBox'ı Gorunumu özelliğine atıyoruz
        }

        // 3. Mermi hareket metodu 
        public void HareketEt()
        {
            // Merminin düşmana doğru hareket etme mantığı buraya gelir
           
        }

        // 4. Çarpışma kontrol metodu
        public bool CarptiMi()
        {
            // Merminin düşmanın görsel konumu ile çarpışıp çarpışmadığı 
            return Gorunumu.Bounds.IntersectsWith(Hedef.Gorunumu.Bounds);
        }
    }
}