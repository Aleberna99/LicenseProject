using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class UserExt
    {
        [Key]
        [Display(Name="UserID")]
        public int Userid { get; set; }
        [Display(Name = "Cliente")]
        public string Company { get; set; }
        [Column("username")]
        [StringLength(50)]
        public string Username { get; set; }
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }
        [Column("name")]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Column("surname")]
        [StringLength(100)]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }
        [Column("email")]
        [StringLength(250)]
        [EmailAddress]
        public string Email { get; set; }
    }
}
