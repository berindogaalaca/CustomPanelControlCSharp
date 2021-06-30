using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Panel
{
    public partial class MyPanel : ContainerControl
    {
        private Rectangle Shape; 
        private int x;
        private int y;
        /// <summary>
        /// Componentin kurucu methodu background, size ve stilleri ayarlar
        /// </summary>
        public MyPanel()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);

            BackColor = Color.Transparent;
            x = 200; y = 100;
            Padding = new Padding(0,0, 0, 0);
            this.Size = new Size(201, 101);
            
        }
        /// <summary>
        /// width, height değerlerine göre rectangle çizdirilir.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            Shape = new Rectangle(0, 0, x, y);
            Bitmap Bmp = new Bitmap(Width, Height);
            Graphics Grp = Graphics.FromImage(Bmp);

            Grp.SmoothingMode = SmoothingMode.HighQuality;

            Grp.Clear(Color.Transparent);
            Grp.DrawRectangle(new Pen(Color.FromArgb(180, 180, 180)), Shape);

            Grp.Dispose();
            e.Graphics.DrawImage((Image)Bmp.Clone(), 0, 0);
            Bmp.Dispose();
        }
        /// <summary>
        /// size değiştikçe width, height değerlerini değiştirerek componenti invalidate eder.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            x = this.Size.Width-1;
            y = this.Size.Height-1;
            this.Invalidate();
        }
    }
}
