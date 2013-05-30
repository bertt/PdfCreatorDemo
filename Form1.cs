using System;
using System.Diagnostics;
using System.Windows.Forms;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PdfCreatorDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 20, XFontStyle.BoldItalic);
            gfx.DrawString("Hello, World!", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.Center);

            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            Process.Start(filename);
        }
    }
}
