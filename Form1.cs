using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace PdfCreatorDemo
{
    public class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String FullName { get; set; }
    }


    public partial class Form1 : Form
    {
        public List<Person> GetPersons()
        {
            var p1 = new Person() {FullName = "Puk", Id = 1, Name = "Pietje"};
            var p2 = new Person() { FullName = "Puk2", Id = 2, Name = "Pietje2" };
            var p3 = new Person() { FullName = "Puk3", Id = 3, Name = "Pietje3" };
            var p4 = new Person() { FullName = "Puk4", Id = 3, Name = "Pietje4" };
            var persons = new List<Person>() {p1, p2, p3, p4};
            return persons;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var persons = GetPersons();
            var doc = PdfCreator.CreatePdf(persons);
            const string filename = "HelloWorld.pdf";
            doc.Save(filename);
            Process.Start(filename);
        }



    }
}
