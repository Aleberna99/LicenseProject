using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProvaConnessioneLicenze.Data;
using ProvaConnessioneLicenze.Models;

namespace ProvaConnessioneLicenze.Controllers
{
    public class UsersController : Controller
    {
        private readonly licenseContext _context;

        public UsersController(licenseContext context)
        {
            _context = context;
        }

        // GET: Users
        public IActionResult Index(string company="", string username="", string name="", string surname="", string email="", string activationcode="")
        {
            List<UserExt> users = new List<UserExt>();

            users = _context.UsersExt
                .FromSqlRaw("SELECT users.`userid`, customers.`company`, users.`username`, users.`password`, " +
                "users.`name`, users.`surname`, users.`email` FROM users LEFT JOIN customers " +
                "ON users.`customerid` = customers.`customerid`")
                .ToList();

            if (company != null && company!="" || username != null && username!="" || name!=null && name!="" || surname!=null && surname!="" || email!="" && email!=null || activationcode != null && activationcode != "")
            {
                if (activationcode != null && activationcode != "")
                {
                    UsersLicense licenseModel = _context.UsersLicenses.FirstOrDefault(m => m.Activationcode == activationcode);
                    users = users.Where(s => s.Userid == licenseModel.Userid).ToList();
                }
                if (company != null && company != "")
                {
                    users = users.Where(s => s.Company.Contains(company)).ToList();
                }
                if (username != null && username != "")
                {
                    users = users.Where(s => s.Username.Contains(username)).ToList();
                }
                if (name != null && name != "")
                {
                    users = users.Where(s => s.Name.Contains(name)).ToList();
                }
                if (surname != null && surname != "")
                {
                    users = users.Where(s => s.Surname.Contains(surname)).ToList();
                }
                if (email != null && email != "")
                {
                    users = users.Where(s => s.Email.Contains(email)).ToList();
                }
            }

            return View(users);
        }

        public IActionResult Search()
        {
            return View();
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            UserExtAdd user = new UserExtAdd();

            user.CustomerDict = _context.Customers.ToDictionary(c => c.Customerid.ToString(),
                                                                    c => c.Company.ToString(),
                                                                    StringComparer.OrdinalIgnoreCase);

            return View(user);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Username, [Bind("Userid,Customerid,Username,Password,Name,Surname,Email")] User user)
        {
            //controllo l'id se esiste già

            if (ModelState.IsValid)
            {
                //controllo che non esista un'altro user con lo stesso username
                var userEqual = await _context.Users
                .FirstOrDefaultAsync(m => m.Username == Username);

                if(userEqual == null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();

                    TempData["Message"] = "USER CREATO CON SUCCESSO";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = "USERNAME GIA' ESISTENTE";
                    //creo un nuovo userextadd perchè la mia funzione create mi prende in ingresso questo tipo e non user
                    UserExtAdd userExtAdd = new UserExtAdd();
                    userExtAdd.Userid = user.Userid;
                    userExtAdd.Customerid = user.Customerid;
                    userExtAdd.Username = user.Username;
                    userExtAdd.Password = user.Password;
                    userExtAdd.Name = user.Name;
                    userExtAdd.Surname = user.Surname;
                    userExtAdd.Email = user.Email;
                    userExtAdd.CustomerDict = _context.Customers.ToDictionary(c => c.Customerid.ToString(),
                                                                    c => c.Company.ToString(),
                                                                    StringComparer.OrdinalIgnoreCase);
                    return View(userExtAdd);
                }
                
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserExtEdit user = new UserExtEdit();

            user.user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.CustomerDict = _context.Customers.ToDictionary(c => c.Customerid.ToString(),
                                                                     c => c.Company.ToString(),
                                                                     StringComparer.OrdinalIgnoreCase);

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Userid,Customerid,Username,Password,Name,Surname,Email")] User user)
        {
            if (id != user.Userid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userEqual = await _context.Users
                   .FirstOrDefaultAsync(m => m.Username == user.Username && m.Userid != id);

                    if (userEqual == null)
                    {
                        _context.Update(user);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.Message = "USERNAME GIA' ESISTENTE";
                        //creo un nuovo userextadd perchè la mia funzione create mi prende in ingresso questo tipo e non user
                        UserExtEdit userExtEdit = new UserExtEdit();
                        userExtEdit.user = await _context.Users.FirstOrDefaultAsync(m => m.Userid == id);
                        userExtEdit.CustomerDict = _context.Customers.ToDictionary(c => c.Customerid.ToString(),
                                                                    c => c.Company.ToString(),
                                                                    StringComparer.OrdinalIgnoreCase);
                        return View(userExtEdit);
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Userid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                TempData["Message"] = "USER AGGIORNATO CON SUCCESSO";
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);

            //se elimino uno user devo eliminare anche la licenza vista la corrispondenza 1 a 1

            var userlicense = await _context.UsersLicenses.FirstOrDefaultAsync(m => m.Userid == id);
            //var license = await _context.Licenses.FirstOrDefaultAsync(l => l.Activationcode == userlicense.Activationcode);

            _context.UsersLicenses.Remove(userlicense);
            //_context.Licenses.Remove(license);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            TempData["Message"] = "USER RIMOSSO CON SUCCESSO";
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Userid == id);
        }
    }
}
