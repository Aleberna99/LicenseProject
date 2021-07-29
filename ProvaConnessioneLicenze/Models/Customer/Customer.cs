using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ProvaConnessioneLicenze.Models
{
    [Table("customers")]
    [Index(nameof(Email), Name = "email", IsUnique = true)]
    [Index(nameof(Vatid), Name = "vatid", IsUnique = true)]
    public partial class Customer
    {
        [Key]
        [Column("customerid", TypeName = "int unsigned")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int Customerid { get; set; }
        [Required(ErrorMessage = "Campo CLIENTE obbligatorio")]
        [Column("company")]
        [StringLength(250)]
        [Display(Name = "Cliente")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Company { get; set; }
        [Required(ErrorMessage = "Campo E-MAIL obbligatorio")]
        [Column("email")]
        [StringLength(250)]
        [Display(Name = "E-Mail")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [EmailAddress(ErrorMessage = "Inserire un e-mail valida")]
        public string Email { get; set; }
       
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Column("email2")]
        [StringLength(250)]
        [Display(Name = "E-Mail 2")]
        public string Email2 { get; set; }
        [Required(ErrorMessage = "Campo P.IVA obbligatorio")]
        [Column("vatid")]
        [Display(Name = "P.IVA")]
        [StringLength(11, ErrorMessage = "Codice partita iva errato")]
        [MinLength(11, ErrorMessage = "Codice partita iva errato")]
        [Phone(ErrorMessage = "Codice partita iva errato")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Vatid { get; set; }
        [Required(ErrorMessage = "Campo REFERENTE obbligatorio")]
        [Column("contact")]
        [StringLength(250)]
        [Display(Name = "Referente")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Contact { get; set; }
        [Required(ErrorMessage = "Campo TELEFONO obbligatorio")]
        [Column("phone")]
        [StringLength(30)]
        [Display(Name = "Telefono")]
        [MinLength(10, ErrorMessage = "Inserire un numero di telefono corretto")]
        [Phone(ErrorMessage = "Inserire un numero di telefono corretto")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Phone { get; set; }

        [Column("mobile")]
        [StringLength(30)]
        [Display(Name = "Cellulare")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Mobile { get; set; }

        [Column("notes")]
        [Display(Name = "Note")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Notes { get; set; }
        [Column("customertype")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public byte Customertype { get; set; }

        public FileTxtEngine FileTxtEngine;
        public PdfEngine pdfEngine;
    }
}
