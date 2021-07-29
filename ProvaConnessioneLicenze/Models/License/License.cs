using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("licenses")]
    public partial class License
    {
        [Key]
        [Column("activationcode")]
        [StringLength(50)]
        [Display(Name = "Chiave")]
        [Required]
        public string Activationcode { get; set; }
        [Column("customerid", TypeName = "int unsigned")]
        [Display(Name = "Cliente")]
        public int Customerid { get; set; }
        [Column("resellerid", TypeName = "int unsigned")]
        public int Resellerid { get; set; }
        [Column("activationdate")]
        [Display(Name = "Data attivazione")]
        public DateTime Activationdate { get; set; }
        [Column("duedate")]
        [Display(Name = "Scadenza")]
        public DateTime Duedate { get; set; }
        [Column("locked")]
        [Display(Name = "Locked")]
        public byte Locked { get; set; }
        [Column("notes")]
        [Display(Name = "Note")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Notes { get; set; }
        [Column("licensetype")]
        [Display(Name = "Tipo Licenza")]
        public byte Licensetype { get; set; }
        [Column("maxsuppliers")]
        public byte Maxsuppliers { get; set; }
        [Column("maxpersonalcatalogs")]
        public byte Maxpersonalcatalogs { get; set; }
        [Column("maxpricelists")]
        public byte Maxpricelists { get; set; }
        [Column("maxpersonalproducts", TypeName = "int unsigned")]
        public int Maxpersonalproducts { get; set; }
        [Column("maxapikeys")]
        public byte Maxapikeys { get; set; }
        [Column("icecatenabled")]
        public byte Icecatenabled { get; set; }
        [Column("schedulerenabled")]
        public byte Schedulerenabled { get; set; }
        [Column("backupenabled")]
        public byte Backupenabled { get; set; }
        [Column("lastreminder")]
        public DateTime? Lastreminder { get; set; }
        [Column("onlyforbeta", TypeName = "tinyint")]
        public byte Onlyforbeta { get; set; }
        [Column("apiendpoint")]
        [StringLength(250)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Apiendpoint { get; set; }
    }
}
