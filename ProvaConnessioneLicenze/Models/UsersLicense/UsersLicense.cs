using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("users_licenses")]
    public partial class UsersLicense
    {
        [Key]
        [Column("activationcode")]
        [StringLength(50)]
        public string Activationcode { get; set; }
        [Key]
        [Column("userid", TypeName = "int unsigned")]
        public int Userid { get; set; }
    }
}
