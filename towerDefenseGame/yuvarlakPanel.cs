
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace towerDefenseGame
{
    public class yuvarlakPanel : Panel
    {
        private int koseYaricapi = 15; // Varsayılan yuvarlaklık yarıçapı

        // Tasarım ekranından veya koddan ayarlanabilmesi için özellik (Property)
        public int KoseYaricapi
        {
            get { return koseYaricapi; }
            set
            {
                koseYaricapi = value;
                this.Invalidate(); // Değer değiştiğinde kontrolü yeniden çiz
            }
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            // Kenar yumuşatma ayarını açar
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int r = KoseYaricapi;
            int w = this.Width;
            int h = this.Height;

            // Yuvarlatılmış dikdörtgeni tanımlayan grafik yolu
            GraphicsPath gPath = new GraphicsPath();

            // Köşe yaylarını ekle
            gPath.AddArc(w - r, h - r, r, r, 0, 90);           // Sağ alt köşe
            gPath.AddArc(0, h - r, r, r, 90, 90);              // Sol alt köşe
            gPath.AddArc(0, 0, r, r, 180, 90);                 // Sol üst köşe
            gPath.AddArc(w - r, 0, r, r, 270, 90);             // Sağ üst köşe

            gPath.CloseAllFigures(); // Yolu kapat

            // Kontrolün çizim bölgesini bu yuvarlak yol ile sınırla
            this.Region = new Region(gPath);

            // Arka plan rengini çiz
            using (SolidBrush firca = new SolidBrush(this.BackColor))
            {
                e.Graphics.FillPath(firca, gPath);
            }

            base.OnPaint(e); // Varsayılan Panel çizimini tamamla
        }
    }
}