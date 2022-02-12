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

            OpenFileDialog dialog = new OpenFileDialog();

            dialog.InitialDirectory = "c:\\";
            dialog.Filter = "All files (*.json)|*.json";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string location = dialog.FileName;
                string jsoncheck = File.ReadAllText(location);

                datacheck jsonout = JsonConvert.DeserializeObject<datacheck>(jsoncheck);
                Document pdfout = new Document();
                PdfWriter.GetInstance(pdfout, new FileStream(@"C:\Users\Adrian\Documents\GitHub\PDF-Creator\output\resume.pdf", FileMode.Create));
                pdfout.Open();


                // For black line separator in Resume
                LineSeparator separator = new LineSeparator(3f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 1);

                Paragraph fullname = new Paragraph(jsonout.FullName);
                fullname.Alignment = Element.ALIGN_CENTER;
                pdfout.Add(fullname);

                Paragraph address = new Paragraph(jsonout.Address);
                address.Alignment = Element.ALIGN_CENTER;
                pdfout.Add(address);

                Paragraph number = new Paragraph(jsonout.Number);
                number.Alignment = Element.ALIGN_CENTER;
                pdfout.Add(number);

                Paragraph email = new Paragraph(jsonout.Email + "\n\n");
                email.Alignment = Element.ALIGN_CENTER;
                pdfout.Add(email);

                pdfout.Add(separator);

                pdfout.Add(separator);

                Paragraph educLineHead = new Paragraph(jsonout.EducLineHead);
                educLineHead.Font.Size = 12;
                educLineHead.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(educLineHead);

                Paragraph educ1 = new Paragraph(jsonout.Education1);
                educ1.IndentationLeft = 40;
                educ1.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(educ1);

                Paragraph educ2 = new Paragraph(jsonout.Education2 + "\n\n");
                educ2.IndentationLeft = 40;
                educ2.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(educ2);

                pdfout.Add(separator);

                Paragraph workheader = new Paragraph(jsonout.WorkLineHead + "\n");
                workheader.Font.Size = 12;
                workheader.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(workheader);

                Paragraph workExp = new Paragraph(jsonout.WorkExperience + "\n\n");
                workExp.IndentationLeft = 40;
                workExp.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(workExp);

                Paragraph workExp1 = new Paragraph(jsonout.WorkExperience1 + "\n\n");
                workExp1.IndentationLeft = 40;
                workExp1.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(workExp1);



                pdfout.Add(separator);

                Paragraph skillslinehead = new Paragraph(jsonout.Skillslinehead + "\n");
                skillslinehead.Font.Size = 12;
                skillslinehead.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(skillslinehead);

                Paragraph skill1 = new Paragraph(jsonout.Skill1);
                skill1.IndentationLeft = 40;
                skill1.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(skill1);

                Paragraph skill2 = new Paragraph(jsonout.Skill2);
                skill2.IndentationLeft = 40;
                skill2.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(skill2);

                Paragraph skill3 = new Paragraph(jsonout.Skill3 + "\n\n");
                skill3.IndentationLeft = 40;
                skill3.Alignment = Element.ALIGN_LEFT;
                pdfout.Add(skill3);

                pdfout.Add(separator);

                Paragraph fullname1 = new Paragraph(jsonout.FullName);
                fullname1.Alignment = Element.ALIGN_RIGHT;
                pdfout.Add(fullname1);

                pdfout.Close();

                MessageBox.Show("PDF Successfully Created!");
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void convertclick(object sender, EventArgs e)
        {
           
          
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