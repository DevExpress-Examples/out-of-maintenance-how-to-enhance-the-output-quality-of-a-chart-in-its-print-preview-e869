using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraPrinting;

namespace dxKB17093 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        System.Drawing.Imaging.Metafile mf;
        private void button1_Click(object sender, EventArgs e) {
            MemoryStream ms = new MemoryStream();
            try {
                chartControl1.ExportToImage(ms, System.Drawing.Imaging.ImageFormat.Wmf);
                ms.Seek(0, SeekOrigin.Begin);
                mf = new System.Drawing.Imaging.Metafile(ms);
            }
            finally { ms.Close(); }

            Link l = new Link(new PrintingSystem());
            l.CreateDetailArea += new CreateAreaEventHandler(l_CreateDetailArea);
            l.ShowPreview();
        }

        void l_CreateDetailArea(object sender, CreateAreaEventArgs e) {
            Link l = sender as Link;
            ImageBrick ib = new ImageBrick();
            ib.Rect = new RectangleF(0, 0,chartControl1.Width, chartControl1.Height);
            ib.Image = mf;
            e.Graph.DrawBrick(ib);
        }
    }
}