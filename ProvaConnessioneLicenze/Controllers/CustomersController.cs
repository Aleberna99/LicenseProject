using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Memcached;
using Org.BouncyCastle.Asn1.Cmp;
using ProvaConnessioneLicenze.Data;
using ProvaConnessioneLicenze.Models;

namespace ProvaConnessioneLicenze.Controllers
{
    public class CustomersController : Controller
    {
        private readonly licenseContext _context;

        //private readonly string connectionString = "server=localhost;user=root;database=license;password=pc4centro;port=3306";

        public CustomersController(licenseContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index(string company = "", string email = "", string vatid = "", string contact = "")
        {
            
            List<CustomerExt> customers = _context.CustomerExt
                .FromSqlRaw("SELECT customers.`customerid`, customers.`company`, customers.`vatid`, customers.`email`, customers.`phone`, " +
                    "customers.`contact`, ris.`duedate` FROM customers LEFT JOIN (SELECT `licenses`.`customerid`, MIN(`licenses`.`duedate`) AS duedate " +
                    "FROM licenses WHERE licenses.`duedate` > NOW() GROUP BY licenses.`customerid`) AS ris ON customers.`customerid` = ris.`customerid`")
                .ToList(); 

            if (company != "" && company != null || email != "" && email != null || vatid != "" && vatid != null || contact != "" && contact != null)
            {
                if (company != "" && company != null)
                {
                    customers = customers.Where(s => s.Company.Contains(company)).ToList();
                }
                if (email != "" && email != null)
                {
                    customers = customers.Where(s => s.Email.Contains(email)).ToList();
                }
                if (vatid != "" && vatid != null)
                {
                    customers = customers.Where(s => s.Vatid.Contains(vatid)).ToList();
                }
                if (contact != "" && contact != null)
                {
                    customers = customers.Where(s => s.Contact.Contains(contact)).ToList();
                }
            }

            return View(customers);
        }

        /*public IActionResult Index()
        {
            List<CustomerExt> customers = new List<CustomerExt>();
            
            //connetto a mysql
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT customers.`customerid`, customers.`company`, customers.`vatid`, customers.`email`, customers.`phone`, " +
                    "customers.`contact`, ris.`duedate` FROM customers LEFT JOIN (SELECT `licenses`.`customerid`, MIN(`licenses`.`duedate`) AS duedate " +
                    "FROM licenses WHERE licenses.`duedate` > NOW() GROUP BY licenses.`customerid`) AS ris ON customers.`customerid` = ris.`customerid`", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //estraggo i dati
                    CustomerExt customer = new CustomerExt();
                    customer.Customerid = Convert.ToByte(reader["customerid"]);
                    customer.Company = reader["company"].ToString();
                    customer.Vatid = reader["vatid"].ToString();
                    customer.Email = reader["email"].ToString();
                    customer.Phone = reader["phone"].ToString();
                    customer.Contact = reader["contact"].ToString();
                    if (!(reader["duedate"] is DBNull))
                        customer.Duedate = Convert.ToDateTime(reader["duedate"]);

                    customers.Add(customer);
                }
                reader.Close();
            }

            return View(customers);
        }*/

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Customerid == id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Vatid, string Email, [Bind("Customerid,Company,Email,Email2,Vatid,Contact,Phone,Mobile,Notes,Customertype")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var customer1 = await _context.Customers
                .FirstOrDefaultAsync(m => m.Vatid == Vatid);

                var customer2 = await _context.Customers
                .FirstOrDefaultAsync(m => m.Email == Email);

                //se non ho trovati altri clienti con la stessa e-mail e partita iva salvo il nuovo cliente
                if(customer1 == null && customer2 == null)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "CLIENTE CREATO CON SUCCESSO";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (customer1 != null )
                    {
                        ViewBag.Message = "P.IVA GIA' ESISTENTE";
                    }
                    if (customer2 != null)
                    {
                        ViewBag.Message = "E-MAIL GIA' ESISTENTE";
                    }
                    if (customer1 != null && customer2 != null)
                    {
                        ViewBag.Message = "E-MAIL E P.IVA GIA' ESISTENTE";
                    }

                    return View(customer);
                }  
                
            }
            return View(customer);

        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string Vatid, string Email, [Bind("Customerid,Company,Email,Email2,Vatid,Contact,Phone,Mobile,Notes,Customertype")] Customer customer)
        {
            if (id != customer.Customerid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var customer1 = await _context.Customers
                        .FirstOrDefaultAsync(m => m.Vatid == Vatid && m.Customerid != id);

                    var customer2 = await _context.Customers
                        .FirstOrDefaultAsync(m => m.Email == Email && m.Customerid != id);

                    if (customer1 == null && customer2 == null)
                    {
                        _context.Update(customer);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        if (customer1 != null)
                        {
                            ViewBag.Message = "P.IVA GIA' ESISTENTE";
                        }
                        if (customer2 != null)
                        {
                            ViewBag.Message = "E-MAIL GIA' ESISTENTE";
                        }
                        if (customer1 != null && customer2 != null)
                        {
                            ViewBag.Message = "E-MAIL E P.IVA GIA' ESISTENTE";
                        }

                        return View(customer);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Customerid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                TempData["Message"] = "CLIENTE AGGIORNATO CON SUCCESSO";
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.Customerid == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            TempData["Message"] = "CLIENTE RIMOSSO CON SUCCESSO";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search()
        {
            return View();
        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Customerid == id);
        }

        public async Task<IActionResult> Email(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.FileTxtEngine = new FileTxtEngine(_context,customer);
            customer.pdfEngine = new PdfEngine(_context,customer);

            return View(customer);
        }

        [HttpPost]
        public IActionResult Email(string email, int id)
        {
            Customer customer = _context.Customers.First(c => c.Customerid == id);

            try
            {
                PdfEngine createPdf = new PdfEngine(_context,customer);
                string pdfName = createPdf.CreatePdfLicense();

                EmailEngine createEmail = new EmailEngine();
                createEmail.SendEmail(customer, email, pdfName);

                TempData["Message"] = "E-MAIL INVIATA CON SUCCESSO";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = "ERRORE INVIO E-MAIL";
                return View(customer);
            }

        }

    }
}
