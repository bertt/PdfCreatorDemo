﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
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
            gfx.DrawString("Wagenlijst", font, XBrushes.Black,
            new XRect(0, 0, page.Width, page.Height),
            XStringFormats.Center);

            var doc = new Document();
            var sec = doc.AddSection();
            var para = sec.AddParagraph();
            para.Format.Alignment = ParagraphAlignment.Justify;
            para.Format.Font.Name = "Times New Roman";
            para.Format.Font.Size = 12;
            para.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.DarkGray;
            para.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.DarkGray;
            para.AddText("Duisism odigna acipsum delesenisl ");
            para.AddFormattedText("ullum in velenit", TextFormat.Bold);


            para.AddText(" ipit iurero dolum zzriliquisis nit wis dolore vel et nonsequipit, velendigna " +
              "auguercilit lor se dipisl duismod tatem zzrit at laore magna feummod oloborting ea con vel " +
              "essit augiati onsequat luptat nos diatum vel ullum illummy nonsent nit ipis et nonsequis " +
              "niation utpat. Odolobor augait et non etueril landre min ut ulla feugiam commodo lortie ex " +
              "essent augait el ing eumsan hendre feugait prat augiatem amconul laoreet. ≤≥≈≠");
            para.Format.Borders.Distance = "5pt";
            para.Format.Borders.Color = Colors.Gold;

            var docRenderer = new DocumentRenderer(doc);
            docRenderer.PrepareDocument();
            docRenderer.RenderObject(gfx, XUnit.FromCentimeter(5), XUnit.FromCentimeter(10), "12cm", para);
            
            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            Process.Start(filename);
        }


    }
}
