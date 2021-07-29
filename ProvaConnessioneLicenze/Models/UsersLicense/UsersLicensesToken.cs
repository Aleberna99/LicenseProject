using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("users_licenses_tokens")]
    public partial class UsersLicensesToken
    {
        [Key]
        [Column("token")]
        [StringLength(1000)]
        public string Token { get; set; }
        [Required]
        [Column("activationcode")]
        [StringLength(50)]
        public string Activationcode { get; set; }
        [Column("userid", TypeName = "int unsigned")]
        public int Userid { get; set; }
        [Column("duedate")]
        public DateTime? Duedate { get; set; }
        [Column("tokentype", TypeName = "tinyint")]
        public byte? Tokentype { get; set; }
    }
}
