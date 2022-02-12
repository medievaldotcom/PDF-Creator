using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;


namespace PDFRESUMECREATOR
{
    public partial class Form1 : Form
    {

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Allfiles (*.*)";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string location = openFileDialog1.FileName;
            }

        }
        location = new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        private void convertclick(object sender, EventArgs e)
        {
            string jsoncheck = File.ReadAllText(location);
            datacheck jsonout = JsonConvert.DeserializeObject<datacheck>(jsoncheck);
            Document pdfout = new Document();
            PdfWriter.GetInstance(pdfout, new FileStream(@"C:\Users\Adrian\Documents\GitHub\PDF-Creator\resume.pdf", FileMode.Create));
            pdfout.Open();



            MessageBox.Show("PDF has been created!");
        }
        public class datacheck
        {
            public string FullName { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Number { get; set; }
            public string EducLineHead { get; set; }
            public string Education1 { get; set; }
            public string Education2 { get; set; }
            public string WorkLineHead { get; set; }
            public string WorkExperience { get; set; }
            public string WorkExperience1 { get; set; }
            public string Skillslinehead { get; set; }
            public string Skill1 { get; set; }
            public string Skill2 { get; set; }
            public string Skill3 { get; set; }

        }


    }
}