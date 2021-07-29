using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("users")]
    [Index(nameof(Username), Name = "username", IsUnique = true)]
    public partial class User
    {
        [Key]
        [Column("userid", TypeName = "int unsigned")]
        [Display(Name = "ID User")]
        public int Userid { get; set; }
        [Column("customerid", TypeName = "int unsigned")]
        [Display(Name = "Cliente")]
        public int Customerid { get; set; }
        [Required]
        [Column("username")]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Column("name")]
        [StringLength(100)]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required]
        [Column("surname")]
        [StringLength(100)]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }
        [Required]
        [Column("email")]
        [StringLength(250)]
        public string Email { get; set; }
    }
}
