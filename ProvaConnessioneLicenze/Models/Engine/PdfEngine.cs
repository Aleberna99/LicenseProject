using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ProvaConnessioneLicenze.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class PdfEngine
    {
        private readonly licenseContext _context;
        public Customer customer;
        string path = @"C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\wwwroot\";

        public PdfEngine(licenseContext context, Customer Customer)
        {
            _context = context;
            customer = Customer;
        }

        public string CreatePdfLicense()
        {
            string pdfPath = path + @"document\PDF\" + customer.Company + "-PdfLicenze.pdf";

            if (File.Exists(pdfPath))
            {
                File.Delete(pdfPath);
                File.Delete(pdfPath);
            }

            FileTxtEngine fileTxtEngine = new FileTxtEngine(_context, customer);
            PdfDocument pdf = new PdfDocument();
            FileInfo fi = fileTxtEngine.CreateFileLicense();

            PdfPage pdfPage = pdf.AddPage();

            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);
            XImage img = XImage.FromFile(path + @"images\" + "titoloPdf.png");

            graph.DrawImage(img, 0, 0);

            using (StreamReader sr = fi.OpenText())
            {
                int currentYposition_values = 100;
                int page = 1;

                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    graph.DrawString(s, font, XBrushes.Black, new XRect(40, currentYposition_values, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
                    currentYposition_values += 20;
                    page++;

                    if (page == 35)
                    {
                        pdfPage = pdf.AddPage();
                        graph = XGraphics.FromPdfPage(pdfPage);
                        graph.DrawImage(img, 0, 0);
                        currentYposition_values = 100;
                        page = 1;
                    }
                }
                sr.Close();
            }

            
            pdf.Save(pdfPath);
            pdf.Close();
            pdf.Dispose();

            return customer.Company + "-PdfLicenze.pdf";
        }
    }
}
