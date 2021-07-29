using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaConnessioneLicenze.Models
{
    public class CustomerExt
    {
        [Key]
        [Column("customerid", TypeName = "int unsigned")]
        public int Customerid { get; set; }

        [Column("company")]
        [StringLength(250)]
        [Display(Name = "Cliente")]
        public string Company { get; set; }

        [Column("vatid")]
        [StringLength(20)]
        [Display(Name = "P.IVA")]
        public string Vatid { get; set; }

        [Column("email")]
        [StringLength(250)]
        [Display(Name = "E-Mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Column("contact")]
        [StringLength(250)]
        [Display(Name = "Referente")]
        public string Contact { get; set; }
    
        [Column("phone")]
        [StringLength(30)]
        [Display(Name = "Telefono")]
        [Phone]
        public string Phone { get; set; }

        [Display(Name = "Scadenza")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]

        public DateTime? Duedate { get; set; }
    }
}
