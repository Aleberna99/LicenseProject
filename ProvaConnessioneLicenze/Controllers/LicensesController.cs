using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using ProvaConnessioneLicenze.Data;
using ProvaConnessioneLicenze.Models;

namespace ProvaConnessioneLicenze.Controllers
{
    public class LicensesController : Controller
    {
        private readonly licenseContext _context;

        public LicensesController(licenseContext context)
        {
            _context = context;
        }

        public IActionResult Index(string company = "", string activationcode ="", string producttitle="", string stato = "", DateTime? scadenza_da=null, DateTime? scadenza_a=null, bool? locked=null)
        {
            List<LicenseExt> licenses = _context.LicenseExt
                .FromSqlRaw("SELECT licenses.`activationcode`, licenses.`duedate`,license_models.`producttitle`, customers.`company`, users.`name`, " +
                    "users.`surname`,licenses.`locked` FROM licenses LEFT JOIN users_licenses ON users_licenses.activationcode = licenses.activationcode " +
                    "LEFT JOIN users ON users.userid = users_licenses.userid LEFT JOIN customers ON customers.`customerid` = licenses.`customerid` " +
                    "LEFT JOIN license_models ON license_models.licensetype = licenses.licensetype")
                .ToList();

            if (company != "" && company != null || activationcode != "" && activationcode != null || locked != null
                || producttitle != "" && producttitle != null || scadenza_da != null ||  scadenza_a != null || stato != "" && stato != null)
            {
                if (company != "" && company != null)
                {
                    licenses = licenses.Where(s => s.Company.Contains(company)).ToList();
                }
                if (activationcode != "" && activationcode != null)
                {
                    licenses = licenses.Where(s => s.Activationcode.Contains(activationcode)).ToList();
                }
                if (producttitle != "" && producttitle != null)
                {
                    licenses = licenses.Where(s => s.Producttitle.Contains(producttitle)).ToList();
                }
                if (scadenza_da != null)
                {
                    licenses = licenses.Where(s => s.Duedate.Date >= scadenza_da).ToList();
                }
                if (scadenza_a != null)
                {
                    licenses = licenses.Where(s => s.Duedate.Date <= scadenza_a).ToList();
                }
                if (stato != "" && stato != null)
                {
                    if (stato == "attivo")
                    {
                        licenses = licenses.Where(s => s.Duedate.Date > DateTime.Now).ToList();
                    }
                    if (stato == "scaduto")
                    {
                        licenses = licenses.Where(s => s.Duedate.Date < DateTime.Now).ToList();
                    }
                    if (stato == "vicina")
                    {
                        licenses = licenses.Where(s => DateTime.Now < s.Duedate.Date && s.Duedate.Date < DateTime.Now.AddMonths(1)).ToList();

                    }
                }
                if (locked != null)
                {
                    licenses = licenses.Where(s => s.Locked == locked).ToList();
                }
            }

            return View(licenses);
        }

        /*public IActionResult Index()
        {
            List<LicenseExt> licenses = new List<LicenseExt>();

            //connetto a mysql
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=license;password=pc4centro;port=3306"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT licenses.`activationcode`, licenses.`duedate`,license_models.`producttitle`, customers.`company`, users.`name`, " +
                    "users.`surname`,licenses.`locked` FROM licenses LEFT JOIN users_licenses ON users_licenses.activationcode = licenses.activationcode " +
                    "LEFT JOIN users ON users.userid = users_licenses.userid INNER JOIN customers ON customers.`customerid` = licenses.`customerid` " +
                    "INNER JOIN license_models ON license_models.licensetype = licenses.licensetype ", con);
                
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //estraggo i dati
                    LicenseExt license = new LicenseExt();
                    
                    license.Activationcode = reader["activationcode"].ToString();
                    license.Duedate = Convert.ToDateTime(reader["duedate"]);
                    license.Producttitle = reader["producttitle"].ToString();
                    license.Company = reader["company"].ToString();
                    license.Name = reader["name"].ToString();
                    license.Surname = reader["surname"].ToString();
                    license.Locked = Convert.ToByte(reader["locked"]);

                    if (license.Duedate < DateTime.Now)
                    {
                        license.State = "Scaduta";
                    }
                    else
                    {
                        license.State = "Attiva";
                    }

                    licenses.Add(license);
                }
                reader.Close();
            }

            return View(licenses);
        }*/


        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.Licenses
                .FirstOrDefaultAsync(m => m.Activationcode == id);
            if (license == null)
            {
                return NotFound();
            }

            return View(license);
        }

        // GET: Licenses/Create
        public IActionResult Create()
        {
            LicenseExtAdd licenses = new LicenseExtAdd();

            licenses.CustomerDict = _context.Customers.ToDictionary(c => c.Customerid.ToString(),
                                                                    c => c.Company.ToString(),
                                                                    StringComparer.OrdinalIgnoreCase);

            licenses.LicenseDict = _context.LicenseModels.ToDictionary(c => c.Licensetype.ToString(),
                                                                    c => c.Producttitle.ToString(),
                                                                    StringComparer.OrdinalIgnoreCase);

            return View(licenses);
        }

        // POST: Licenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Name, string Surname, [Bind("Customerid,Activationcode,Licensetype,Duedate,Locked,Onlyforbeta,Notes,Apiendpoint")] License License)
        {
            if (ModelState.IsValid)
            {
                //compilo i campi relativi al licensemodel
                CompliteLicenseInfo(License);

                //creo la licenza, lo user e il loro collegamento
                User user = new User();
                Customer customer = new Customer();
                UsersLicense usersLicense = new UsersLicense();

                customer = (from c in _context.Customers
                            where c.Customerid == License.Customerid
                            select c).FirstOrDefault();

                user.Name = Name;
                user.Surname = Surname;
                user.Password = GeneraPassword();
                user.Customerid = customer.Customerid;
                user.Email = customer.Email;
                user.Username = GeneraUsername();

                _context.Add(user);
                _context.Add(License);
                await _context.SaveChangesAsync();

                usersLicense.Activationcode = License.Activationcode;
                usersLicense.Userid = user.Userid;

                _context.Add(usersLicense);
                await _context.SaveChangesAsync();

                TempData["Message"] = "LICENZA CREATA CON SUCCESSO";
                return RedirectToAction(nameof(Index));
            }

            return View(License);
        }

        public async Task<IActionResult> Edit(string id)
        {
            //FACCIO L'UPDATE DI QUELLO GIA PRESENTE

            if (id == null)
            {
                return NotFound();
            }

            LicenseExtEdit license = new LicenseExtEdit();

            license.License = await _context.Licenses
                .FirstOrDefaultAsync(m => m.Activationcode == id);

            //ora mi trovo lo user collegato, se esiste
            UsersLicense usersLicense = await _context.UsersLicenses
                .FirstOrDefaultAsync(m => m.Activationcode == id);

            if(usersLicense != null)
            {
                license.User = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == usersLicense.Userid);
            }
            else
            {
                license.User = null;
            }

            //riempio i dizionari
            license.CustomerDict = _context.Customers.ToDictionary(c => c.Customerid.ToString(),
                                                                    c => c.Company.ToString(),
                                                                    StringComparer.OrdinalIgnoreCase);

            license.LicenseDict = _context.LicenseModels.ToDictionary(c => c.Licensetype.ToString(),
                                                                    c => c.Producttitle.ToString(),
                                                                    StringComparer.OrdinalIgnoreCase);

            //dizionario per tenere traccia degli user disponibili che non hanno associato nessun'altra licenza
            license.UserDict = (from u in _context.Users
                                where !(from r in _context.UsersLicenses
                                        select r.Userid)
                                        .Contains(u.Userid)
                                select new { u.Userid, u.Username }).ToDictionary(x=> x.Userid.ToString(), 
                                                                                  x => x.Username.ToString(), 
                                                                                  StringComparer.OrdinalIgnoreCase);

            return View(license);
        }

        // POST: Licenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, int Userid, [Bind("Activationcode,Customerid,Duedate,Locked,Notes,Licensetype,Onlyforbeta,Apiendpoint")] License license)
        {
            if (id != license.Activationcode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //se decido di modificare anche lo user collegato allora aggiorno i collegamenti
                    //ed elimino lo user visto che la relazione è 1 a 1
                    if (Userid != -1)
                    {
                        //rimuovo il vecchio colegamento, se esiste
                        UsersLicense usersLicenseOld = await _context.UsersLicenses
                            .FirstOrDefaultAsync(m => m.Activationcode == license.Activationcode);

                        if(usersLicenseOld != null)
                        {
                            User user = await _context.Users
                            .FirstOrDefaultAsync(m => m.Userid == usersLicenseOld.Userid);

                            _context.Remove(usersLicenseOld);
                            _context.Remove(user);
                        }

                        //creo il nuovo collegamento e l'aggiungo
                        UsersLicense usersLicenseNew = new UsersLicense();
                        usersLicenseNew.Activationcode = license.Activationcode;
                        usersLicenseNew.Userid = Userid;

                        _context.Add(usersLicenseNew);

                    }

                    CompliteLicenseInfo(license);

                    _context.Update(license);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenseExists(license.Activationcode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                TempData["Message"] = "LICENZA AGGIORNATA CON SUCCESSO";
                return RedirectToAction(nameof(Index));
            }

            //correggo tutti
            return View(license);
        }


        private void CompliteLicenseInfo(License license)
        {
            //compilo le informazioni della licenza con i relativi campi presenti nel license_model
            LicenseModel licenseModel =  _context.LicenseModels.First(m => m.Licensetype == license.Licensetype);

            license.Maxsuppliers = licenseModel.Maxsuppliers;
            license.Maxpersonalcatalogs = licenseModel.Maxpersonalcatalogs;
            license.Maxpricelists = licenseModel.Maxpricelists;
            license.Maxpersonalproducts = licenseModel.Maxpersonalproducts;
            license.Maxapikeys = licenseModel.Maxapikeys;
            license.Schedulerenabled = licenseModel.Schedulerenabled;
            license.Backupenabled = licenseModel.Backupenabled;
            license.Icecatenabled = licenseModel.Icecatenabled;
            license.Apiendpoint = licenseModel.Apiendpoint;
        }

        // GET: Licenses/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var license = await _context.Licenses
                .FirstOrDefaultAsync(m => m.Activationcode == id);
            if (license == null)
            {
                return NotFound();
            }

            return View(license);
        }

        // POST: Licenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var license = await _context.Licenses.FindAsync(id);
            _context.Licenses.Remove(license);

            UsersLicense usersLicense = await _context.UsersLicenses
                .FirstOrDefaultAsync(m => m.Activationcode == id);

            _context.UsersLicenses.Remove(usersLicense);

            User user = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == usersLicense.Userid);

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            TempData["Message"] = "LICENZA RIMOSSA CON SUCCESSO";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search()
        {
            return View();
        }

        private bool LicenseExists(string id)
        {
            return _context.Licenses.Any(e => e.Activationcode == id);
        }

        private string GeneraPassword()
        {
            int len = 12;
            const string ValidChar = "qwertyuioplkjhgfdsazxcvbnm:!?/%&$@#QWERTYUIOPLKJHGFDSAZXCVBNM1234567890";

            StringBuilder result = new StringBuilder();

            Random rnd = new Random();

            while(0 < len--)
            {
                result.Append(ValidChar[rnd.Next(ValidChar.Length)]);
            }

            return result.ToString();
        }

        private string GeneraUsername()
        {
            int len = 4;
            const string ValidChar = "1234567890";

            StringBuilder result = new StringBuilder();

            Random rnd = new Random();

            while (0 < len--)
            {
                result.Append(ValidChar[rnd.Next(ValidChar.Length)]);
            }

            return "IMP-" + result.ToString();
        }
        public string GeneraCodiceAttivazione()
        {
            string result;

            result = GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori() + "-" + GeneraValori();

            return result;
        }

        private string GeneraValori()
        {
            int len = 5;
            const string ValidChar = "QWERTYUIOPLKJHGFDSAZXCVBNM1234567890";

            StringBuilder result = new StringBuilder();

            Random rnd = new Random();

            while (0 < len--)
            {
                result.Append(ValidChar[rnd.Next(ValidChar.Length)]);
            }

            return result.ToString();
        }

    }
}
