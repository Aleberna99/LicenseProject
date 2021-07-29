using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("license_models")]
    public partial class LicenseModel
    {
        [Key]
        [Column("productcode")]
        [StringLength(10)]
        public string Productcode { get; set; }
        [Required]
        [Column("producttitle")]
        [StringLength(100)]
        public string Producttitle { get; set; }
        [Column("licensetype", TypeName = "tinyint")]
        public byte Licensetype { get; set; }
        [Column("maxsuppliers")]
        public byte Maxsuppliers { get; set; }
        [Column("maxpersonalcatalogs")]
        public byte Maxpersonalcatalogs { get; set; }
        [Column("maxpricelists")]
        public byte Maxpricelists { get; set; }
        [Column("maxapikeys")]
        public byte Maxapikeys { get; set; }
        [Column("maxpersonalproducts", TypeName = "int unsigned")]
        public int Maxpersonalproducts { get; set; }
        [Column("schedulerenabled")]
        public byte Schedulerenabled { get; set; }
        [Column("backupenabled")]
        public byte Backupenabled { get; set; }
        [Column("icecatenabled")]
        public byte Icecatenabled { get; set; }
        [Required]
        [Column("apiendpoint")]
        [StringLength(250)]
        public string Apiendpoint { get; set; }
    }
}
