using System.Collections.Generic;
using System.Globalization;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace PdfCreatorDemo
{
    public static class PdfCreator
    {
        public static PdfDocument CreatePdf1(List<Person> persons)
        {
            var document = new Document();
            document.Info.Title = "Created with PDFsharp";

            var sec = document.Sections.AddSection();
            sec.AddParagraph("Persons list");

            // table definition
            var table = sec.AddTable();
            table.Borders.Visible = true;
            table.AddColumn();
            table.AddColumn();
            table.Rows.HeightRule = RowHeightRule.Exactly;
            table.Rows.Height = 14;
            var headerRow = table.AddRow();
            headerRow.HeadingFormat = true;
            headerRow.Cells[0].AddParagraph("Id");
            headerRow.Cells[1].AddParagraph("Name");

            // Fill with data
            foreach (var person in persons)
            {
                var row = table.AddRow();
                row.Cells[0].AddParagraph(person.Id.ToString(CultureInfo.InvariantCulture));
                row.Cells[1].AddParagraph(person.Name.ToString(CultureInfo.InvariantCulture));
            }

            // after table data
            sec.AddParagraph("A Paragraph afterwards");

            var rend = new PdfDocumentRenderer();
            rend.Document = document;
            rend.RenderDocument();
            return rend.PdfDocument;
        }
    }
}
