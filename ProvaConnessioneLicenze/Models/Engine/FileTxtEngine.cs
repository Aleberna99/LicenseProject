using ProvaConnessioneLicenze.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class FileTxtEngine
    {
        private readonly licenseContext _context;
        public Customer customer;
        string path = @"C:\Users\Roberto\source\repos\PROGETTO TIROCINIO\ProvaConnessioneLicenze\ProvaConnessioneLicenze\wwwroot\";

        public FileTxtEngine(licenseContext context, Customer _customer)
        {
            _context = context;
            customer = _customer;
        }

        public FileInfo CreateFileLicense()
        {
            //~
            string fileName = path + @"document\TXT\" + customer.Company + "-FileLicenze.txt";
            FileInfo fi = new FileInfo(fileName);
            
            try
            {
                // Check if file already exists. If yes, delete it.     
                if (fi.Exists)
                {
                    fi.Delete();
                }

                // Create a new file     
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine("LICENZE ImporterONE\n\n" +
                                "Intestatario: IMPRIMIS Srl\n" +
                                "Mail: info@imprimis.it\n" +
                                "P.IVA: 02026020426\n\n" +
                                "UTENZE\n");

                    List<License> licenses = _context.Licenses.Where(l => l.Customerid == customer.Customerid).ToList();

                    foreach (License license in licenses)
                    {
                        LicenseModel licenseModel = _context.LicenseModels.First(m => m.Licensetype == license.Licensetype);
                        UsersLicense usersLicense = _context.UsersLicenses.First(m => m.Activationcode == license.Activationcode);
                        User user = _context.Users.First(m => m.Userid == usersLicense.Userid);

                        sw.WriteLine("Tipo Licenza : " + licenseModel.Producttitle);
                        sw.WriteLine("Codice Attivazione : " + license.Activationcode);
                        sw.WriteLine("Username : " + user.Username);
                        sw.WriteLine("Data Scadenza : " + license.Duedate);
                        sw.WriteLine("--------------------------------------------------------------------------");
                        sw.WriteLine();
                    }

                    sw.WriteLine("Vai su https://app.importerone.it");
                    sw.Close();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }

            return fi;
        }

    }
}
