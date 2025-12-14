using System.Drawing; 
using System.Security.Policy;
using System.Windows.Forms;
using towerDefenseGame; 

public abstract class Kule : ISaldirabilir, IYukseltilebilir
{
    // KAPSÜLLEME İÇİN PRIVATE ALANLAR
    protected int hasar;
    protected int menzil;
    protected int fiyat;
    private PictureBox gorunumu; 

    // IYukseltilebilir
    protected int seviye = 1;
    protected int yukseltmeMaliyeti = 50;
  


    // PUBLIC ÖZELLİKLER (PROPERTIES)
    public DateTime SonSaldiriZamani { get; set; } = DateTime.Now;
    public double SaldiriHizi { get; set; } // Kule hızını (örneğin 1.0) tutar
    public int Hasar => hasar;
    public int Menzil => menzil;
    public int Fiyat => fiyat;

    public int X { get; set; }
    public int Y { get; set; }

    public PictureBox Gorunumu
    {
        get { return gorunumu; }
        set { gorunumu = value; } 
    }

    public int Seviye => seviye;
    public int YukseltmeMaliyeti => yukseltmeMaliyeti;


    // Abstract Saldir metodu tanımı
    // Tüm alt sınıflar bunu implemente etmek zorundadır.
    public abstract void Saldir(List<Dusman> hedefListesi);


    // Constructor (Yapıcı Metot) 
    public Kule(int hasar, int menzil, int fiyat, double saldiriHizi)
    {
        this.hasar = hasar;
        this.menzil = menzil;
        this.fiyat = fiyat;
        // PictureBox buraya parametre olarak gelmediği için burada atama yapmayız.
        // Atama işlemi Form1'deki pnlOyunAlani_MouseClick olayında gerçekleşir.
    }

    // Zorunlu Metotlar (Abstract ve Interface)
    public abstract void Yukselt();
   
}